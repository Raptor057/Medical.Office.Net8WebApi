using Common.Common.CleanArch;
using Medical.Office.App.UseCases.Users.GetUsers.Responses;

namespace Medical.Office.App.UseCases.Users.GetUsers
{
    public sealed class GetUsersRequest : IRequest<GetUsersResponse>
    {
        public GetUsersRequest() { }
        public long Id { get; set; }
        public string Usr { get; set; }
    }
}
