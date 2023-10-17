﻿using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Application.Queries
{
	public class GetActiveProfileImageByUserNameQueryHandler : IRequestHandler<GetActiveProfileImageByUserName, byte[]>
	{
		private readonly IFileWriterService _writerService;
		private readonly IBlobService _blobService;
		private readonly UserManager<User> _userManager;

		public GetActiveProfileImageByUserNameQueryHandler(IFileWriterService writerService, IBlobService blobService, UserManager<User> userManager)
		{
			_writerService = writerService;
			_blobService = blobService;
			_userManager = userManager;
		}

		public async Task<byte[]> Handle(GetActiveProfileImageByUserName request, CancellationToken cancellationToken)
		{
			var user = await _userManager
				.Users
				.AsNoTracking()
				.Include(x => x.ProfileImages)
				.FirstOrDefaultAsync(x => x.UserName == request.UserName);
			if (user == null) throw new UserNotFoundException();
			var image = user.ProfileImages.FirstOrDefault(x => x.IsActive);
			if (image == null)
			{
				var rootPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
				byte[] noImageFile;
				if (user.Gender == null)
					noImageFile = await File.ReadAllBytesAsync($"{rootPath}/Images/noImage.jpg", cancellationToken);
				else if ((bool)user.Gender)
					noImageFile = await File.ReadAllBytesAsync($"{rootPath}/Images/noProfileMan.jpg", cancellationToken);
				else
					noImageFile = await File.ReadAllBytesAsync($"{rootPath}/Images/noProfileWoman.jpg", cancellationToken);
				await _writerService.WriteFileAsync(noImageFile, "jpg", cancellationToken);
				return _writerService.Bytes;
			}
			var profileImage = await _blobService.DownloadAsync(image.BlobName, image.ContainerName, cancellationToken);
			await _writerService.WriteFileAsync(profileImage, image.Extention, cancellationToken);
			return _writerService.Bytes;
		}
	}
}
