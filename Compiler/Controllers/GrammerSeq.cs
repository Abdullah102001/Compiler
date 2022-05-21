using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiler
{
    public class GrammerSeq
    {
        public int LineNumber;
        public ParserTable.NonTerminals NonTerminal;

        public GrammerSeq(int LineNumber, ParserTable.NonTerminals NonTerminal)
        {
            this.LineNumber = LineNumber;
            this.NonTerminal = NonTerminal;
        }
    }
}
