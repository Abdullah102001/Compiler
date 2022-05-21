using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class ParserTable
    {
        public enum NonTerminals
        {
            Program,
            Declaration_list,
            Declaration_list_cot,
            Declaration,
            Declaration_cont,
            Type_specifier,
            Params,
            Params_list,
            Param_list_cont,
            Param,
            Compound_stmt,
            Compound_stmt_cont,
            Local_declaration,
            Local_declaration_cont,
            Statement_list,
            Statement_list_cont,
            Statement,
            Expression_stmt,
            Selection_stmt,
            Selection_stmt_cont,
            Iteration_stmt,
            Loop_statement,
            Iterate_statement,
            Jump_stmt,
            Expression,
            Expression_cont,
            Id_assign,
            Id_call,
            Simple_expression,
            Simple_expression_cont,
            Relop,
            Additive_expression,
            Additive_expression_cont,
            Addop,
            Term,
            Term_cont,
            Mulop,
            Factor,
            Args,
            Arg_list,
            Arg_list_cont,
            Num,
            Unsigned_num,
            Signed_num,
            Pos_num,
            Neg_num,
            Value,
            Comment,
            Include_command,
            F_name,
            Erorr,
        }


        public static Dictionary<NonTerminals, Dictionary<string, Expression>> TransitionExprission =
            new Dictionary<NonTerminals, Dictionary<string, Expression>>()
            {
                {
                    NonTerminals.Program , new Dictionary<string, Expression>(){
                        {"$$$" , new Expression(new List<TerminalAndNonTerminal>()
                                    {
                                        new TerminalAndNonTerminal(NonTerminals.Comment),
                                    })
                        },
                        {"/$" , new Expression(new List<TerminalAndNonTerminal>()
                                    {
                                        new TerminalAndNonTerminal(NonTerminals.Comment),
                                    })
                        },
                    }
                },
                {
                    NonTerminals.Comment , new Dictionary<string, Expression>(){
                        {"$$$" , new Expression(new List<TerminalAndNonTerminal>()
                                    {
                                        new TerminalAndNonTerminal("$$$",true),
                                        new TerminalAndNonTerminal(State.TOKENTYPE.STR,true),
                                        new TerminalAndNonTerminal("@"),
                                    })
                        },
                        {"/$" , new Expression(new List<TerminalAndNonTerminal>()
                                    {
                                        new TerminalAndNonTerminal("/$",true),
                                        new TerminalAndNonTerminal(State.TOKENTYPE.STR,true),
                                        new TerminalAndNonTerminal("$/",true),
                                        new TerminalAndNonTerminal("@"),
                                    })
                        }
                    }
                }
            };

    }
}
