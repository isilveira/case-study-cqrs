using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Core.Infrastructures.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Application.Users.Commands.PutUser
{
    public class PutUserCommandHandler : IRequestHandler<PutUserCommand, PutUserCommandResponse>
    {
        private SingleCQRSContext Context { get; set; }

        public PutUserCommandHandler(SingleCQRSContext context)
        {
            Context = context;
        }

        public async Task<PutUserCommandResponse> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            if (await Context.Users.AnyAsync(x => x.Email.ToLower().Equals(request.Email.ToLower()) && x.UserID!=request.UserID, cancellationToken))
                throw new Exception("E-mail already registered!");

            var user = await Context.Users.SingleOrDefaultAsync(x => x.UserID == request.UserID, cancellationToken);

            user.UpdateData(request.Email);

            await Context.SaveChangesAsync(cancellationToken);

            return new PutUserCommandResponse
            {
                UserID = user.UserID,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate,
                DeactivationDate = user.DeactivationDate
            };
        }
    }
}
