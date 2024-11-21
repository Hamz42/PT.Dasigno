using System.ComponentModel.DataAnnotations;

namespace PT.Dasigno.DAL.Context.ContextDasigno.Entities
{
    public class Users
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? MiddleName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string FirstLastName { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? SecondLastName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public double Salary { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
