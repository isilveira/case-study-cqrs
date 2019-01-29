using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Core.Domain.Entities;
using SimpleCQRS.Core.Infrastructures.Data.Contexts;
using SimpleCQRS.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommandResponse>
    {
        private SingleCQRSContext Context { get; set; }

        public DeleteUserCommandHandler(SingleCQRSContext context)
        {
            Context = context;
        }

        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await Context.Users.SingleOrDefaultAsync(x => x.UserID == request.UserID);

            if (user == null)
                throw new NotFoundException(typeof(User).Name, request.UserID);

            Context.Users.Remove(user);

            await Context.SaveChangesAsync(cancellationToken);

            return new DeleteUserCommandResponse
            {
                Message = "User successfully removed!"
            };
        }
    }
}
