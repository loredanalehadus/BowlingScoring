using System.Collections.Generic;
using Bowling.Models;
using Bowling.Services;
using Bowling.Tests.TestData;
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

        [Theory]
        [ClassData(typeof(AverageFrames))]
        [ClassData(typeof(AverageFramesWithFinalBonusRoll))]
        [ClassData(typeof(GoodFramesWithFinalBonusRoll))]
        [ClassData(typeof(AllStrikes))]
        [ClassData(typeof(WorstFrames))]
        public void GetFinalScore_GivenFrames_ShouldCalculateScore(List<Frame> frames, int expectedScore)
        {
            var result = sut.GetFinalScore(frames);
            result.Should().Be(expectedScore);
        }
    }
}
