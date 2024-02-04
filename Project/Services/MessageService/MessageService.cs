using FirebaseAdmin.Messaging;
using Project.Models;

namespace Project.Services.MessageService
{
    public class MessageService : IMessageService
    {
        public async Task SendMessageAsync(MessageRequest request)
        {
            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = request.Title,
                    Body = request.Body,
                },
                Token = request.DeviceToken
            };

            var messaging = FirebaseMessaging.DefaultInstance;
            var result = await messaging.SendAsync(message);


            if (string.IsNullOrEmpty(result))
                throw new Exception("Error sending message.");

        }
    }
}
