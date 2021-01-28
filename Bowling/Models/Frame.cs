using System.Collections.Generic;

namespace Bowling.Models
{
    public class Frame
    {
        public int Number { get; set; }
        public bool IsFinalFrame { get; set; }
        public List<Roll> Rolls { get; set; }
    }
}