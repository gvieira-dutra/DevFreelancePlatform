using DevFreela.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModel> GetAll();
        ProjectDetailViewModel GetById(int id);
        int Create(NewProjectInputModel inputModel);
        int Update(UpdateProjectModel updateModel);
        void Delete(int id);
        void CreateComment(CreateCommentInputModel inputModel);
        void Start(int id);
        void Finish(int id);
    }
}
