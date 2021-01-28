using System.Collections.Generic;
using System.Linq;
using Bowling.Interfaces;
using Bowling.Models;

namespace Bowling.Services
{
    public class ScoreService : IScoreService
    {
        public int GetFinalScore(List<Frame> frames)
        {
            for (int i = 0; i < frames.Count; i++)
            {
                if (frames[i].IsFinalFrame)
                {
                    frames[i].Score = frames[i].Rolls.Sum(r => r.Value);
                    break;
                }

                if (!frames[i].Rolls.Any(r => r.IsStrike || r.IsSpare))
                {
                    frames[i].Score = frames[i].Rolls.Sum(r => r.Value);
                }

                if (frames[i].Rolls.Any(r => r.IsSpare))
                {
                    frames[i].Score = 10 + frames[i + 1].Rolls.First(r => r.Try == 1).Value;
                }

                if (frames[i].Rolls.Any(r => r.IsStrike))
                {
                    frames[i].Score = GetFrameScoreForStrike(frames, i);
                }
            }

            return frames.Sum(f => f.Score);
        }

        private int GetFrameScoreForStrike(List<Frame> frames, int index)
        {
            if (index >= 9)
            {
                return frames[index].Rolls.First(r => r.Try == 1).Value + frames[index].Rolls.First(r => r.Try == 2).Value;
            };

            if (frames[index].Rolls.Any(r => r.IsStrike))
            {
                return frames[index].Score = 10 + GetFrameScoreForStrike(frames, index + 1);
            }

            return frames[index + 1].Rolls.First(r => r.Try == 1).Value;
        }

    }
}