using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleCQRS.Core.Domain.Entities;
using SimpleCQRS.Core.Infrastructures.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Application.Users.Queries.GetUsersByFilter
{
    public class GetUsersByFilterQueryHandler : IRequestHandler<GetUsersByFilterQuery, GetUsersByFilterQueryResponse>
    {
        private SingleCQRSContext Context { get; set; }

        public GetUsersByFilterQueryHandler(SingleCQRSContext context)
        {
            Context = context;
        }

        public async Task<GetUsersByFilterQueryResponse> Handle(GetUsersByFilterQuery request, CancellationToken cancellationToken)
        {
            var query = Context.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Email))
                query = query.Where(x => x.Email.ToLower().Contains(request.Email.ToLower()));

            var totalResults = await query.CountAsync();

            var users = await query.ToListAsync();

            return new GetUsersByFilterQueryResponse
            {
                Query = request,
                TotalResults = totalResults,
                Results = users.Select(
                    x=> new GetUsersByFilterQueryResponseItem
                    {
                        UserID = x.UserID,
                        Email = x.Email,
                        RegistrationDate = x.RegistrationDate,
                        DeactivationDate = x.DeactivationDate
                    }).ToList()
            };
        }
    }
}
