using MediatR;
using SimpleCQRS.Core.Domain.Entities;
using SimpleCQRS.Core.Infrastructures.Data.Contexts;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleCQRS.Core.Application.Users.Commands.PostUser
{
    public class PostUserCommandHandler : IRequestHandler<PostUserCommand, PostUserCommandResponse>
    {
        private SingleCQRSContext Context { get; set; }

        public PostUserCommandHandler(SingleCQRSContext context)
        {
            Context = context;
        }

        public async Task<PostUserCommandResponse> Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            if (Context.Users.Any(x => x.Email.ToLower().Equals(request.Email.ToLower())))
                throw new Exception("E-mail already registered!");

            if (request.Password != request.PasswordConfirmation)
                throw new Exception("Password and password confirmation don't match!");

            var user = new User();

            user.SetData(request.Email, request.Password);

            await Context.Users.AddAsync(user, cancellationToken);
            await Context.SaveChangesAsync(cancellationToken);

            return new PostUserCommandResponse
            {
                UserID = user.UserID,
                Email = user.Email,
                RegistrationDate = user.RegistrationDate,
                DeactivationDate = user.DeactivationDate
            };
        }
    }
}
