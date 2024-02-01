﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Models.Extentions;

namespace Models.Dtos
{
	public class GetFollowingStoriesDto : IPage,IRequest<AppResponseDto>
	{
		public int? UserId { get; private set; }
		public int? Take {  get; private set; }
		public int? LastId {  get; private set; }

		public GetFollowingStoriesDto(IQueryCollection collection)
		{
			UserId = collection.ReadInt("userId");
			Take = collection.ReadInt("take");
			LastId = collection.ReadInt("lastId");
		}
	}
}
