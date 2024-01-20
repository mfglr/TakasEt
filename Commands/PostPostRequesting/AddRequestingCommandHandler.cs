﻿using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
    public class AddRequestingCommandHandler : IRequestHandler<AddRequestings, AppResponseDto>
    {

        private readonly IRepository<Requesting> _swapRequests;

        public AddRequestingCommandHandler(IRepository<Requesting> swapRequests)
        {
            _swapRequests = swapRequests;
        }

        public async Task<AppResponseDto> Handle(AddRequestings request, CancellationToken cancellationToken)
        {
            var swapRequests = new List<Requesting>();
            foreach (var requesterId in request.RequesterIds)
                swapRequests.Add(new Requesting(requesterId, request.RequestedId));
            await _swapRequests
                .DbSet
                .AddRangeAsync(swapRequests);
            return AppResponseDto.Success();
        }
    }
}
