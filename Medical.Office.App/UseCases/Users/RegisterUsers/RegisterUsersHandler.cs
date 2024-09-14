using Common.Common;
using Common.Common.CleanArch;
using Medical.Office.Domain.Repository;

namespace Medical.Office.App.UseCases.Users.RegisterUsers
{
    internal class RegisterUsersHandler
        : ResultInteractorBase<RegisterUsersRequest, RegisterUsersResponse>
    {
        private readonly IUsersRepository _usersRepository;

        public RegisterUsersHandler(IUsersRepository usersRepository)
        {
            _usersRepository=usersRepository;
        }

        public override async Task<Result<RegisterUsersResponse>> Handle(RegisterUsersRequest request, CancellationToken cancellationToken)
        {
            var UsrIsUnique = _usersRepository.GetDataUserByUsrAsync(request.registerUsersDto.Usr);
            if (UsrIsUnique == null) { }

            throw new NotImplementedException();
        }
    }
}
