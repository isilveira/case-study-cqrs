using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Application.Users.Commands.PutUser
{
    public class PutUserCommand : IRequest<PutUserCommandResponse>
    {
        public long UserID { get; set; }
        public string Email { get; set; }
    }
}
