using AuthService.Api.DomainEvents.Models;
using AuthService.Api.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Events;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;

namespace AuthService.Api.DomainEvents.Handlers
{
    public class OnUserCreatedByEmail_SendEmailConfirmaionMailEventHandler : INotificationHandler<UserCreatedByEmailEvent>
    {
        private readonly UserManager<User> _userManager;
        private readonly AppEventsPublisher _publisher;

        public OnUserCreatedByEmail_SendEmailConfirmaionMailEventHandler(UserManager<User> userManager, AppEventsPublisher publisher)
        {
            _userManager = userManager;
            _publisher = publisher;
        }

        public async Task Handle(UserCreatedByEmailEvent notification, CancellationToken cancellationToken)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(notification.User);
            _publisher.Publish(
                new SendEmailConfirmationMailEvent()
                {
                    ReceiverEmail = notification.User.Email!,
                    Token = token,
                    UserId = notification.User.Id
                },
                Queue.SendEmailConfirmationMail
            );


        }
    }
}
