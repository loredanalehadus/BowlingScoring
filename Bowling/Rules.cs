using System.Linq;
using Bowling.Models;

namespace Bowling
{
    public static class Rules
    {
        public const string FrameDelimiter = "|";
        public const string FrameHeader = "| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |";

        public static bool IsStrike(int roll)
        {
            return roll == 10;
        }

        public static bool IsSpare(int firstRoll, int secondRoll)
        {
            if (firstRoll == 10) return false;

            return firstRoll + secondRoll == 10;
        }

        public static bool IsLastFrame(int frameNumber)
        {
            return frameNumber == 10;
        }

        public static bool IsBonusRoll(int firstRoll, int secondRoll)
        {
            return IsStrike(firstRoll) || IsSpare(firstRoll, secondRoll);
        }

        public static string GetSymbol(int value, bool isSpare)
        {
            var symbol = value switch
            {
                0 => "-",
                10 => "X",
                _ => value.ToString()
            };

            return isSpare ? "/" : symbol;
        }

        //todo: decide if this is the correct place to put it
        public static string GetSpacing(Roll roll, Frame frame)
        {
            if (frame.IsFinalFrame && frame.Rolls.Count() == 2 && roll.Try == 2 ||
                !frame.IsFinalFrame && roll.IsStrike)
            {
                return "   ";
            }

            if (frame.IsFinalFrame && roll.Try == 3 ||
                !frame.IsFinalFrame && roll.Try == 2)
            {
                return "";
            }

            return ", ";
        }
    }
}
