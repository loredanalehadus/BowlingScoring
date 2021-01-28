using System.Collections.Generic;
using System.Text;
using Bowling.Interfaces;
using Bowling.Models;
using Bowling.Services;
using Bowling.Tests.TestData;
using FluentAssertions;
using Moq;
using Xunit;

namespace Bowling.Tests
{
    public class SummaryServiceTests
    {
        private readonly Mock<IScoreService> mockScoreService;
        private readonly SummaryService sut;

        public SummaryServiceTests()
        {
            mockScoreService = new Mock<IScoreService>();

            sut = new SummaryService(mockScoreService.Object);
        }

        [Theory]
        [ClassData(typeof(AverageFrames))]
        public void Print_AverageFrames_ShouldPrintResults(List<Frame> frames, int score)
        {
            mockScoreService.Setup(service => service.GetFinalScore(frames)).Returns(score);

            var result = sut.Print(frames);
            var expectedResult = new StringBuilder()
                .AppendLine("| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |")
                .AppendLine("|2, 3|5, 4|9, /|2, 5|3, 2|4, 2|3, 3|4, /|X   |3, 2   |")
                .AppendLine($"score: {score.ToString()}")
                .ToString();

            result.Should().Be(expectedResult);
        }

        [Theory]
        [ClassData(typeof(AverageFramesWithFinalBonusRoll))]
        public void Print_AverageFramesWithBonusRoll_ShouldPrintResults(List<Frame> frames, int score)
        {
            mockScoreService.Setup(service => service.GetFinalScore(frames)).Returns(score);
            
            var result = sut.Print(frames);
            var expectedResult = new StringBuilder()
                .AppendLine("| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |")
                .AppendLine("|-, 3|5, -|9, /|2, 5|3, 2|4, 2|3, 3|4, /|X   |X, 2, 5|")
                .AppendLine($"score: {score.ToString()}")
                .ToString();

            result.Should().Be(expectedResult);
        }

        [Theory]
        [ClassData(typeof(GoodFramesWithFinalBonusRoll))]
        public void Print_GoodFramesWithFinalBonusRoll_ShouldPrintResults(List<Frame> frames, int score)
        {
            mockScoreService.Setup(service => service.GetFinalScore(frames)).Returns(score);
            
            var result = sut.Print(frames);
            var expectedResult = new StringBuilder()
                .AppendLine("| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |")
                .AppendLine("|-, 3|5, -|9, /|X   |X   |4, /|3, 3|4, /|X   |2, /, X|")
                .AppendLine($"score: {score.ToString()}")
                .ToString();

            result.Should().Be(expectedResult);
        }

        [Theory]
        [ClassData(typeof(AllStrikes))]
        public void Print_AllStrikes_ShouldPrintResults(List<Frame> frames, int score)
        {
            mockScoreService.Setup(service => service.GetFinalScore(frames)).Returns(score);

            var result = sut.Print(frames);
            var expectedResult = new StringBuilder()
                .AppendLine("| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |")
                .AppendLine("|X   |X   |X   |X   |X   |X   |X   |X   |X   |X, X, X|")
                .AppendLine($"score: {score.ToString()}")
                .ToString();

            result.Should().Be(expectedResult);
        }

        [Theory]
        [ClassData(typeof(WorstFrames))]
        public void Print_WorstFrames_ShouldPrintResults(List<Frame> frames, int score)
        {
            mockScoreService.Setup(service => service.GetFinalScore(frames)).Returns(score);

            var result = sut.Print(frames);
            var expectedResult = new StringBuilder()
                .AppendLine("| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |")
                .AppendLine("|-, -|-, -|-, -|-, -|-, -|-, -|-, -|-, -|-, -|-, -   |")
                .AppendLine($"score: {score.ToString()}")
                .ToString();

            result.Should().Be(expectedResult);
        }
    }
}