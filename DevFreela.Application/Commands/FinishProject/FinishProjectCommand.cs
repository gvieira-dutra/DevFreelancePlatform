using MediatR;

namespace DevFreela.Application.Commands.FinishProject
{
    public class FinishProjectCommand : IRequest<bool>
    {

        public int Id { get; set; }
        public string CcNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiryDate { get; set; }
        public string FullName { get; set; }
    }
}
