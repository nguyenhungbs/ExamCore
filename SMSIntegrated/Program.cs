using System;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace SMSIntegrated
{
    class Program
    {
        static void Main(string[] args)
        {

            const string accountSid = "AC5d7c1f81cf208fc93b7b5a73263404e4";
            const string authToken = "ae0ccd004afceb774893a8ea6ac874d6";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "Join Earth's mightiest heroes. Like Kevin Bacon.",
                from: new Twilio.Types.PhoneNumber("+19723255945"),
                to: new Twilio.Types.PhoneNumber("+84373295037")
            );
            //var acc = Environment.GetEnvironmentVariable("AC5d7c1f81cf208fc93b7b5a73263404e4");
            //var auth = Environment.GetEnvironmentVariable("ae0ccd004afceb774893a8ea6ac874d6");
            //TwilioClient.Init(
            //    Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID"),
            //    Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN_OK"));


            //MessageResource.Create(
            //    to: new PhoneNumber("0373205037"),
            //    from: new PhoneNumber("888888"),
            //    body: "Xin chào, test thành công!");
            Console.WriteLine("ok");
            Console.ReadLine();

        }
    }
}
