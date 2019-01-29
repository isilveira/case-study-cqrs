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

namespace SimpleCQRS.Core.Application.Users.Queries.GetUserByID
{
    public class GetUserByIDQueryHandler : IRequestHandler<GetUserByIDQuery, GetUserByIDQueryReponse>
    {
        private SingleCQRSContext Context { get; set; }

        public GetUserByIDQueryHandler(SingleCQRSContext context)
        {
            Context = context;
        }

        public async Task<GetUserByIDQueryReponse> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
        {
            var user = await Context.Users.SingleOrDefaultAsync(x => x.UserID == request.UserID);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.UserID);
            }

            return new GetUserByIDQueryReponse {
                UserID = user.UserID,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate,
                DeactivationDate = user.DeactivationDate
            };
        }
    }
}
