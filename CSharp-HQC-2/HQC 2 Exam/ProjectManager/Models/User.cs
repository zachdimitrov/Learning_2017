﻿using ProjectManager.Models.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{
    public class User : IUser
    {
        public User(string username, string email)
        {
            this.Username = username;
            this.Email = email;
        }

        [Required(ErrorMessage = "User Username is required!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "User Email is required!")]

        // [EmailAddress(ErrorMessage = "User Email is not valid!")]
        public string Email { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("    Username: " + this.Username);
            builder.AppendLine("    Email: " + this.Email);
            return builder.ToString();
        }
    }
}
