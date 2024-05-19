using DevFreela.Application.InputModels;
using DevFreela.Application.ViewModels;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll(string query);

        ProjectDetailViewModel GetById(int id);

        void CreateComment(CreateCommentInputModel inputModel);

        int Create(NewProjectInputModel inputModel);

        int Update(UpdateProjectInputModel updateModel);

        void Start(int id);

        void Finish(int id);

        void Delete(int id);
    }
}