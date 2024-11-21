namespace PT.Dasigno.DTO.Users
{
    public class CreateUserRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleName { get; set; } = string.Empty;
        public string FirstLastName { get; set; } = string.Empty;
        public string? SecondLastName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public double Salary { get; set; }
    }
}
