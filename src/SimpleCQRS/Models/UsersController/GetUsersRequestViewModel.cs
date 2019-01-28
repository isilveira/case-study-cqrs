using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCQRS.Models.UsersController
{
    public class GetUsersRequestViewModel
    {
        public string Email { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
