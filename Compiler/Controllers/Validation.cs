namespace Compiler
{
    public class Validation
    {
        public static char GetDelimiterSymbol(char delimiter)
        {
            if (IsDelimiter(delimiter))
            {
                return '@';
            }
            return delimiter;
        }
        public static char IsAlphabet(char character)
        {
            int ASSCIICode = (int)character;
            if ((ASSCIICode >= 65 && ASSCIICode <= 90) ||
                (ASSCIICode >= 97 && ASSCIICode <= 122) ||
                ASSCIICode == 95)
                return '1';
            else
                return character;
        }
        public static char IsNumber(char character)
        {
            int ASSCIICode = (int)character;
            if (ASSCIICode >= 48 && ASSCIICode <= 57)
                return '0';
            else
                return character;
        }
        public static bool IsDelimiter(char delimiter)
        {
            if (delimiter == ' ' ||
                delimiter == ';' ||
                delimiter == '\n' ||
                delimiter == '\r' ||
                (int)delimiter == 9 ||
                delimiter == '\0')
            {
                return true;
            }
            return false;
        }
        public static bool IsOtherDelimiter(char delimiter)
        {
            if (delimiter == '+' || delimiter == '-' ||
                delimiter == '*' || delimiter == '/' ||
                delimiter == '{' || delimiter == '}' ||
                delimiter == '[' || delimiter == ']' ||
                delimiter == '(' || delimiter == ')' ||
                delimiter == '/' || delimiter == '&' ||
                delimiter == '|' || delimiter == '<' ||
                delimiter == '>' || delimiter == '!' ||
                delimiter == '~' || delimiter == '"' ||
                delimiter == '\'' || delimiter == '=' ||
                delimiter == ',' || delimiter == '$')
                return true;
            return false;
        }
        public static char SetDigitSymbol(char character)
        {
            if (character == '1')
            {
                character = '0';
            }
            return character;
        }
    }
}
