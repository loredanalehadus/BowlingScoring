using System.Collections.Generic;
using Bowling.Models;

namespace Bowling.Interfaces
{
    public interface IFrameService
    {
        List<Frame> GetFrames(List<int> rolls);
    }
}