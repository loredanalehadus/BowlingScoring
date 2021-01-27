using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bowling.Models;

namespace Bowling.Services
{
    public class ScoreService : IScoreService
    {
        public int GetFinalScore(List<int> rolls)
        {

            return 0;

        }

        public string ShowPanelScore(List<int> rolls)
        {
            var output = new StringBuilder().Append("| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |");

            return output.ToString();

        }

        private bool IsStrike(int roll)
        {
            return roll == 10;
        }

        private bool IsSpare(int firstRoll, int secondRoll)
        {
            if (firstRoll == 10)
            {
                return false;
            }

            return firstRoll + secondRoll == 10;
        }

        private bool IsLastFrame(int frameNumber)
        {
            return frameNumber == 10;
        }

        private bool IsBonusRoll(int firstRoll, int secondRoll)
        {
            return IsStrike(firstRoll) || IsSpare(firstRoll, secondRoll);
        }

        public List<Frame> GetFrames(List<int> rolls)
        {
            var frames = new List<Frame>();
            var frameNumber = 1;
            int index = 0;

            while (index < rolls.Count)
            {
                var throwScore = rolls.ElementAt(index);


                Frame frame;
                if (IsLastFrame(frameNumber))
                {
                    frame = new Frame
                    {
                        Number = frameNumber,
                        Rolls = new List<Roll>
                        {
                            new Roll { Try = 1, Value = throwScore },
                            new Roll { Try = 2, Value = rolls.ElementAt(index + 1) }
                        }
                    };

                    if (IsBonusRoll(throwScore, rolls.ElementAt(index + 1)))
                    {
                        frame.Rolls.Add(new Roll { Try = 3, Value = rolls.ElementAt(index + 2) });
                    }

                    frames.Add(frame);
                    break;
                }

                if (IsStrike(throwScore))
                {
                    frame = new Frame
                    {
                        Number = frameNumber,
                        Rolls = new List<Roll> { new Roll { Try = 1, Value = throwScore, IsStrike = true} }
                    };

                    frames.Add(frame);
                    index++;
                    frameNumber++;
                    continue;
                }

                if (IsSpare(throwScore, rolls.ElementAt(index + 1)))
                {
                    frame = new Frame
                    {
                        Number = frameNumber,
                        Rolls = new List<Roll>
                    {
                        new Roll { Try = 1, Value = throwScore },
                        new Roll { Try = 2, Value = rolls.ElementAt(index + 1), IsSpare = true}
                    }
                    };

                    frames.Add(frame);
                    index += 2;
                    frameNumber++;
                    continue;
                }


                var roll1 = new Roll { Try = 1, Value = throwScore };
                var roll2 = new Roll { Try = 2, Value = rolls.ElementAt(index + 1) };
                frame = new Frame { Number = frameNumber, Rolls = new List<Roll> { roll1, roll2 } };

                frames.Add(frame);
                index += 2;
                frameNumber++;
            }

            return frames;
        }
    }
}