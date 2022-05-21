using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    class Parser
    {
        List<Token> InputTokens;
        ParserStack<TerminalAndNonTerminal> ParseStack;
        
        ParserStack<GrammerSeq> GrammerStack;
        List<GrammerSeq> ParseResult = new List<GrammerSeq>();
        public Parser(List<Token> InputTokens)
        {
            this.InputTokens = PrepareInputTokens(InputTokens);
            PrepareParseStack();
            PrepareGrammerStack();
        }

        public List<GrammerSeq> Parse()
        {
            TerminalAndNonTerminal PopedItem = ParseStack.Pop();
            Token NextToken;
            while (PopedItem.ExpressionBody.ToString() != "$")
            {  
                try 
                {
                    NextToken = GetNextToken();
                } 
                catch(Exception e)
                {
                    break;
                }
                if (PopedItem.IsTerminal)
                {
                    if(PopedItem.ExpressionBody.ToString() == NextToken.TokenValue ||
                        PopedItem.ExpressionBody.ToString() == NextToken.TokenType.ToString())
                    {
                        RemoveToken();
                        PopedItem = ParseStack.Pop();
                        if(PopedItem.ExpressionBody.ToString() == "@")
                        {
                            ParseResult.Add(GrammerStack.Pop());
                            PopedItem = ParseStack.Pop();
                            if (PopedItem.ExpressionBody.ToString() != GetNextToken().TokenValue)
                            {
                                ParseStack.Push(new TerminalAndNonTerminal("$", true));
                                ParseStack.Push(new TerminalAndNonTerminal(ParserTable.NonTerminals.Program));
                                PopedItem = ParseStack.Pop();
                                continue;
                            }
                        }
                        
                        continue;
                    }
                    else
                    {
                        Error(NextToken);
                    }
                }
                else
                {
                    GrammerStack.Push(new GrammerSeq(NextToken.LineNumber,(ParserTable.NonTerminals)PopedItem.ExpressionBody));
                    try
                    {
                        Expression TargetExpression = ParserTable.TransitionExprission[(ParserTable.NonTerminals)PopedItem.ExpressionBody][NextToken.TokenValue];
                        ReplaceExpression(ParseStack, TargetExpression);
                    } catch (Exception e)
                    {
                        Error(NextToken);
                    }
                }
                PopedItem = ParseStack.Pop();
            }
            return ParseResult;
        }
        private void ReplaceExpression(ParserStack<TerminalAndNonTerminal> ParseStack,Expression TargetExpression)
        {
            for(int i = TargetExpression.ExepressionStatement.Count - 1; i >=0; i--)
            {
                ParseStack.Push(TargetExpression.ExepressionStatement[i]);
            }
        }

        private void Error(Token NextToken)
        {
            ParseResult.Add(new GrammerSeq(NextToken.LineNumber,
                ParserTable.NonTerminals.Erorr));
        }
        private Token GetNextToken()
        {
            return InputTokens[0];
        }

        private void RemoveToken()
        {
            InputTokens.RemoveAt(0);
        }


        private void PrepareParseStack()
        {
            ParseStack = new ParserStack<TerminalAndNonTerminal>();
            ParseStack.Push(new TerminalAndNonTerminal("$", true));
            ParseStack.Push(new TerminalAndNonTerminal(ParserTable.NonTerminals.Program));
        }
        private void PrepareGrammerStack()
        {
            GrammerStack = new ParserStack<GrammerSeq>();
        }

        private List<Token> PrepareInputTokens(List<Token> InputTokens)
        {
            InputTokens.Add(new Token(-1, State.TOKENTYPE.NULL, "$"));
            return InputTokens;
        }

    }







}
