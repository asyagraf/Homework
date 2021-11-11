using HometaskService.ModelsDTO;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetPersonCommand
    {
        PersonDTO Execute(int id);
    }
}
