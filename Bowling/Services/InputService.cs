using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bowling.Interfaces;

namespace Bowling.Services
{
    public class ConsoleInputService : IInputService
    {
        private string filePath;

        public ConsoleInputService(string filePath)
        {
            this.filePath = filePath;
        }

        public List<int> ReadFromFile()
        {
            var input = File.ReadAllText(filePath);
            return input.Split(',').Select(int.Parse).ToList();
        }
    }
}