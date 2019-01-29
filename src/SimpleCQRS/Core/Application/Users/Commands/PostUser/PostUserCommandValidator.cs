using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Application.Users.Commands.PostUser
{
    public class PostUserCommandValidator : AbstractValidator<PostUserCommand>
    {
        public PostUserCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).Matches(@"\b[\w\.-]+@[\w\.-]+\.\w{2,4}\b");
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Matches(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{6,}$");
        }
    }
}
