using Bowling.Interfaces;

namespace Bowling.Services
{
    public class GameService : IGameService
    {
        private IInputService inputService;
        private IFrameService frameService;
        private IOutputService outputService;

        public GameService(IInputService inputService, IFrameService frameService, IOutputService outputService)
        {
            this.inputService = inputService;
            this.frameService = frameService;
            this.outputService = outputService;
        }

        public string StartGame(string inputFilePath)
        {
            var input = inputService.ReadFromFile(inputFilePath);
            var groupedFrames = frameService.GetFrames(input);

            return outputService.Print(groupedFrames);
        }
    }
}