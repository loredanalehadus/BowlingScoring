using System.Collections.Generic;

namespace Bowling.Interfaces
{
    public interface IScoreService
    {
        int GetFinalScore(List<int> rolls);
        string ShowPanelScore(List<int> rolls);
    }
}