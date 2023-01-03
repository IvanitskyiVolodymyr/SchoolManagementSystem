﻿using Common.Dtos.Auth;

namespace Web.Tests.Integration.Setup
{
    public static class ModelsProvider
    {
        public static List<LoginDto> GetStudentsLoginData()
        {
            return new List<LoginDto>
            {
                new LoginDto
                {
                    Email = "student@gmail.com",
                    Password = "studentP"
                },
                new LoginDto
                {
                    Email = "student2@gmail.com",
                    Password = "studentP"
                }
            };
        }

    }
}
