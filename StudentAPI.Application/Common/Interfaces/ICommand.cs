using MediatR;
namespace StudentAPI.Application.Common.Interfaces
{
    public interface ICommand<TResponse> : IRequest<TResponse> { }
    public interface ICommand : IRequest { }
    public interface IQuery<TResponse> : IRequest<TResponse> { }
}