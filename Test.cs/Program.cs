

using Application.Entities;
using Service;

await new SmtpService().SendEmailToUserThatAccountHasBeenCreated(new User("muhammet.furkan.guler@alphastellar.io", "thenqlv"));