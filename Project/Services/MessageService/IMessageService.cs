using Project.Models;

namespace Project.Services.MessageService
{
    public interface IMessageService
    {
        Task SendMessageAsync(MessageRequest request);
    }
}

