using System;
using Bowling.Interfaces;

namespace Bowling
{
    public class GameService : IGameService
    {
        private IInputService inputService;
        private IFrameService frameService;
        private ISummaryService summaryService;

        public GameService(IInputService inputService, IFrameService frameService, ISummaryService summaryService)
        {
            this.inputService = inputService;
            this.frameService = frameService;
            this.summaryService = summaryService;
        }

        public string StartGame(string inputFilePath)
        {
            var input = inputService.ReadFromFile(inputFilePath);
            var groupedFrames = frameService.GetFrames(input);

            return summaryService.Print(groupedFrames);
        }
    }
}