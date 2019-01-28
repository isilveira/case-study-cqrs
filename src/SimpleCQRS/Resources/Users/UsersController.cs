using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCQRS.Core.Application.Users.Queries.GetUsersByFilter;
using SimpleCQRS.Models.UsersController;

namespace SimpleCQRS.Resources.Users
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IMediator Mediator { get;set; }
        public UsersController(IMediator mediator)
        {
            Mediator = mediator;
        }
        // GET api/values
        [HttpGet]
        public Task<GetUsersByFilterQueryResponse> Get(GetUsersRequestViewModel request)
        {
            return Mediator.Send(new GetUsersByFilterQuery { Email = "italobrian@gmail.com" });
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
