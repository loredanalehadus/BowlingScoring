using System.Collections.Generic;

namespace Bowling.Services
{
    public interface IInputService
    {
        List<int> ReadFromFile(string path);
    }
}