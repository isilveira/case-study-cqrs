using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Application.Users.Queries.GetUserByID
{
    public class GetUserByIDQuery: IRequest<GetUserByIDQueryReponse>
    {
        public long UserID { get; set; }
    }
}
