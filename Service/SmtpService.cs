﻿
using Application.Entities;
using Application.Interfaces.Services;
using Microsoft.Win32;
using Service.CustomMailMessages;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Service
{
	public class SmtpService : ISmtpService
	{
		private static string Host = "smtp.gmail.com";
		private static int Port = 587;
		private static string MailOfSender = "thenqlv@gmail.com";
		private static string DisplayNameOfSender = "Furkan GULER";
		private static string PasswordOfSender = "cqlknrpcerabqbhp";
		private static MailAddress From = new MailAddress(MailOfSender, DisplayNameOfSender);
		private static NetworkCredential Credential = new NetworkCredential(MailOfSender,PasswordOfSender);

		public void SetSender(string mailOfSender, string passwordOfSender)
		{
			MailOfSender = mailOfSender;
			PasswordOfSender = passwordOfSender;
			From = new MailAddress(MailOfSender, DisplayNameOfSender);
			Credential = new NetworkCredential(MailOfSender, PasswordOfSender);
		}

		private static SmtpClient CreateSmtpClient() {
			SmtpClient sc = new SmtpClient(Host, Port);
			sc.EnableSsl = true;
			sc.UseDefaultCredentials = false;
			sc.Credentials = Credential;
			return sc;
		}
		
		public async Task SendEmailConfirmationMailToUser(User user)
		{
			MailMessage mail = new UserEmailConfirmationMail(user);
			mail.From = From;
			await CreateSmtpClient().SendMailAsync(mail);
		}

		public async Task SendMailtoUserThatCreditHasBeenCreated(User user)
		{
			MailMessage mail = new CreatingCreditMail(user);
			mail.From = From;
			await CreateSmtpClient().SendMailAsync(mail);
		}

	}
}
