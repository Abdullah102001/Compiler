
namespace ScannerS
{
    public class Token
    {
        public int LineNumber;
        public State.TOKENTYPE TokenType;
        public string TokenValue;

        public Token(int LineNumber, State.TOKENTYPE TokenType, string TokenValue)
        {
            this.LineNumber = LineNumber;
            this.TokenType = TokenType;
            this.TokenValue = TokenValue;
        }

        public string PrintToken()
        {
            return "Line : " + LineNumber + " Token Text : " + TokenValue + " Token Type : " + TokenType;
        }
    }

}
