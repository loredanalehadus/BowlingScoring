using System.Collections.Generic;
using Bowling.Models;

namespace Bowling.Interfaces
{
    public interface IScoreService
    {
        int GetTotalScore(List<Frame> frames);
    }
}