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

            while (frameNumber <= Rules.MaxFrameNumber)
            {
                var currentThrow = rolls.ElementAt(index);
                var nextThrow = rolls.ElementAt(index + 1);

                if (Rules.IsBonusRoll(currentThrow, nextThrow, frameNumber))
                {
                    var lastThrow = rolls.ElementAt(index + 2);
                    finalFrameRolls = GetBonusRolls(currentThrow, nextThrow, lastThrow);
                }

                var frame = new Frame
                {
                    Number = frameNumber,
                    Rolls = finalFrameRolls ?? GetRolls(currentThrow, nextThrow),
                    IsFinalFrame = Rules.IsLastFrame(frameNumber)
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
                    new Roll { Number = 1, Value = firstRoll, IsStrike = true }
                };
            }

            if (Rules.IsSpare(firstRoll, secondRoll))
            {
                return new List<Roll>
                {
                    new Roll {Number = 1, Value = firstRoll},
                    new Roll {Number = 2, Value = secondRoll, IsSpare = true}
                };
            }

            return new List<Roll>
            {
                new Roll {Number = 1, Value = firstRoll},
                new Roll {Number = 2, Value = secondRoll}
            };
        }

        private List<Roll> GetBonusRolls(int firstThrow, int secondThrow, int thirdThrow)
        {
            return new List<Roll>
            {
                new Roll
                {
                    Number = 1,
                    Value = firstThrow,
                    IsStrike = Rules.IsStrike(firstThrow),
                },
                new Roll
                {
                    Number = 2,
                    Value = secondThrow,
                    IsStrike = Rules.IsStrike(secondThrow),
                    IsSpare = Rules.IsSpare(firstThrow, secondThrow)
                },
                new Roll
                {
                    Number = 3,
                    Value = thirdThrow,
                    IsStrike = Rules.IsStrike(thirdThrow),
                    IsSpare = Rules.IsSpare(secondThrow, thirdThrow)
                }
            };
        }
    }
}