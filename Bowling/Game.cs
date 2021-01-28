using System;
using Bowling.Interfaces;

namespace Bowling
{
    public class Game : IGame
    {
        private IInputService inputService;
        private IFrameService frameService;
        private ISummaryService summaryService;

        public Game(IInputService inputService, IFrameService frameService, ISummaryService summaryService)
        {
            this.inputService = inputService;
            this.frameService = frameService;
            this.summaryService = summaryService;
        }

        public void StartGame(string inputFilePath)
        {
            var input = inputService.ReadFromFile(inputFilePath);
            var groupedFrames = frameService.GetFrames(input);

            Console.WriteLine(summaryService.Print(groupedFrames));
        }
    }
}