using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Cimob.Services;

namespace Cimob.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "CIMOB - Confirma��o de Email no registo",
                $"<h1>Bem Vindo ao CIMOB</h1> Ap�s o seu registo, pedimos que confirme o seu email clicando no seguinte link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a> <br> Se n�o se registou no CIMOB, por favor ignore este email.");
        }

        public static Task SendEmail(this IEmailSender emailSender, string descricao)
        {
            return emailSender.SendEmailAsync("marlenecunha14@hotmail.com","Aviso de contacto", descricao);
        }
    }
}
