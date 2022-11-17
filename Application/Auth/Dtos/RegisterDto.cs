namespace Application.Auth.Dtos
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
    }
}
