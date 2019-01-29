using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Application.Users.Queries.GetUsersByFilter
{
    public class GetUsersByFilterQueryResponse
    {
        public GetUsersByFilterQuery Query { get; set; }
        public int TotalResults { get; set; }
        public List<GetUsersByFilterQueryResponseItem> Results { get; set; }
    }
}
