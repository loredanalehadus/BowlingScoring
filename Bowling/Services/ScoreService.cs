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
                    if (frames[i + 1].IsFinalFrame)
                    {
                        frames[i].Score = 10 + frames[i + 1].Rolls.Where(r => r.Try <= 2).Sum(r => r.Value);
                        continue;
                    }

                    if (frames[i + 1].Rolls.Any(r => r.IsStrike))
                    {
                        frames[i].Score = 20 + frames[i + 2].Rolls.First(r => r.Try <= 1).Value;
                        continue;
                    }

                    frames[i].Score = 10 + frames[i + 1].Rolls.Sum(r => r.Value);
                }
            }

            return frames.Sum(f => f.Score);
        }

        private int GetFrameScoreForStrike(List<Frame> frames, int index)
        {
            if (frames[index + 1].Rolls.Any(r => r.IsStrike))
            {
                return frames[index].Score = 20 + frames[index + 1].Rolls.First().Value;
            }

            return frames[index].Score = 10 + frames[index + 1].Rolls.Sum(r => r.Value);
        }

    }
}