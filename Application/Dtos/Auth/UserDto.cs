﻿namespace Application.Dtos.Auth
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime JoinDate { get; set; }
        public string AvatarUrl { get; set; }

        public int RoleId { get; set; }
    }
}
