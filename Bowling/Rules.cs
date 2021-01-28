namespace Bowling
{
    public static class Rules
    {
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
    }
}
