using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerS
{
    class Parser
    {
        List<Token> InputTokens;
        ParserStack<TerminalAndNonTerminal> stack;
        Token NextToken;
        ParserStack<GrammerSeq> GrammerStack;
        List<GrammerSeq> ParseResult = new List<GrammerSeq>();
        public Parser(List<Token> InputTokens)
        {
            this.InputTokens = InputTokens;
            stack = new ParserStack<TerminalAndNonTerminal>();
            GrammerStack = new ParserStack<GrammerSeq>();
            InputTokens.Add(new Token(-1, State.TOKENTYPE.NULL, "$")); ;
            stack.Push(new TerminalAndNonTerminal("$",true));
            stack.Push(new TerminalAndNonTerminal(ParserTable.NonTerminals.Program));
        }


        public List<GrammerSeq> Parse()
        {
            TerminalAndNonTerminal PopedItem = stack.Pop(); 
            while (PopedItem.ExpressionBody.ToString() != "$")
            {
                
                try 
                {
                    NextToken = GetNextToken();
                } 
                catch(Exception e)
                {
                    Error();
                    break;
                }
                if (PopedItem.IsTerminal)
                {
                    if(PopedItem.ExpressionBody.ToString() == NextToken.TokenValue ||
                        PopedItem.ExpressionBody.ToString() == NextToken.TokenType.ToString())
                    {
                        RemoveToken();
                        PopedItem = stack.Pop();
                        if(PopedItem.ExpressionBody.ToString() == "@")
                        {
                            ParseResult.Add(GrammerStack.Pop());
                            PopedItem = stack.Pop();
                            if (PopedItem.ExpressionBody.ToString() != GetNextToken().TokenValue)
                            {
                                stack.Push(new TerminalAndNonTerminal("$", true));
                                stack.Push(new TerminalAndNonTerminal(ParserTable.NonTerminals.Program));
                                PopedItem = stack.Pop();
                                continue;
                            }
                        }
                        
                        continue;
                    }
                    else
                    {
                        Error();
                    }
                }
                else
                {
                    GrammerStack.Push(new GrammerSeq(NextToken.LineNumber,(ParserTable.NonTerminals)PopedItem.ExpressionBody));
                    try
                    {
                        Expression TargetExpression = ParserTable.TransitionStates[(ParserTable.NonTerminals)PopedItem.ExpressionBody][NextToken.TokenValue];
                        ReplaceExpression(ref stack, TargetExpression);
                    } catch (NullReferenceException e)
                    {
                        Error();
                    }
                }
                PopedItem = stack.Pop();
            }
            return ParseResult;
        }
        public void ReplaceExpression(ref ParserStack<TerminalAndNonTerminal> stack,Expression TargetExpression)
        {
            for(int i = TargetExpression.ExepressionStatement.Count - 1; i >=0; i--)
            {
                stack.Push(TargetExpression.ExepressionStatement[i]);
            }
        }

        private void Error()
        {
            Console.WriteLine("Error");
        }
        public Token GetNextToken()
        {
            return InputTokens[0];
        }

        public void RemoveToken()
        {
            InputTokens.RemoveAt(0);
        }
    }


    
   

    
    
}
