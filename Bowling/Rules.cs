using System.Linq;
using Bowling.Models;

namespace Bowling
{
    public static class Rules
    {
        public const int StrikeScore = 10;
        public const string FrameDelimiter = "|";
        public const string FrameHeader = "| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |";

        public static bool IsStrike(int roll) => roll == 10;
        public static bool IsSpare(int firstRoll, int secondRoll) => firstRoll != 10 && firstRoll + secondRoll == 10;
        public static bool IsBonusRoll(int firstRoll, int secondRoll, int frameNumber) => IsLastFrame(frameNumber) && (IsStrike(firstRoll) || IsSpare(firstRoll, secondRoll));
        public static bool IsLastFrame(int frameNumber) => frameNumber == 10;

        public static bool FrameHasSpare(Frame frame) => frame.Rolls.Any(r => r.IsSpare);
        public static bool FrameHasStrike(Frame frame) => frame.Rolls.Any(r => r.IsStrike);
        

        //todo:pass Roll
        public static string GetRollSymbol(int value, bool isSpare)
        {
            var symbol = value switch
            {
                0 => "-",
                10 => "X",
                _ => value.ToString()
            };

            return isSpare ? "/" : symbol;
        }

        //todo: decide if this is the correct place to put it; 
        //move back to print
        public static string GetSpacing(Roll roll, Frame frame)
        {
            if (frame.IsFinalFrame && frame.Rolls.Count() == 2 && roll.Number == 2 ||
                !frame.IsFinalFrame && roll.IsStrike)
            {
                return "   ";
            }

            if (frame.IsFinalFrame && roll.Number == 3 ||
                !frame.IsFinalFrame && roll.Number == 2)
            {
                return "";
            }

            return ", ";
        }
    }
}
