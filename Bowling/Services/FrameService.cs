using System.Collections.Generic;
using System.Linq;
using Bowling.Interfaces;
using Bowling.Models;

namespace Bowling.Services
{
    public class FrameService : IFrameService
    {
        public List<Frame> GetFrames(List<int> rolls)
        {
            var frames = new List<Frame>();
            var frameNumber = 1;
            var index = 0;
            List<Roll> finalFrameRolls = null;

            while (frameNumber <= 10)
            {
                var currentThrow = rolls.ElementAt(index);

                if (Rules.IsLastFrame(frameNumber) && Rules.IsBonusRoll(currentThrow, rolls.ElementAt(index + 1)))
                {
                    finalFrameRolls = GetBonusRolls(currentThrow, rolls.ElementAt(index + 1), rolls.ElementAt(index + 2));
                }

                var frame = new Frame
                {
                    Number = frameNumber,
                    Rolls = finalFrameRolls ?? GetRolls(currentThrow, rolls.ElementAt(index + 1))
                };

                frames.Add(frame);
                index += Rules.IsStrike(currentThrow) ? 1 : 2;

                frameNumber++;
            }

            return frames;
        }

        private List<Roll> GetRolls(int firstRoll, int secondRoll)
        {
            if (Rules.IsStrike(firstRoll))
            {
                return new List<Roll>
                {
                    new Roll { Try = 1, Value = firstRoll, IsStrike = true }
                };
            }

            if (Rules.IsSpare(firstRoll, secondRoll))
            {
                return new List<Roll>
                {
                    new Roll {Try = 1, Value = firstRoll},
                    new Roll {Try = 2, Value = secondRoll, IsSpare = true}
                };
            }

            return new List<Roll>
            {
                new Roll {Try = 1, Value = firstRoll},
                new Roll {Try = 2, Value = secondRoll}
            };
        }

        private List<Roll> GetBonusRolls(int firstThrow, int secondThrow, int thirdThrow)
        {
            var rolls = GetRolls(firstThrow, secondThrow);

            if (rolls.Count == 1 && rolls.First().IsStrike)
            {
                var followingRolls = GetRolls(secondThrow, thirdThrow);
                followingRolls.First().Try = 2;

                if (!followingRolls.First().IsStrike)
                {
                    followingRolls.Last().Try = 3;
                }

                rolls.AddRange(followingRolls);
            }

            if (rolls.Count == 2 && rolls.Last().IsSpare || rolls.Last().IsStrike)
            {
                rolls.Add(new Roll
                {
                    Try = 3,
                    Value = thirdThrow,
                    IsStrike = Rules.IsStrike(thirdThrow),
                    IsSpare = Rules.IsSpare(secondThrow, thirdThrow)
                });
            }

            return rolls;
        }
    }
}