using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Presentation
{
    public record AuthorizationResponse
    {
        public string Token { get; init; }
        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string PhoneNumber { get; init; }
        public string EmailAdress { get; init; }
        public string UserId { get; init; }
    }
}
