

/*
 '0' --> Number
 '1' --> Letter
 */
using System;
using System.Collections.Generic;

namespace ScannerS
{
    public class TransitionTable
    {
        private static Dictionary<int,State> States = new Dictionary<int, State>()
        {
            {-2 , new State(-2,true,State.TOKENTYPE.DELIMITER)},
            { -1 , new State(-1)},
            { 0 , new State(0)},
            { 1 , new State(1)},
            { 2 , new State(2)},
            { 3 , new State(3)},
            { 4 , new State(4)},
            { 5 , new State(5)},
            { 6 , new State(6,true,State.TOKENTYPE.SFLOAT)},
            { 7 , new State(7,true,State.TOKENTYPE.SINTEGER)},
            { 8 , new State(8)},
            { 9 , new State(9)},
            { 10 , new State(10)},
            { 11 , new State(11,true,State.TOKENTYPE.BREAK)},
            { 12 , new State(12)},
            { 13 , new State(13)},
            { 14 , new State(14)},
            { 15 , new State(15)},
            { 16 , new State(16,true,State.TOKENTYPE.CHARACTER)},
            { 17 , new State(17)},
            { 18 , new State(18)},
            { 19 , new State(19)},
            { 20 , new State(20,true,State.TOKENTYPE.STRING)},
            { 21 , new State(21)},
            { 22 , new State(22)},
            { 23 , new State(23)},
            { 24 , new State(24)},
            { 25 , new State(25,true,State.TOKENTYPE.STRUCT)},
            { 26 , new State(26)},
            { 27 , new State(27)},
            { 28 , new State(28)},
            { 29 , new State(29)},
            { 30 , new State(30)},
            { 31 , new State(31)},
            { 32 , new State(32,true,State.TOKENTYPE.LOOP)},
            { 33 , new State(33)},
            { 34 , new State(34)},
            { 35 , new State(35,true,State.TOKENTYPE.CONDITION)},
            { 36 , new State(36)},
            { 37 , new State(37)},
            { 38 , new State(38)},
            { 39 , new State(39)},
            { 40 , new State(40)},
            { 41 , new State(41)},
            { 42 , new State(42)},
            { 43 , new State(43)},
            { 44 , new State(44)},
            { 45 , new State(45)},
            { 46 , new State(46)},
            { 47 , new State(47,true,State.TOKENTYPE.INCLUSION)},
            { 48 , new State(48)},
            { 49 , new State(49)},
            { 50 , new State(50)},
            { 51 , new State(51,true,State.TOKENTYPE.FLOAT)},
            { 52 , new State(52)},
            { 53 , new State(53)},
            { 54 , new State(54)},
            { 55 , new State(55)},
            { 56 , new State(56)},
            { 57 , new State(57)},
            { 58 , new State(58)},
            { 59 , new State(59)},
            { 60 , new State(60)},
            { 61 , new State(61,true,State.TOKENTYPE.VOID)},
            { 62 , new State(62)},
            { 63 , new State(63)},
            { 64 , new State(64)},
            { 65 , new State(65)},
            { 66 , new State(66)},
            { 67 , new State(67)},
            { 68 , new State(68)},
            { 69 , new State(69)},
            { 70 , new State(70,true,State.TOKENTYPE.RETURN)},
            { 71 , new State(71)},
            { 72 , new State(72)},
            { 73 , new State(73)},
            { 74 , new State(74)},
            { 75 , new State(75,true,State.TOKENTYPE.CONDITION)},
            { 76 , new State(76)},
            { 77 , new State(77)},
            { 78 , new State(78)},
            { 79 , new State(79,true,State.TOKENTYPE.IDENTIFIER)},
            { 80 , new State(80)},
            { 81 , new State(81,true,State.TOKENTYPE.CONSTANT)},
            { 82 , new State(82)},
            { 83 , new State(83,true,State.TOKENTYPE.RELATIONALOPERATION)},
            { 84 , new State(84)},
            { 85 , new State(85)},
            { 86 , new State(86,true,State.TOKENTYPE.RELATIONALOPERATION)},
            { 87 , new State(87)},
            { 88 , new State(88)},
            { 89 , new State(89,true,State.TOKENTYPE.RELATIONALOPERATION)},
            { 90 , new State(90)},
            { 91 , new State(91)},
            { 92 , new State(92)},
            { 93 , new State(93)},
            { 94 , new State(94,true,State.TOKENTYPE.RELATIONALOPERATION)},
            { 95 , new State(95)},
            { 96 , new State(96,true,State.TOKENTYPE.ARITHMETICOPERATION)},
            { 97 , new State(97)},
            { 98 , new State(98,true,State.TOKENTYPE.ARITHMETICOPERATION)},
            { 99 , new State(99)},
            { 100 , new State(100,true,State.TOKENTYPE.ACCESSOPERATION)},
            { 101 , new State(101)},
            { 102 , new State(102,true,State.TOKENTYPE.ARITHMETICOPERATION)},
            { 103 , new State(103)},
            { 104 , new State(104,true,State.TOKENTYPE.ARITHMETICOPERATION)},
            { 105 , new State(105)},
            { 106 , new State(106)},
            { 107 , new State(107,true,State.TOKENTYPE.COMMENT)},
            { 108 , new State(108)},
            { 109 , new State(109,true,State.TOKENTYPE.LOGICOPERATION)},
            { 110 , new State(110)},
            { 111 , new State(111)},
            { 112 , new State(112,true,State.TOKENTYPE.LOGICOPERATION)},
            { 113 , new State(113)},
            { 114 , new State(114)},
            { 115 , new State(115,true,State.TOKENTYPE.LOGICOPERATION)},
            { 116 , new State(116)},
            { 117 , new State(117,true,State.TOKENTYPE.QUOTAYIONMARK)},
            { 118 , new State(118)},
            { 119 , new State(119,true,State.TOKENTYPE.QUOTAYIONMARK)},
            { 120 , new State(120)},
            { 121 , new State(121,true,State.TOKENTYPE.BRACES)},
            { 122 , new State(122)},
            { 123 , new State(123,true,State.TOKENTYPE.BRACES)},
            { 124 , new State(124)},
            { 125 , new State(125,true,State.TOKENTYPE.BRACES)},
            { 126 , new State(126)},
            { 127 , new State(127,true,State.TOKENTYPE.BRACES)},
            { 128 , new State(128)},
            { 129 , new State(129,true,State.TOKENTYPE.COMMA)},
            { 130 , new State(130)},
            { 131 , new State(131)},
            { 132 , new State(132)},
            { 133 , new State(133,true,State.TOKENTYPE.COMMENT)},
            { 134 , new State(134)},
            { 135 , new State(135)},
            { 136 , new State(136,true,State.TOKENTYPE.BRACES)},
            { 137 , new State(137)},
            { 138 , new State(138,true,State.TOKENTYPE.BRACES)},
        };

        private static Dictionary<int, Dictionary<char, int>> TransitionStates =
            new Dictionary<int, Dictionary<char, int>>()
        {
            { 0 , new Dictionary<char, int>(){
                    { 'S', 1},
                    { 'C', 12},
                    { 'L', 21},
                    { 'I', 33},
                    { 'W', 52},
                    { 'T', 62},
                    { 'E', 71},
                    { '1', 76},
                    { '0', 80},
                    { '=', 82},
                    { '<', 85},
                    { '>', 88},
                    { '!', 91},
                    { '+', 95},
                    { '-', 97},
                    { '*', 101},
                    { '/', 103},
                    { '~', 108},
                    { '|', 110},
                    { '&', 113},
                    { '\'', 116},
                    { '"', 118},
                    { '{', 120},
                    { '}', 122},
                    { '[', 124},
                    { ']', 126},                
                    { ',', 128},
                    { '$', 130},    
                    { '(', 135},    
                    { ')', 137},    
                } 
            },
            { 1 , new Dictionary<char, int>(){
                    { 'I', 2},
                    { 't', 8},
                }
            },
            { 2 , new Dictionary<char, int>(){
                        { 'o', 3},                        
                    }
            },
            { 3 , new Dictionary<char, int>(){
                        { 'w', 4},
                    }
            },
            { 4 , new Dictionary<char, int>(){
                        { 'f', 5},
                        { '@', 7},
                    }
            },
            { 5 , new Dictionary<char, int>(){
                        { '@', 6},
                    }
            },
            { 8 , new Dictionary<char, int>(){
                        { 'o', 9},
                    }
            },
            { 9 , new Dictionary<char, int>(){
                        { 'p', 10},
                    }
            },
            { 10 , new Dictionary<char, int>(){
                        { '@', 11},
                    }
            },
            { 12 , new Dictionary<char, int>(){
                        { 'h', 13},
                    }
            },
            { 13 , new Dictionary<char, int>(){
                        { 'l', 14},
                        { 'a', 17},
                    }
            },
            { 14 , new Dictionary<char, int>(){
                        { 'o', 15},
                    }
            },
            { 15 , new Dictionary<char, int>(){
                        { '@', 16},
                    }
            },
            { 17 , new Dictionary<char, int>(){
                        { 'i', 18},
                    }
            },
            { 18 , new Dictionary<char, int>(){
                        { 'n', 19},
                    }
            },
            { 19 , new Dictionary<char, int>(){
                        { '@', 20},
                    }
            },
            { 21 , new Dictionary<char, int>(){
                        { 'o', 22},
                    }
            },
            { 22 , new Dictionary<char, int>(){
                        { 'l', 23},
                        { 'o', 26},
                    }
            },
            { 23 , new Dictionary<char, int>(){
                        { 'i', 24},
                    }
            },
            { 24 , new Dictionary<char, int>(){
                        { '@', 25},
                    }
            },
            { 26 , new Dictionary<char, int>(){
                        { 'p', 27},
                    }
            },
            { 27 , new Dictionary<char, int>(){
                        { 'w', 28},
                    }
            },
            { 28 , new Dictionary<char, int>(){
                        { 'h', 29},
                    }
            },
            { 29 , new Dictionary<char, int>(){
                        { 'e', 30},
                    }
            },
            { 30 , new Dictionary<char, int>(){
                        { 'n', 31},
                    }
            },
            { 31 , new Dictionary<char, int>(){
                        { '@', 32},
                    }
            },
            { 33 , new Dictionary<char, int>(){
                        { 'f', 34},
                        { 't', 36},
                        { 'n', 41},
                        { 'o', 48},
                    }
            },
            { 34 , new Dictionary<char, int>(){
                        { '@', 35},
                    }
            },
            { 36 , new Dictionary<char, int>(){
                        { 'e', 37},
                        { 'r', 38},
                        { 'a', 39},
                        { 't', 40},
                    }
            },
            { 40 , new Dictionary<char, int>(){
                        { 'e', 27},
                    }
            },
            { 41 , new Dictionary<char, int>(){
                        { 'c', 42},
                        { 'l', 43},
                    }
            },
            { 43 , new Dictionary<char, int>(){
                        { 'u', 44},
                    }
            },
            { 44 , new Dictionary<char, int>(){
                        { 'd', 45},
                    }
            },
            { 45 , new Dictionary<char, int>(){
                        { 'e', 46},
                    }
            },
            { 46 , new Dictionary<char, int>(){
                        { '@', 47},
                    }
            },
            { 48 , new Dictionary<char, int>(){
                        { 'w', 49},
                        { 'f', 50},
                    }
            },
            { 50 , new Dictionary<char, int>(){
                        { '@', 51},
                    }
            },
            { 52 , new Dictionary<char, int>(){
                        { 'o', 53},
                    }
            },
            { 53 , new Dictionary<char, int>(){
                        { 'r', 54},
                    }
            },
            { 54 , new Dictionary<char, int>(){
                        { 't', 55},
                    }
            },
            { 55 , new Dictionary<char, int>(){
                        { 'h', 56},
                    }
            },
            { 56 , new Dictionary<char, int>(){
                        { 'l', 57},
                    }
            },
            { 57 , new Dictionary<char, int>(){
                        { 'e', 58},
                    }
            },
            { 58 , new Dictionary<char, int>(){
                        { 's', 59},
                    }
            },
            { 59 , new Dictionary<char, int>(){
                        { 's', 60},
                    }
            },
            { 60 , new Dictionary<char, int>(){
                        { '@', 61},
                    }
            },
            { 62 , new Dictionary<char, int>(){
                        { 'u', 63},
                    }
            },
            { 63 , new Dictionary<char, int>(){
                        { 'r', 64},
                    }
            },
            { 64 , new Dictionary<char, int>(){
                        { 'n', 65},
                    }
            },
            { 65 , new Dictionary<char, int>(){
                        { 'b', 66},
                    }
            },
            { 66 , new Dictionary<char, int>(){
                        { 'a', 67},
                    }
            },
            { 67 , new Dictionary<char, int>(){
                        { 'c', 68},
                    }
            },
            { 68 , new Dictionary<char, int>(){
                        { 'k', 69},
                    }
            },
            { 69 , new Dictionary<char, int>(){
                        { '@', 70},
                    }
            },
            { 71 , new Dictionary<char, int>(){
                        { 'l', 72},
                    }
            },
            { 72 , new Dictionary<char, int>(){
                        { 's', 73},
                    }
            },
            { 73 , new Dictionary<char, int>(){
                        { 'e', 74},
                    }
            },
            { 74 , new Dictionary<char, int>(){
                        { '@', 75},
                    }
            },
            { 76 , new Dictionary<char, int>(){
                        { '1', 77},
                        { '0', 78},
                        { '@', 79},
                    }
            },
            { 77 , new Dictionary<char, int>(){
                        { '1', 77},
                        { '0', 78},
                        { '@', 79},
                    }
            },
            { 78 , new Dictionary<char, int>(){
                        { '1', 77},
                        { '0', 78},
                        { '@', 79},
                    }
            },
            { 80 , new Dictionary<char, int>(){
                        { '0', 80},
                        { '@', 81},
                    }
            },
            { 82 , new Dictionary<char, int>(){
                        { '@', 83},
                        { '=', 84},
                    }
            },
            { 84 , new Dictionary<char, int>(){
                        { '@', 94},
                    }
            },
            { 85 , new Dictionary<char, int>(){
                        { '@', 86},
                        { '=', 87},
                    }
            },
            { 87 , new Dictionary<char, int>(){
                        { '@', 94},
                    }
            },
            { 88 , new Dictionary<char, int>(){
                        { '@', 89},
                        { '=', 90},
                    }
            },
            { 90 , new Dictionary<char, int>(){
                        { '@', 94},
                    }
            },
            { 91 , new Dictionary<char, int>(){
                        { '=', 93},
                    }
            },
            { 93 , new Dictionary<char, int>(){
                        { '@', 94},
                    }
            },
            { 95 , new Dictionary<char, int>(){
                        { '@', 96},
                    }
            },
            { 97 , new Dictionary<char, int>(){
                        { '@', 98},
                        { '>', 99},
                    }
            },
            { 99 , new Dictionary<char, int>(){
                        { '@', 100},
                    }
            },
            { 101 , new Dictionary<char, int>(){
                        { '@', 102},
                    }
            },
            { 103 , new Dictionary<char, int>(){
                        { '@', 104},
                        { '$', 105},
                    }
            },
            { 105 , new Dictionary<char, int>(){
                        { '@', 107},
                    }
            },
            { 108 , new Dictionary<char, int>(){
                        { '@', 109},
                    }
            },
            { 110 , new Dictionary<char, int>(){
                        { '|', 111},
                    }
            },
            { 111 , new Dictionary<char, int>(){
                        { '@', 112},
                    }
            },
            { 113 , new Dictionary<char, int>(){
                        { '&', 114},
                    }
            },
            { 114 , new Dictionary<char, int>(){
                        { '@', 115},
                    }
            },
            { 116 , new Dictionary<char, int>(){
                        { '@', 117},
                    }
            },
            { 118 , new Dictionary<char, int>(){
                        { '@', 119},
                    }
            },
            { 120 , new Dictionary<char, int>(){
                        { '@', 121},
                    }
            },
            { 122 , new Dictionary<char, int>(){
                        { '@', 123},
                    }
            },
            { 124 , new Dictionary<char, int>(){
                        { '@', 125},
                    }
            },
            { 126 , new Dictionary<char, int>(){
                        { '@', 127},
                    }
            },
            { 128 , new Dictionary<char, int>(){
                        { '@', 129},
                    }
            },
            { 130 , new Dictionary<char, int>(){
                        { '$', 131},
                        { '/', 134},
                    }
            },
            { 131 , new Dictionary<char, int>(){
                        { '$', 132},
                    }
            },
            { 132 , new Dictionary<char, int>(){
                        { '@', 133},
                    }
            },
            { 134 , new Dictionary<char, int>(){
                        { '@', 133},
                    }
            },
            { 135 , new Dictionary<char, int>(){
                        { '@', 136},
                    }
            },
            { 137 , new Dictionary<char, int>(){
                        { '@', 138},
                    }
            },
        };

        public static State GetNextState(State CurrentState,char NextInput)
        {
            try
            {
                NextInput = GetDelimiterSymbol(NextInput);  
                if(NextInput == '1')
                {
                    NextInput = '0';
                }
                
                int NextState = TransitionStates[CurrentState.StateNumber][NextInput];
                return States[NextState];
            } catch (Exception e)
            {
                NextInput = IsNumber(NextInput);
                NextInput = IsAlphabet(NextInput);
                if (CurrentState.StateNumber == 0)
                { 
                    if(NextInput == '@')
                    {
                        return States[-2];
                    }
                    else
                    {
                        int NextState = TransitionStates[CurrentState.StateNumber][NextInput];
                        return States[NextState];
                    }

                }           
                char PreChar = Scanner.Code[Scanner.i - 2];
                //Letter
                if(NextInput == '1')
                {
                    if(IsAlphabet(PreChar) == '1')
                    {
                        return States[78];
                    } else if(IsOtherDelimiter(PreChar))
                    {
                        NextInput = '@';
                        Scanner.i--;
                        try
                        {
                            int NextState = TransitionStates[CurrentState.StateNumber][NextInput];
                            return States[NextState];
                        } catch(Exception e2)
                        {
                            return States[-1];
                        }
                    } else
                    {
                        return States[-1];
                    }

                } 
                else if(NextInput == '0') //Digit
                {
                    if (IsAlphabet(PreChar) == '1')
                    {
                        return States[77];
                    }
                    else if (IsOtherDelimiter(PreChar))
                    {
                        NextInput = '@';
                        Scanner.i--;
                        try
                        {
                            int NextState = TransitionStates[CurrentState.StateNumber][NextInput];
                            return States[NextState];
                        }
                        catch (Exception e2)
                        {
                            return States[-1];
                        }
                    }
                    else if(IsNumber(PreChar) == '0')
                    {
                        return States[80];
                    }
                } 
                else if (IsOtherDelimiter(NextInput))
                {
                    if (IsAlphabet(PreChar) == '1')
                    {
                        NextInput = '@';
                        Scanner.i--;
                        try
                        {
                            int NextState = TransitionStates[CurrentState.StateNumber][NextInput];
                            return States[NextState];
                        }
                        catch (Exception e2)
                        {
                            return States[79];
                        }
                    }
                    else if (IsOtherDelimiter(PreChar))
                    {
                        NextInput = '@';
                        Scanner.i--;
                        try
                        {
                            int NextState = TransitionStates[CurrentState.StateNumber][NextInput];
                            return States[NextState];
                        }
                        catch (Exception e2)
                        {
                            return States[-1];
                        }
                    }
                    else
                    {
                        NextInput = '@';
                        Scanner.i--;
                        try
                        {
                            int NextState = TransitionStates[CurrentState.StateNumber][NextInput];
                            return States[NextState];
                        }
                        catch (Exception e2)
                        {
                            return States[-1];
                        }
                    }
                } else if(NextInput == '@')
                {
                    if (IsAlphabet(PreChar) == '1')
                    {
                        Scanner.i--;
                        return States[79];
                    }
                    else if (IsOtherDelimiter(PreChar))
                    {
                        Scanner.i--;
                        try
                        {
                            int NextState = TransitionStates[CurrentState.StateNumber][NextInput];
                            return States[NextState];
                        }
                        catch (Exception e2)
                        {
                            return States[-1];
                        }
                    }
                    else
                    {
                        Scanner.i--;
                        try
                        {
                            int NextState = TransitionStates[CurrentState.StateNumber][NextInput];
                            return States[NextState];
                        }
                        catch (Exception e2)
                        {
                            return States[-1];
                        }
                    }
                }
                return States[-1];
                //if (CurrentState.StateNumber != 0 &&
                //    IsOtherDelimiter(NextInput)
                //    )
                //{
                //    var p = Scanner.Code[Scanner.i - 2];
                //    var n = Scanner.Code[Scanner.i + 1];
                //    if (IsAlphabet(p) == '1' || IsAlphabet(n) == '1')
                //    {
                //        NextInput = '@';

                //    }

                //}
                //else if (CurrentState.StateNumber != 0)
                //{
                //    if (IsAlphabet(NextInput) == '1')
                //    {
                //        var x = Scanner.Code[Scanner.i - 2];
                //        if (IsOtherDelimiter(x))
                //        {
                //            NextInput = '@';
                //        }
                //    }
                //}
                //NextInput = IsAlphabet(NextInput);
                //NextInput = IsNumber(NextInput);
                //if (!IsOtherDelimiter(Scanner.Code[Scanner.i - 1]))
                //{
                //    if (NextInput == '1')
                //    {
                //        return States[78];
                //    }
                //    else if (NextInput == '0')
                //    {
                //        return States[77];
                //    } else if(IsAlphabet(Scanner.Code[Scanner.i - 2]) == '1')
                //    {
                //        Scanner.i--;
                //        return States[78];
                //    }
                //    else if (IsNumber(Scanner.Code[Scanner.i - 2]) == '0')
                //    {
                //        Scanner.i--;
                //        return States[77];
                //    }
                //} else
                //{
                //    State LastState = Scanner.State;
                    
                //}
                //Scanner.i--;
                //int NextState = TransitionStates[CurrentState.StateNumber][NextInput];
                //return States[NextState];
            }
        }

        public static char GetDelimiterSymbol(char delimiter)
        {
            if(IsDelimiter(delimiter))
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
                (int)delimiter == 9||
                delimiter == '\0')
            {
                return true;
            }
            return false;
        }
        public static bool IsOtherDelimiter(char delimiter)
        {
            if (delimiter == '+'|| delimiter == '-' ||
                delimiter == '*' || delimiter == '/'|| 
                delimiter == '{' || delimiter == '}' ||
                delimiter == '[' || delimiter == ']'||
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

    


}
}
