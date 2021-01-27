using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bowling.Models;

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