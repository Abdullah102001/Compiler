using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerS
{


    public class Scanner
    { 
        static public string Code = "Loopwhen(counter<num){\nSIow";
        static public State State = new State(0);
        static public int i = 0;
        string TokenValue = "";
        string LastInputString = "";
        char NextChar;
        List<Token> RightTokens = new List<Token>() { };
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
                        State.TOKENTYPE.BREAK,
                        RemoveLastCharacter(TokenValue)));
                    State = new State(0);
                    TokenValue = "";
                }

                //if (State.IsAcceptance)
                //{
                //    RightTokens.Add(new Token(
                //        GetLineNumber(LastInputString),
                //        State.TOKENTYPE.BREAK,
                //        TokenValue));
                //    State = new State(0);
                //    TokenValue = "";
                //}
            }
            var tokens = "";
            foreach (Token token in RightTokens)
            {
                tokens += token.PrintToken();
                tokens += "\n";
            }
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
            foreach(char x in LastInput)
            {
                if (x == '\n')
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

        




        //int State = 0;
        //int i = 0;
        //public string Line = "sdsfsdfad";
        //string TokenValue = "";
        //public TOKENTYPE GetToken()
        //{
        //    Line = Line + " ";
        //    int EndOfLine = Line.Length;
        //    while (i < EndOfLine)
        //    {
        //        char NextChar = NextCharacter();
        //        if(NextChar == ' ')
        //        {
        //            continue;
        //        }
        //        else
        //        {
        //            switch (NextChar)
        //            {
        //                case 'S': //Done
        //                    State = 1;
        //                    TokenValue += "S";
        //                    return CheckState1();  
        //                case 'C':
        //                    State = 1;
        //                    TokenValue += "C";
        //                    return CheckState2();
        //                case 'L':
        //                    break;
        //                case 'I':
        //                    break;
        //                case 'W':
        //                    break;
        //                case 'T':
        //                    break;
        //                case 'E':
        //                    break;
        //                case '=':
        //                    if (Line[i + 1] == '=')
        //                    {
        //                        i++;
        //                        return TOKENTYPE.RELATIONALOPERATION;
        //                    }
        //                    else
        //                        return TOKENTYPE.ASSIGNMENTOPERATION;
        //                case '<':
        //                    if (Line[i + 1] == '=')
        //                    {
        //                        i++;
        //                        return TOKENTYPE.RELATIONALOPERATION;
        //                    }
        //                    else
        //                        return TOKENTYPE.RELATIONALOPERATION;
        //                case '>':
        //                    if (Line[i + 1] == '=')
        //                    {
        //                        i++;
        //                        return TOKENTYPE.RELATIONALOPERATION;
        //                    }
        //                    else
        //                        return TOKENTYPE.RELATIONALOPERATION;
        //                case '!':
        //                    if (Line[i + 1] == '=')
        //                    {
        //                        i++;
        //                        return TOKENTYPE.RELATIONALOPERATION;
        //                    }
        //                    else
        //                        return TOKENTYPE.ERROR;
        //                case '+' or '-' or '*' or '/':
        //                    return TOKENTYPE.ARITHMETICOPERATION;
        //                case '~':
        //                    return TOKENTYPE.LOGICOPERATION;
        //                case '|':
        //                    if (Line[i + 1] == '|')
        //                    {
        //                        i++;
        //                        return TOKENTYPE.LOGICOPERATION;
        //                    }
        //                    else
        //                        return TOKENTYPE.ERROR;
        //                case '&':
        //                    if (Line[i + 1] == '&')
        //                    {
        //                        i++;
        //                        return TOKENTYPE.LOGICOPERATION;
        //                    }
        //                    else
        //                        return TOKENTYPE.ERROR;
        //                case '\'' or '"':
        //                    return TOKENTYPE.QUOTAYIONMARK;
        //                case '{' or '}' or '[' or ']':
        //                    return TOKENTYPE.BRACES;
        //                case '_':
        //                    State = 8;
        //                    TokenValue += "_";

        //                    break;
        //                case '1':
        //                    break;
        //            }
        //        }
        //        TokenValue = "";
        //    }
        //    return TOKENTYPE.ERROR;
        //}

        //public char NextCharacter()
        //{
        //    return Line[i++];
        //}
        //TOKENTYPE CheckState1()
        //{
        //    char NextChar = ' ';
        //    switch (NextCharacter())
        //    {
        //        case 'I':
        //            State = 27;
        //            TokenValue += "I";
        //            if (NextCharacter() == 'o')
        //            {
        //                State = 44;
        //                TokenValue += "o";
        //                if (NextCharacter() == 'w')
        //                {
        //                    TokenValue += "w";
        //                    if (NextCharacter() == 'f')
        //                    {
        //                        TokenValue += "f";
        //                        NextChar = NextCharacter();
        //                        if (!(IsAlphabet(NextChar) || IsNumber(NextChar)))
        //                        {
        //                            i--;
        //                            State = 68; //Acceptance
        //                        }
        //                    }
        //                    else
        //                    {
        //                        i--;
        //                        NextChar = NextCharacter();
        //                        if (!(IsAlphabet(NextChar) || IsNumber(NextChar)))
        //                        {
        //                            i--;
        //                            State = 56; //Acceptance
        //                        }
        //                    }
        //                }
        //            }
        //            break;

        //        case 't':
        //            State = 28;
        //            TokenValue += "t";
        //            if (NextCharacter() == 'o')
        //            {
        //                State = 45;
        //                TokenValue += "o";
        //                if (NextCharacter() == 'p')
        //                { 
        //                    TokenValue += "p";
        //                    NextChar = NextCharacter();
        //                    if (!(IsAlphabet(NextChar) || IsNumber(NextChar)))
        //                    {
        //                        i--;
        //                        State = 57; //Acceptance
        //                    } 
        //                }
        //            }
        //            break;
        //    }

        //    if (State == 56)
        //        return TOKENTYPE.SINTEGER;
        //    else if (State == 68)
        //        return TOKENTYPE.SFLOAT;
        //    else if (State == 57)
        //        return TOKENTYPE.BREAK;

        //    i--;
        //    NextChar = NextCharacter();
        //    if (IsAlphabet(NextChar) || IsNumber(NextChar))
        //    {
        //        i--;
        //        return CheckIdentifier();
        //    }else
        //    {
        //        return TOKENTYPE.ERROR;
        //    }


        //}

        //TOKENTYPE CheckState2()
        //{
        //    char NextChar = ' ';
        //    if(NextCharacter() == 'h')
        //    {
        //        State = 29;
        //        TokenValue += 'h';
        //        switch (NextCharacter())
        //        {
        //            case 'a':
        //                State = 47;
        //                TokenValue += "a";
        //                if (NextCharacter() == 'i')
        //                {
        //                    State = 59;
        //                    TokenValue += "i";
        //                    if (NextCharacter() == 'n')
        //                    {
        //                        TokenValue += "n";
        //                        NextChar = NextCharacter();
        //                        if (!(IsAlphabet(NextChar) || IsNumber(NextChar)))
        //                        {
        //                            i--;
        //                            State = 69; //Acceptance
        //                        }
        //                    }

        //                }
        //                break;

        //            case 'l':
        //                State = 46;
        //                TokenValue += "l";
        //                if (NextCharacter() == 'o')
        //                {
        //                    TokenValue += "o";
        //                    NextChar = NextCharacter();
        //                    if (!(IsAlphabet(NextChar) || IsNumber(NextChar)))
        //                    {
        //                        i--;
        //                        State = 58; //Acceptance
        //                    }
        //                }
        //                break;
        //        }
        //    }

        //    if (State == 69)
        //        return TOKENTYPE.STRING;
        //    else if (State == 58)
        //        return TOKENTYPE.CHARACTER;

        //    i--;
        //    NextChar = NextCharacter();
        //    if (IsAlphabet(NextChar) || IsNumber(NextChar))
        //    {
        //        i--;
        //        return CheckIdentifier();
        //    }
        //    else
        //    {
        //        return TOKENTYPE.ERROR;
        //    }

        //}
        //TOKENTYPE CheckIdentifier()
        //{
        //    State = 8;
        //    while (State != -1)
        //    {
        //        char NextChar = NextCharacter();
        //        switch (State)
        //        {
        //            case 8:
        //                if (IsAlphabet(NextChar))
        //                {
        //                    State = 38;
        //                    TokenValue += NextChar;
        //                } else if(IsNumber(NextChar))
        //                {
        //                    i--;
        //                    if (IsAlphabet(NextCharacter()))
        //                        State = 39;
        //                }
        //                else
        //                {
        //                    State = -1;                        }
        //                break;
        //            case 38:
        //                if (IsAlphabet(NextChar))
        //                {
        //                    State = 38;
        //                    TokenValue += NextChar;
        //                }
        //                else if (IsNumber(NextChar))
        //                {
        //                    State = 39;
        //                    TokenValue += NextChar;
        //                }
        //                else
        //                    State = -1;
        //                break;
        //            case 39:
        //                if (IsAlphabet(NextChar))
        //                {
        //                    State = 38;
        //                    TokenValue += NextChar;
        //                }
        //                else if (IsNumber(NextChar))
        //                {
        //                    State = 39;
        //                    TokenValue += NextChar;
        //                }
        //                else
        //                    State = -1;
        //                break;

        //        }

        //    }

        //    i--;
        //    return TOKENTYPE.IDENTIFIER;

        //}



    }
}
