using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{

    public class Scanner
    {
        static public string Code = "";
        static public State State = new State(0);
        static public int i = 0;
        static string TokenValue = "";
        static string LastInputString = "";
        static char NextChar;
        static List<Token> ParseingTokens = new List<Token>();
        static List<string> right = new List<string>();

        public static List<Token> Scan()
        {
            if (!TransitionTable.IsDelimiter(Code[Code.Length - 1]))
            {
                Code += "\0";
            }
            while (i < Code.Length)
            {


                while (State.StateNumber != -1 && !State.IsAcceptance && i < Code.Length)
                {
                    NextChar = NextCharacter();
                    LastInputString += NextChar;
                    State = TransitionTable.GetNextState(State, NextChar);
                    TokenValue += NextChar;
                }

                if (State.IsAcceptance)
                {
                    ParseingTokens.Add(new Token(
                        GetLineNumber(LastInputString),
                        State.TokenType,
                        RemoveLastCharacter(TokenValue)));
                    AddCommentString(RemoveLastCharacter(TokenValue));
                    right.Add(RemoveLastCharacter(TokenValue));
                    State = new State(0);
                    TokenValue = "";

                }
                else
                {
                    while (!TransitionTable.IsDelimiter(NextChar) && i < Code.Length)
                    {
                        NextChar = NextCharacter();
                        TokenValue += NextChar;
                    }
                    ParseingTokens.Add(new Token(
                        GetLineNumber(LastInputString),
                        State.TokenType,
                        RemoveLastCharacter(TokenValue)));
                    State = new State(0);
                    TokenValue = "";
                }

            }
            return RemoveDelimeters(ParseingTokens);
        }

        public static void PrepareScanner()
        {
            State = new State(0);
            i = 0;
            TokenValue = "";
            LastInputString = "";
            ParseingTokens.Clear();
        }
        private static void AddCommentString(string TokenValue)
        {
            if (TokenValue == "$$$")
            {
                TokenValue = "";
                while (NextChar != '\n' && i < Code.Length)
                {
                    NextChar = NextCharacter();
                    TokenValue += NextChar;
                    LastInputString += NextChar;
                }
                ParseingTokens.Add(new Token(
                    GetLineNumber(LastInputString),
                    State.TOKENTYPE.STR,
                    RemoveLastCharacter(TokenValue)));
            }

            if (TokenValue == "/$")
            {
                TokenValue = "";
                while (NextChar != '$' && i < Code.Length)
                {
                    NextChar = NextCharacter();
                    TokenValue += NextChar;
                    LastInputString += NextChar;
                }
                ParseingTokens.Add(new Token(
                    GetLineNumber(LastInputString),
                    State.TOKENTYPE.STR,
                    RemoveLastCharacter(TokenValue)));
                i--;
            }
        }

        private static List<Token> RemoveDelimeters(List<Token> Tokens)
        {
            for(int i = 0; i < Tokens.Count - 1; i++)
            {
                if (Tokens[i].TokenType == State.TOKENTYPE.DELIMITER ||
                    Tokens[i].TokenType == State.TOKENTYPE.NULL )
                    Tokens.RemoveAt(i);
            }
            return Tokens;
        }
        private static string RemoveLastCharacter(string TokenValue)
        {
            string NewToken = "";
            if (TokenValue.Length > 1)
            {
                for (int i = 0; i < TokenValue.Length - 1; i++)
                {
                    NewToken += TokenValue[i];
                }
                return NewToken;
            }
            else
            {
                return TokenValue;
            }

        }

        private static int GetLineNumber(string LastInput)
        {
            int NumberOfLine = 1;
            for (int i = 0; i < LastInput.Length; i++)
            {
                if (LastInput[i] == '\n' && i != LastInput.Length - 1)
                    NumberOfLine++;
            }
            return NumberOfLine;
        }

        private static char NextCharacter()
        {
            return Code[i++];
        }


        public List<string> Red_Line()
        {
            return right;
        }


    }
}
