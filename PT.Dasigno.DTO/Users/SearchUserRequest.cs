namespace PT.Dasigno.DTO.Users
{
    public class SearchUserRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string FirstLastName { get; set; } = string.Empty;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
