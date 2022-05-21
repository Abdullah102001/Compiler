using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class TerminalAndNonTerminal
    {


        public dynamic ExpressionBody;
        public bool IsTerminal;

        public TerminalAndNonTerminal(dynamic ExpressionBody, bool IsTerminal = false)
        {
            this.ExpressionBody = ExpressionBody;
            this.IsTerminal = IsTerminal;
        }
    }
}
