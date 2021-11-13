using System.Threading.Tasks;

namespace HometaskService.Commands.Interfaces
{
    public interface IDeleteBookCommand
    {
        Task ExecuteAsync(int id);
    }
}
