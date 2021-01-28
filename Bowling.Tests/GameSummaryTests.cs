using System.Collections.Generic;
using System.Text;
using Bowling.Models;
using Bowling.Services;
using FluentAssertions;
using Xunit;

namespace Bowling.Tests
{
    public class GameSummaryTests
    {
        private readonly GameSummary sut;

        public GameSummaryTests()
        {
            sut = new GameSummary();
        }

        [Fact]
        public void Print_ShouldOutputGameResults()
        {
            var result = sut.Print(Frames);
            var expectedResult = new StringBuilder()
                .AppendLine("| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |")
                .Append("|-, 3|5, -|9, /|2, 5|3, 2|4, 2|3, 3|4, /|X   |X, 2, 5|")
                .ToString();

            result.Should().Be(expectedResult);
        }

        private readonly List<Frame> Frames = new List<Frame>
        {
            new Frame{ Number = 1, Rolls = new List<Roll>{new Roll{Try = 1, Value = 0}, new Roll{Try = 2, Value = 3} }},
            new Frame{ Number = 2, Rolls = new List<Roll>{new Roll{Try = 1, Value = 5}, new Roll{Try = 2, Value = 0} }},
            new Frame{ Number = 3, Rolls = new List<Roll>{new Roll{Try = 1, Value = 9}, new Roll{Try = 2, Value = 1, IsSpare = true} }},
            new Frame{ Number = 4, Rolls = new List<Roll>{new Roll{Try = 1, Value = 2}, new Roll{Try = 2, Value = 5} }},
            new Frame{ Number = 5, Rolls = new List<Roll>{new Roll{Try = 1, Value = 3}, new Roll{Try = 2, Value = 2} }},
            new Frame{ Number = 6, Rolls = new List<Roll>{new Roll{Try = 1, Value = 4}, new Roll{Try = 2, Value = 2} }},
            new Frame{ Number = 7, Rolls = new List<Roll>{new Roll{Try = 1, Value = 3}, new Roll{Try = 2, Value = 3} }},
            new Frame{ Number = 8, Rolls = new List<Roll>{new Roll{Try = 1, Value = 4}, new Roll{Try = 2, Value = 6, IsSpare = true} }},
            new Frame{ Number = 9, Rolls = new List<Roll>{new Roll{Try = 1, Value = 10, IsStrike = true}}},
            new Frame{ Number = 10, Rolls = new List<Roll>{new Roll{Try = 1, Value = 10, IsStrike = true}, new Roll{Try = 2, Value = 2}, new Roll{Try = 3, Value = 5} }, IsFinalFrame = true }
        };
    }
}