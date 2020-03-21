using Backend_ApiNetCore3_1.Application.Interfaces;
using Backend_ApiNetCore3_1.Application.ViewModels;
using Backend_ApiNetCore3_1.Domain.Core;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend_ApiNetCore3_1.Application.Services
{
    public class SendGridAppService : ISendGridAppService
    {

        public async Task<Response> Enviar(SendGridParametersViewModel parameters)
        {
            var client = ConfigureClient();
            var message = GenerateContent(parameters);
            return await client.SendEmailAsync(message);

        }

        private SendGridClient ConfigureClient()
        {

            var apiKey = Settings.SendGridApiKey;
            return new SendGridClient(apiKey);
        }

        private SendGridMessage GenerateContent(SendGridParametersViewModel parameters)
        {

            var from = new EmailAddress(parameters.From, parameters.FromUserName);
            var subject = parameters.Subject;
            var tos = GenerateListOfTos(parameters.Tos);
            var plainTextContent = parameters.PlainTextContent;
            var htmlContent = parameters.HtmlContent;
            var msg = MailHelper.CreateSingleEmailToMultipleRecipients(from, tos, subject, plainTextContent, htmlContent);

            return msg;
        }

        private List<EmailAddress> GenerateListOfTos(List<string> toList)
        {
            List<EmailAddress> tos = new List<EmailAddress>();

            foreach (var to in toList)
            {
                tos.Add(new EmailAddress(to));
            }

            return tos;
        }


    }
}
