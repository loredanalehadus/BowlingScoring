using System.Collections.Generic;
using Bowling.Models;

namespace Bowling.Interfaces
{
    public interface IOutputService
    {
        string Print(List<Frame> frames);
    }
}