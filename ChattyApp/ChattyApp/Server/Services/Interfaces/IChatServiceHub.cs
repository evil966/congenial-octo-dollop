namespace ChattyApp.Server.Services.Interfaces
{
    public interface IChatServiceHub
    {
        Task SendMessage(string user, string message);
    }
}
