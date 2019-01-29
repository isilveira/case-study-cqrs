using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Application.Users.Queries.GetUserByID
{
    public class GetUserByIDQueryReponse
    {
        public long UserID { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime? DeactivationDate { get; set; }
    }
}
