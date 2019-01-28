using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCQRS.Models.UsersController
{
    public class GetUsersResponseViewModel
    {
        public GetUsersRequestViewModel Request { get; set; }
        public int ResultCount { get; set; }
        public List<GetUsersResponseItemViewModel> Result { get; set; }
    }
}
