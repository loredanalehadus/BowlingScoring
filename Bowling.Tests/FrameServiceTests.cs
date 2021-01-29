using System.Collections.Generic;
using System.Linq;
using Bowling.Services;
using FluentAssertions;
using Xunit;

namespace Bowling.Tests
{
    public class FrameServiceTests
    {
        private readonly FrameService sut;

        public FrameServiceTests()
        {
            sut = new FrameService();
        }

        [Theory]
        [MemberData(nameof(AverageThrows))]
        [MemberData(nameof(AverageThrowsWithBonusRollStrike))]
        [MemberData(nameof(AverageThrowsWithBonusRollSpare))]
        [MemberData(nameof(BestThrows))]
        [MemberData(nameof(WorstThrows))]
        public void GetFrames_GivenInput_ShouldReturn10Frames(List<int> inputData)
        {
            var result = sut.GetFrames(inputData);
            result.Count.Should().Be(10);
        }

        [Theory]
        [MemberData(nameof(AverageThrowsWithBonusRollStrike))]
        public void GetFrames_NormalFrameWithSpare_ShouldCheckSpareRoll(List<int> inputData)
        {
            var result = sut.GetFrames(inputData);

            var rolls = result.First(f => f.Number == 3).Rolls;

            rolls.Count.Should().Be(2);

            var firstThrow = rolls.First(r => r.Number == 1);
            firstThrow.IsStrike.Should().BeFalse();
            firstThrow.IsSpare.Should().BeFalse();

            var secondThrow = rolls.First(r => r.Number == 2);
            secondThrow.IsStrike.Should().BeFalse();
            secondThrow.IsSpare.Should().BeTrue();
        }

        [Theory]
        [MemberData(nameof(AverageThrowsWithBonusRollStrike))]
        public void GetFrames_NormalFrameWithStrike_ShouldCheckStrikeRoll(List<int> inputData)
        {
            var result = sut.GetFrames(inputData);

            var rolls = result.First(f => f.Number == 9).Rolls;

            rolls.Count.Should().Be(1);

            var firstThrow = rolls.First(r => r.Number == 1);
            firstThrow.IsStrike.Should().BeTrue();
            firstThrow.IsSpare.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(AverageThrows))]
        [MemberData(nameof(WorstThrows))]
        public void GetFrames_FinalFrame_ShouldHave2Rolls(List<int> inputData)
        {
            var result = sut.GetFrames(inputData);
            var finalRolls = result.First(f => f.Number == 10).Rolls;

            finalRolls.Count.Should().Be(2);
            finalRolls.First().IsStrike.Should().BeFalse();
            finalRolls.First().IsSpare.Should().BeFalse();

            finalRolls.Last().IsStrike.Should().BeFalse();
            finalRolls.Last().IsSpare.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(AverageThrowsWithBonusRollStrike))]
        [MemberData(nameof(BestThrows))]
        public void GetFrames_FinalFrame_ShouldHave3Rolls(List<int> inputData)
        {
            var result = sut.GetFrames(inputData);
            var finalFrame = result.First(f => f.Number == 10);

            finalFrame.IsFinalFrame.Should().BeTrue();
            finalFrame.Rolls.Count.Should().Be(3);
        }

        [Theory]
        [MemberData(nameof(AverageThrowsWithBonusRollStrike))]
        public void GetFrames_FinalFrameHas1Strike_ShouldCheckEachRoll(List<int> inputData)
        {
            var result = sut.GetFrames(inputData);
            var rolls = result.First(f => f.Number == 10).Rolls;

            var firstRoll = rolls.First(r => r.Number == 1);
            firstRoll.IsStrike.Should().BeTrue();
            firstRoll.IsSpare.Should().BeFalse();

            var secondRoll = rolls.First(r => r.Number == 2);
            secondRoll.IsStrike.Should().BeFalse();
            secondRoll.IsSpare.Should().BeFalse();

            var thirdRoll = rolls.First(r => r.Number == 3);
            thirdRoll.IsStrike.Should().BeFalse();
            thirdRoll.IsSpare.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(AverageThrowsWithBonusRollSpare))]
        public void GetFrames_FinalFrameHas1Spare_ShouldCheckEachRoll(List<int> inputData)
        {
            var result = sut.GetFrames(inputData);
            var rolls = result.First(f => f.Number == 10).Rolls;

            var firstRoll = rolls.First(r => r.Number == 1);
            firstRoll.IsStrike.Should().BeFalse();
            firstRoll.IsSpare.Should().BeFalse();

            var secondRoll = rolls.First(r => r.Number == 2);
            secondRoll.IsStrike.Should().BeFalse();
            secondRoll.IsSpare.Should().BeTrue();

            var thirdRoll = rolls.First(r => r.Number == 3);
            thirdRoll.IsStrike.Should().BeTrue();
            thirdRoll.IsSpare.Should().BeFalse();
        }

        [Theory]
        [MemberData(nameof(BestThrows))]
        public void GetFrames_FinalFrameHas3Strikes_ShouldCheckEachRoll(List<int> inputData)
        {
            var result = sut.GetFrames(inputData);
            var rolls = result.First(f => f.Number == 10).Rolls;

            var firstRoll = rolls.First(r => r.Number == 1);
            firstRoll.IsStrike.Should().BeTrue();
            firstRoll.IsSpare.Should().BeFalse();

            var secondRoll = rolls.First(r => r.Number == 2);
            secondRoll.IsStrike.Should().BeTrue();
            secondRoll.IsSpare.Should().BeFalse();

            var thirdRoll = rolls.First(r => r.Number == 3);
            thirdRoll.IsStrike.Should().BeTrue();
            thirdRoll.IsSpare.Should().BeFalse();
        }

        public static IEnumerable<object[]> AverageThrows()
        {
            yield return new object[] { new List<int> { 2, 3, 5, 4, 9, 1, 2, 5, 3, 2, 4, 2, 3, 3, 4, 6, 10, 3, 2 } };
        }

        public static IEnumerable<object[]> AverageThrowsWithBonusRollStrike()
        {
            yield return new object[] { new List<int> { 0, 3, 5, 0, 9, 1, 2, 5, 3, 2, 4, 2, 3, 3, 4, 6, 10, 10, 2, 5 } };
        }

        public static IEnumerable<object[]> AverageThrowsWithBonusRollSpare()
        {
            yield return new object[] { new List<int> { 0, 3, 5, 0, 9, 1, 2, 5, 3, 2, 4, 2, 3, 3, 4, 6, 10, 2, 8, 10 } };
        }

        public static IEnumerable<object[]> BestThrows()
        {
            yield return new object[] { new List<int> { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 } };
        }

        public static IEnumerable<object[]> WorstThrows()
        {
            yield return new object[] { new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
        }
    }
}