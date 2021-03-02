using Identity.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.API.Entities
{
    public class User
    {
        public User()
        {

        }

        public User(UserDto u)
        {
            Id = Guid.NewGuid();
            Name = u.Name;
            Surname = u.Surname;
            Birthday = u.Birthday;
            GroupId = u.GroupId;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? Birthday { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
        public string Role { get; set; }


    }
}
