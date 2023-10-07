using OnlineMuhasebeServer.Application.Messaging;

namespace OnlineMuhasebeServer.Application.Features.AppFeatures.MainRoleFeatures.Commands.CreateMainRole;

public sealed record CreateMainRoleCommand(string Title, string CompanyId=null): ICommand<CreateMainRoleCommandResponse>
{
}
