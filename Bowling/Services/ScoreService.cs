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

                if (currentFrame.IsFinalFrame || !(Rules.FrameHasSpare(currentFrame) || Rules.FrameHasStrike(currentFrame)))
                {
                    currentFrame.Score = FrameRollsSum(currentFrame.Rolls);
                    continue;
                }
                
                if (Rules.FrameHasStrike(currentFrame))
                {
                    var numberOfFramesToTake = frames[i + 1].IsFinalFrame ? 1 : 2;
                    var rolls = frames.GetRange(i + 1, numberOfFramesToTake).SelectMany(f => f.Rolls).Take(2);

                    currentFrame.Score = Rules.StrikeScore + FrameRollsSum(rolls);
                }

                if (Rules.FrameHasSpare(currentFrame))
                {
                    currentFrame.Score = Rules.StrikeScore + FirstFrameRollValue(frames[i + 1]);
                }
            }

            return frames.Sum(f => f.Score);
        }

        private int FirstFrameRollValue(Frame frame)
        {
            return frame.Rolls.First(r => r.Number == 1).Value;
        }

        private int FrameRollsSum(IEnumerable<Roll> rolls)
        {
            return rolls.Sum(r => r.Value);
        }
    }
}