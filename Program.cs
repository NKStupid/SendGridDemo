using System;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
	        SendMail().Wait();
	        Console.WriteLine("Sent Successfully!!--in the main func");
        }

        static async Task SendMail()
        {
            var apiKey = "";
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("test@example.com", "DXJoseph Team"),
                Subject = "Hello World from the SendGrid CSharp SDK!",
                PlainTextContent = "Hello, Email!",
                HtmlContent = "<strong>Hello, Email!</strong>"
            };
            // msg.AddTo(new EmailAddress("r-arai@nri.co.jp", "Test User"));
            
            msg.AddTo(new EmailAddress("joseph.siyi@gmail.com", "Test User"));
            msg.AddTo(new EmailAddress("chenkiegcp1@gmail.com", "Test User"));
            var response = await client.SendEmailAsync(msg);

	        Console.WriteLine("Sent Successfully!!--in the async func");
	        Console.WriteLine(response.ToString());
        }
    }
}
