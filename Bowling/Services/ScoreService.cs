using System.Collections.Generic;
using System.Linq;
using Bowling.Interfaces;
using Bowling.Models;

namespace Bowling.Services
{
    public class ScoreService : IScoreService
    {
        public int GetTotalScore(List<Frame> frames)
        {
            for (var i = 0; i < frames.Count; i++)
            {
                var currentFrame = frames[i];
                currentFrame.Score = CalculateScore(frames, i);
            }

            return frames.Sum(f => f.Score);
        }

        private int CalculateScore(List<Frame> frames, int index)
        {
            var score = 0;
            var currentFrame = frames[index];

            if (currentFrame.IsFinalFrame || !(Rules.FrameHasSpare(currentFrame) || Rules.FrameHasStrike(currentFrame)))
            {
                return FrameRollsSum(currentFrame.Rolls);
            }

            if (Rules.FrameHasStrike(currentFrame))
            {
                score = Rules.StrikeScore + FrameRollsSum(GetNextRolls(frames, index));
            }

            if (Rules.FrameHasSpare(currentFrame))
            {
                score = Rules.SpareScore + FirstRollValueInFrame(frames[index + 1]);
            }

            return score;
        }

        private int FirstRollValueInFrame(Frame frame)
        {
            return frame.Rolls.First(r => r.Number == 1).Value;
        }

        private int FrameRollsSum(IEnumerable<Roll> rolls)
        {
            return rolls.Sum(r => r.Value);
        }

        private IEnumerable<Roll> GetNextRolls(List<Frame> frames, int index)
        {
            var numberOfFramesToTake = frames[index + 1].IsFinalFrame ? 1 : 2;

            return frames
                .GetRange(index + 1, numberOfFramesToTake)
                .SelectMany(f => f.Rolls)
                .Take(2);
        }
    }
}