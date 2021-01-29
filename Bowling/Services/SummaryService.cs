using System.Collections.Generic;
using System.Text;
using Bowling.Interfaces;
using Bowling.Models;

namespace Bowling.Services
{
    public class SummaryService : ISummaryService
    {
        private readonly IScoreService scoreService;

        public SummaryService(IScoreService scoreService)
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
                        .Append(Rules.GetRollSymbol(roll.Value, roll.IsSpare))
                        .Append(Rules.GetSpacing(roll, frame));
                }

                output.Append(Rules.FrameDelimiter);
            }

            output.AppendLine();
            output.AppendLine($"score: {scoreService.GetTotalScore(frames).ToString()}");
            return output.ToString();
        }
    }
}