﻿using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class UserToReturnDto
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
    }
}
