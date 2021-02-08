using System.Linq;
using Bowling.Models;

namespace Bowling
{
    public static class Rules
    {
        public const int StrikeScore = 10;
        public const int SpareScore = 10;
        public const int GutterScore = 0;
        public const int MaxFrameNumber = 10;
        public const string FrameDelimiter = "|";
        public const string FrameHeader = "| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |";

        public static bool IsStrike(int roll) => roll == StrikeScore;

        public static bool IsSpare(int firstRoll, int secondRoll) => !IsStrike(firstRoll) && firstRoll + secondRoll == SpareScore;

        public static bool IsBonusRoll(int firstRoll, int secondRoll, int frameNumber) => IsLastFrame(frameNumber) && 
                                                                                          (IsStrike(firstRoll) || IsSpare(firstRoll, secondRoll));
        public static bool IsLastFrame(int frameNumber) => frameNumber == MaxFrameNumber;

        public static bool FrameHasSpare(Frame frame) => frame.Rolls.Any(r => r.IsSpare);

        public static bool FrameHasStrike(Frame frame) => frame.Rolls.Any(r => r.IsStrike);
    }
}
