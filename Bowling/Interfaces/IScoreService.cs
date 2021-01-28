using System.Collections.Generic;
using Bowling.Models;

namespace Bowling.Interfaces
{
    public interface IScoreService
    {
        int GetFinalScore(List<Frame> frames);
    }
}