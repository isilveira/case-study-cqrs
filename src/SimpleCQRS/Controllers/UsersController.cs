using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleCQRS.Models.UsersController;

namespace SimpleCQRS.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        // GET api/values
        [HttpGet]
        public GetUsersResponseViewModel Get(GetUsersRequestViewModel request)
        {
            var response = new GetUsersResponseViewModel();

            response.Request = request;

            response.ResultCount = 156;
            response.Result = new List<GetUsersResponseItemViewModel> {
                new GetUsersResponseItemViewModel {
                    UserID = 1,
                    Email = "john.doe@mail.com",
                    RegistrationDate = Convert.ToDateTime("2019-01-22 09:45:22")
                },
                new GetUsersResponseItemViewModel {
                    UserID = 2,
                    Email = "charles.doe@mail.com",
                    RegistrationDate = Convert.ToDateTime("2019-01-22 10:35:52")
                },
                new GetUsersResponseItemViewModel {
                    UserID = 3,
                    Email ="anne.doe@mail.com",
                    RegistrationDate = Convert.ToDateTime("2019-01-22 10:37:21")
                },
                new GetUsersResponseItemViewModel {
                    UserID = 4,
                    Email ="jeff.doe@mail.com",
                    RegistrationDate = Convert.ToDateTime("2019-01-22 13:21:59")
                },
                new GetUsersResponseItemViewModel {
                    UserID = 5,
                    Email ="mary.doe@mail.com",
                    RegistrationDate = Convert.ToDateTime("2019-01-22 19:27:09")
                }
            };

            return response;
        }

        // GET api/values/5
        [HttpGet("{userid}")]
        public GetUserResponseViewModel Get(GetUserRequestViewModel request)
        {
            var response = new GetUserResponseViewModel
            {
                UserID = 5,
                Email = "mary.doe@mail.com",
                RegistrationDate = Convert.ToDateTime("2019-01-22 19:27:09")
            };

            return response;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
