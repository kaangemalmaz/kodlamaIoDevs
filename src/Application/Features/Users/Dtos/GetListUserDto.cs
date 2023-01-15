using Core.Security.Entities;
using Core.Security.Enums;

namespace Application.Features.Users.Dtos
{
    public class GetListUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }

        public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
