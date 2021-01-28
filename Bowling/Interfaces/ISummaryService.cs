using System.Collections.Generic;
using Bowling.Models;

namespace Bowling.Interfaces
{
    public interface ISummaryService
    {
        string Print(List<Frame> frames);
    }
}