using System.Collections;
using System.Collections.Generic;
using Bowling.Models;

namespace Bowling.Tests.TestData.Frames
{
    public class AverageFrames : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[]
            {
                new List<Frame>
                {
                    new Frame{ Number = 1, Rolls = new List<Roll>{ new Roll{Try = 1, Value = 2}, new Roll{Try = 2, Value = 3} }},
                    new Frame{ Number = 2, Rolls = new List<Roll>{ new Roll{Try = 1, Value = 5}, new Roll{Try = 2, Value = 4} }},
                    new Frame{ Number = 3, Rolls = new List<Roll>{ new Roll{Try = 1, Value = 9}, new Roll{Try = 2, Value = 1, IsSpare = true} }},
                    new Frame{ Number = 4, Rolls = new List<Roll>{ new Roll{Try = 1, Value = 2}, new Roll{Try = 2, Value = 5} }},
                    new Frame{ Number = 5, Rolls = new List<Roll>{ new Roll{Try = 1, Value = 3}, new Roll{Try = 2, Value = 2} }},
                    new Frame{ Number = 6, Rolls = new List<Roll>{ new Roll{Try = 1, Value = 4}, new Roll{Try = 2, Value = 2} }},
                    new Frame{ Number = 7, Rolls = new List<Roll>{ new Roll{Try = 1, Value = 3}, new Roll{Try = 2, Value = 3} }},
                    new Frame{ Number = 8, Rolls = new List<Roll>{ new Roll{Try = 1, Value = 4}, new Roll{Try = 2, Value = 6, IsSpare = true} }},
                    new Frame{ Number = 9, Rolls = new List<Roll>{ new Roll{Try = 1, Value = 10, IsStrike = true}}},
                    new Frame{ Number = 10, Rolls = new List<Roll>{ new Roll{Try = 1, Value = 3}, new Roll{Try = 2, Value = 2}}, IsFinalFrame = true }
                }, 90}
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}