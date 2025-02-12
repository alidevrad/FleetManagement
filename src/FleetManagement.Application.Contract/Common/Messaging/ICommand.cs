using MediatR;

namespace FleetManagement.Application.Contract.Common.Messaging;

public interface ICommand : IRequest, ICommandBase { }

public interface ICommand<TResponse> : IRequest<TResponse>, ICommandBase { }

