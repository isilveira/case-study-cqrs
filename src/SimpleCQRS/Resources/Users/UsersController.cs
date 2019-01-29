using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCQRS.Core.Application.Users.Commands.PostUser;
using SimpleCQRS.Core.Application.Users.Queries.GetUserByID;
using SimpleCQRS.Core.Application.Users.Queries.GetUsersByFilter;
using SimpleCQRS.Exceptions;
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
        public async Task<ActionResult<GetUsersByFilterQueryResponse>> Get([FromQuery]GetUsersByFilterQuery query)
        {
            try
            {
                return Ok(await Mediator.Send(query));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // GET api/values/5
        [HttpGet("{userid}")]
        public async Task<ActionResult<GetUserByIDQueryReponse>> Get([FromRoute]GetUserByIDQuery query)
        {
            try
            {
                return Ok(await Mediator.Send(query));
            }
            catch(NotFoundException ex)
            {
                return NotFound(new Exception(ex.Message));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<PostUserCommandResponse>> Post([FromBody]PostUserCommand command)
        {
            try
            {
                return Ok(await Mediator.Send(command));
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
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
