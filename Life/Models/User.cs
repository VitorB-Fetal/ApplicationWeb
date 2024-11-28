using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
namespace Life.Models
{
    
        public class User
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }

    }



