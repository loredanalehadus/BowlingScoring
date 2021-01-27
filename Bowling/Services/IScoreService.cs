using System.Collections.Generic;

namespace Bowling.Services
{
    public interface IScoreService
    {
        int GetFinalScore(List<int> rolls);
        string ShowPanelScore(List<int> rolls);
    }
}