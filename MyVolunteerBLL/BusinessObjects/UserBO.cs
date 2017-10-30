using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVolunteerBLL.BusinessObjects
{
    public class UserBO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25)]
        [MinLength(2)]
        public string LastName { get; set; }

        public string FullName
        { 
            get { return $"{FirstName} {LastName}"; }
        }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public List<int> GuildIds { get; set; }
        public List<GuildBO> Guilds { get; set; }
    }
}
