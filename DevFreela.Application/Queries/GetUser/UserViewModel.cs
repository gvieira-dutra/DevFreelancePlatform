namespace DevFreela.Application.Queries.GetUser
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        public string Email { get; private set; }
        public string FullName { get; private set; }
    }
}
