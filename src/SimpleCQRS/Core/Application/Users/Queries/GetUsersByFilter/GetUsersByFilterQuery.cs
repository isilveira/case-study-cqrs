using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Application.Users.Queries.GetUsersByFilter
{
    public class GetUsersByFilterQuery:IRequest<GetUsersByFilterQueryResponse>
    {
        public string Email { get; set; }

        public GetUsersByFilterQuery()
        {
        }
    }
}
