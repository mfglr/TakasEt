﻿using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Queries
{
    //Belirli bir postun requester postlarini verir.
    //Post u id si ile belirler.

    public class GetRequestersQueryHandler : IRequestHandler<GetRequesters, AppResponseDto>
    {
        private readonly IRepository<Requesting> _requestings;
        private readonly IMapper _mapper;
        public GetRequestersQueryHandler(IRepository<Requesting> requestings, IMapper mapper)
        {
			_requestings = requestings;
            _mapper = mapper;
        }

        public async Task<AppResponseDto> Handle(GetRequesters request, CancellationToken cancellationToken)
        {
            var posts = await _requestings
				.DbSet
				.AsNoTracking()
				.Include(x => x.Requester)
                .ThenInclude(x => x.User)
                .Include(x => x.Requester)
                .ThenInclude(x => x.Category)
                .Where(x => x.RequestedId == request.PostId)
                .Select(x => x.Requester)
                .ToListAsync();
            return AppResponseDto.Success(_mapper.Map<List<PostResponseDto>>(posts));
        }
    }
}
