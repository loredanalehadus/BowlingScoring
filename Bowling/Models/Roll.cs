namespace Bowling.Models
{
    public class Roll
    {
        public int Try { get; set; }
        public int Value { get; set; }
        public bool IsSpare { get; set; }
        public bool IsStrike { get; set; }
    }
}