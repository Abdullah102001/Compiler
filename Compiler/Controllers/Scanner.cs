﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerS
{


    public class Scanner
    { 
        static public string Code = "";
        static public State State = new State(0);
        static public int i = 0;
        string TokenValue = "";
        string LastInputString = "";
        char NextChar;
        List<Token> RightTokens = new List<Token>();
        List<Token> WrongTokens = new List<Token>();
        
        public string Scanner1()
        {
            if (!TransitionTable.IsDelimiter(Code[Code.Length-1]))
            {
                Code += "\0";
            }
            while(i < Code.Length)
            {
                
  
                while (State.StateNumber != -1&& !State.IsAcceptance && i < Code.Length)
                {
                    NextChar = NextCharacter();
                    LastInputString += NextChar;          
                    State = TransitionTable.GetNextState(State, NextChar);
                    TokenValue += NextChar;              
                }

                if (State.IsAcceptance && TransitionTable.IsDelimiter(NextChar))
                {
                    RightTokens.Add(new Token(
                        GetLineNumber(LastInputString),
                        State.TokenType,
                        RemoveLastCharacter(TokenValue)));
                    State = new State(0);
                    TokenValue = "";
                } 
                else if (State.IsAcceptance)
                {
                    RightTokens.Add(new Token(
                        GetLineNumber(LastInputString),
                        State.TokenType,
                        RemoveLastCharacter(TokenValue)));
                    State = new State(0);
                    TokenValue = "";
                }
                else 
                {
                    while(!TransitionTable.IsDelimiter(NextChar) && i < Code.Length)
                    {
                        
                        NextChar = NextCharacter();
                        TokenValue += NextChar;
                    }
                    WrongTokens.Add(new Token(
                        GetLineNumber(LastInputString),
                        State.TOKENTYPE.ERROR,
                        RemoveLastCharacter(TokenValue)));
                    State = new State(0);
                    TokenValue = "";
                }
            }
            var tokens = "";
            foreach (Token token in RightTokens)
            {
                if(token.TokenType != State.TOKENTYPE.DELIMITER)
                {
                    tokens += token.PrintToken();
                    tokens += "\n";
                }
            }
            foreach (Token token in WrongTokens)
            {
                if (token.TokenType != State.TOKENTYPE.DELIMITER)
                {
                    tokens += token.PrintToken();
                    tokens += "\n";
                }
            }
            i = 0; 
            return tokens;
        }

        string RemoveLastCharacter(string TokenValue)
        {
            string NewToken = "";
            if(TokenValue.Length > 1)
            {
                for (int i = 0; i < TokenValue.Length - 1; i++)
                {
                    NewToken += TokenValue[i];
                }
                return NewToken;
            } else
            {
                return TokenValue;
            }
            
        }
        public int GetLineNumber(string LastInput)
        {
            int NumberOfLine = 1;
            for(int i = 0; i < LastInput.Length; i++)
            {
                if(LastInput[i] == '\n' && i != LastInput.Length-1)
                    NumberOfLine++;
            }
            return NumberOfLine;
        }

        public char NextCharacter()
        {
            return Code[i++];
        }


        public void PrintTokens()
        {
            Console.WriteLine("Right");
            foreach (Token token in RightTokens)
            { 
                Console.WriteLine(token.PrintToken());
            }
            Console.WriteLine("Error");
            foreach (Token token in WrongTokens)
            {
                Console.WriteLine(token.PrintToken());
            }
        }

       


    }
}