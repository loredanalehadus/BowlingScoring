using System.Collections.Generic;
using System.Text;
using Bowling.Models;

namespace Bowling.Services
{
    public class GameSummary
    {
        public string Print(List<Frame> frames)
        {
            var output = new StringBuilder().Append("| f1 | f2 | f3 | f4 | f5 | f6 | f7 | f8 | f9 | f10   |");
            output.AppendLine().Append("|");

            foreach (var frame in frames)
            {
                foreach (var roll in frame.Rolls)
                {
                    if (roll.Try == 1 && !frame.IsFinalFrame)
                    {
                        if (roll.Value == 0)
                        {
                            output.Append("-, ");
                        }

                        if (roll.IsStrike)
                        {
                            output.Append("X   ");
                        }

                        if (roll.Value > 0 && roll.Value < 10)
                        {
                            output.Append($"{roll.Value}, ");
                        }
                    }

                    if (roll.Try == 2 && !frame.IsFinalFrame)
                    {
                        if (roll.Value == 0)
                        {
                            output.Append("-");
                        }

                        if (roll.Value > 0 && roll.Value < 10 && !roll.IsSpare)
                        {
                            output.Append(roll.Value);
                        }

                        if (roll.IsSpare)
                        {
                            output.Append("/");
                        }
                    }

                    if (frame.IsFinalFrame)
                    {
                        if (roll.Try == 1)
                        {
                            if (roll.Value == 0)
                            {
                                output.Append("-, ");
                            }

                            if (roll.IsStrike)
                            {
                                output.Append("X, ");
                            }

                            if (roll.Value > 0 && roll.Value < 10)
                            {
                                output.Append($"{roll.Value}, ");
                            }
                        }

                        if (roll.Try == 2)
                        {
                            if (roll.Value == 0)
                            {
                                output.Append("-");
                            }

                            if (roll.IsStrike)
                            {
                                output.Append("X");
                            }

                            if (roll.IsSpare)
                            {
                                output.Append("/");
                            }

                            if (roll.Value > 0 && roll.Value < 10)
                            {
                                output.Append($"{roll.Value}");
                            }
                        }

                        if (roll.Try == 3)
                        {
                            if (roll.Value == 0)
                            {
                                output.Append(", -");
                            }

                            if (roll.Value > 0 && roll.Value < 10 && !roll.IsSpare)
                            {
                                output.Append($", {roll.Value}");
                            }

                            if (roll.IsStrike)
                            {
                                output.Append(", X");
                            }

                            if (roll.IsSpare)
                            {
                                output.Append(", /");
                            }
                        }
                    }
                }

                if (frame.Rolls.Count == 2 && frame.IsFinalFrame)
                {
                    output.Append("   ");
                }

                output.Append("|");
            }
            return output.ToString();
        }
    }
}