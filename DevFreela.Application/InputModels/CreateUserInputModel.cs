﻿namespace DevFreela.Application.InputModels
{
    public class CreateUserInputModel
    {
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
    }
}
