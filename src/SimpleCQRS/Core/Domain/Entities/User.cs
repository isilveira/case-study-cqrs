using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Domain.Entities
{
    public class User
    {
        public long UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? DeactivationDate { get; set; }

        internal void SetData(string email, string password)
        {
            Email = email;
            Password = password;
            RegistrationDate = DateTime.Now;
        }

        internal void UpdateData(string email)
        {
            Email = email;
        }
    }
}
