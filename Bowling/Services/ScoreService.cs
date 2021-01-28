using System.Collections.Generic;
using System.Text;
using Bowling.Interfaces;

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
    }
}