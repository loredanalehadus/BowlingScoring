using System.Collections;
using System.Collections.Generic;
using Bowling.Services;
using FluentAssertions;
using Xunit;

namespace Bowling.Tests
{
    public class ScoreServiceTests
    {
        private readonly ScoreService sut;

        public ScoreServiceTests()
        {
            sut = new ScoreService();
        }

        [Fact]
        public void GetFinalScore_GivenInput_ShouldReturnScore()
        {

        }

        [Fact]
        public void ShowPanelScore_GivenInput_ShouldReturnScore()
        {

        }

        [Theory]
        [MemberData(nameof(GetInputData))]
        public void GetFrames_GivenInput_ShouldReturn10Frames(List<int> inputData)
        {
            var result = sut.GetFrames(inputData);
            result.Count.Should().Be(10);
        }

        public static IEnumerable<object[]> GetInputData()
        {
            yield return new object[] { new List<int> { 2, 3, 5, 4, 9, 1, 2, 5, 3, 2, 4, 2, 3, 3, 4, 6, 10, 3, 2 } };
            yield return new object[] { new List<int> { 0, 3, 5, 0, 9, 1, 2, 5, 3, 2, 4, 2, 3, 3, 4, 6, 10, 10, 2, 5 } };
        }
    }
}
