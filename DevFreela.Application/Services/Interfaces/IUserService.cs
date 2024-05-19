using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        public UserViewModel GetById(int id);

        public int Create(CreateUserInputModel createUserModel);
    }
}