﻿using AuthService.Application.Dtos;
using AuthService.Core.Abstracts;
using AuthService.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using SharedLibrary.UnitOfWork;
using System.Data;
using System.Net;

namespace AuthService.Application.Commands
{
    public class RemoveBlockCommandHandler : IRequestHandler<RemoveBlockDto,IAppResponseDto>
    {

        private readonly ITokenService _tokenService;
        private readonly UserManager<UserAccount> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly BlockingCheckerService _blockingChecker;
        private readonly IUnitOfWork _unitOfWork;


        public RemoveBlockCommandHandler(ITokenService tokenService, UserManager<UserAccount> userManager, IHttpContextAccessor contextAccessor, IUnitOfWork unitOfWork, BlockingCheckerService blockingChecker)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
            _unitOfWork = unitOfWork;
            _blockingChecker = blockingChecker;
        }

        public async Task<IAppResponseDto> Handle(RemoveBlockDto request, CancellationToken cancellationToken)
        {
            string loginUserId = _contextAccessor.HttpContext.GetLoginUserId()!;

            await _blockingChecker.ThrowExceptionIfBlockerAsync(request.BlockedId);

            var blockedUser = await _userManager
                .Users
                .Include(x => x.UsersWhoBlockedTheEntity.Where(x => x.BlockerId == loginUserId))
                .FirstOrDefaultAsync(x => x.Id == request.BlockedId, cancellationToken) ??
                throw new AppException("User was not found", HttpStatusCode.NotFound);

            await _unitOfWork.BeginTransactionAsync(IsolationLevel.ReadUncommitted, cancellationToken);
            blockedUser.RemoveBlock(loginUserId);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            var response = new LoginResponseDto()
            {
                UserId = loginUserId,
                AccessToken = await _tokenService.CreateAccessTokenAsync(loginUserId),
                RefreshToken = await _tokenService.CreateRefreshTokenAsync(loginUserId),
            };
            await _unitOfWork.CommitAsync(cancellationToken);

            return new AppGenericSuccessResponseDto<LoginResponseDto>(response);
        }
    }
}
