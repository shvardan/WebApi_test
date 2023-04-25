using MediatR;

namespace Eshop.Application.Features.Storage.DropStorage
{
    public sealed record DropStorageRequest : IRequest<DropStorageResponse>;
}