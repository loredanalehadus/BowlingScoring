using System.Collections.Generic;
using System.Text;
using Bowling.Interfaces;
using Bowling.Models;

namespace Bowling.Services
{
    public class OutputService : IOutputService
    {
        private readonly IScoreService scoreService;

        public OutputService(IScoreService scoreService)
        {
            this.scoreService = scoreService;
        }

        public string Print(List<Frame> frames)
        {
            var output = new StringBuilder().AppendLine(Rules.FrameHeader).Append(Rules.FrameDelimiter);

            foreach (var frame in frames)
            {
                foreach (var roll in frame.Rolls)
                {
                    output
                        .Append(GetRollSymbol(roll))
                        .Append(GetSpacing(roll, frame));
                }

                output.Append(Rules.FrameDelimiter);
            }

            output.AppendLine();
            output.AppendLine($"score: {scoreService.GetTotalScore(frames).ToString()}");
            return output.ToString();
        }

        private string GetRollSymbol(Roll roll)
        {
            var symbol = roll.Value switch
            {
                Rules.GutterScore => "-",
                Rules.StrikeScore => "X",
                _ => roll.Value.ToString()
            };

            return roll.IsSpare ? "/" : symbol;
        }

        private string GetSpacing(Roll roll, Frame frame)
        {
            if (frame.IsFinalFrame && frame.Rolls.Count == 2 && roll.Number == 2 ||
                !frame.IsFinalFrame && roll.IsStrike)
            {
                return "   ";
            }

            if (frame.IsFinalFrame && roll.Number == 3 ||
                !frame.IsFinalFrame && roll.Number == 2)
            {
                return "";
            }

            return ", ";
        }
    }
}