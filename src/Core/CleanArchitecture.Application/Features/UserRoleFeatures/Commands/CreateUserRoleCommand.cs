using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands;

public sealed record CreateUserRoleCommand(
    string RoleId, 
    string UserId) : IRequest<MessageResponse>;