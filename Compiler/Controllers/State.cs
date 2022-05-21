using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerS
{
    public class State
    {
        public enum TOKENTYPE
        {
            NULL,
            CONDITION,
            INTEGER,
            SINTEGER,
            CHARACTER,
            STRING,
            FLOAT,
            SFLOAT,
            VOID,
            LOOP,
            RETURN,
            BREAK,
            STRUCT,
            ARITHMETICOPERATION,
            LOGICOPERATION,
            RELATIONALOPERATION,
            ASSIGNMENTOPERATION,
            ACCESSOPERATION,
            BRACES,
            CONSTANT,
            QUOTAYIONMARK,
            INCLUSION,
            IDENTIFIER,
            COMMENT,
            ERROR,
            DELIMITER,
            COMMA,
            STR,
        }

        public int StateNumber;
        public bool IsAcceptance;
        public TOKENTYPE TokenType;

        public State(int StateNumber,bool IsAcceptance = false,TOKENTYPE TokenType = TOKENTYPE.NULL)
        {
            this.StateNumber = StateNumber;
            this.IsAcceptance = IsAcceptance;
            this.TokenType = TokenType;
        }

    }
}
