using System.Collections.Generic;

namespace Bowling.Interfaces
{
    public interface IInputService
    {
        List<int> ReadFromFile();
    }
}