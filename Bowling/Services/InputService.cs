using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bowling.Interfaces;

namespace Bowling.Services
{
    public class InputService : IInputService
    {
        public List<int> ReadFromFile(string path)
        {
            var input = File.ReadAllText(path);
            return input.Split(',').Select(int.Parse).ToList();
        }
    }
}