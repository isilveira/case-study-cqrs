using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Application.Users.Commands.PostUser
{
    public class PostUserCommand : IRequest<PostUserCommandResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
