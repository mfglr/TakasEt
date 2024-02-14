using AuthService.Web.DomainEvents.Models;
using AuthService.Web.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Events;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;
using System.Text;

namespace AuthService.Web.DomainEvents.Handlers
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

            var token64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(token));

            _publisher.Publish(
                new SendEmailConfirmationMailEvent()
                {
                    ReceiverEmail = notification.User.Email!,
                    Token = token64,
                    UserId = notification.User.Id
                },
                Queue.SendEmailConfirmationMail
            );


        }
    }
}
