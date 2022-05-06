
namespace ScannerS
{
    internal class Token
    {
        int LineNumber;
        State.TOKENTYPE TokenType;
        string TokenValue;

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
