using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerS
{
    public class Expression
    {
        public List<TerminalAndNonTerminal> ExepressionStatement;
        public Expression(List<TerminalAndNonTerminal> ExepressionStatement)
        {
            this.ExepressionStatement = ExepressionStatement;
        }
    }
}
