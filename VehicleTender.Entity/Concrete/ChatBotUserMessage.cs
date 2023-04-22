namespace VehicleTender.Entity.Concrete
{
    public class ChatBotUserMessage : BaseEntity
    {
        public int ChatBotId { get; set; }
        public int UserId { get; set; }
        public string MessageContent { get; set; }

        public ChatBot ChatBot { get; set; }
        public User User { get; set; }
    }
}
