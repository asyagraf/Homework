using HometaskService.ModelsDTO;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetCarCommand
    {
        CarDTO Execute(string number);
    }
}
