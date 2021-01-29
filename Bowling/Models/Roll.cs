namespace Bowling.Models
{
    public class Roll
    {
        public int Number { get; set; }
        public int Value { get; set; }
        public bool IsSpare { get; set; }
        public bool IsStrike { get; set; }
    }
}