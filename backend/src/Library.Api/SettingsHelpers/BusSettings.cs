namespace Library.Api.SettingsHelpers
{
    public class BusSettings
    {
        public required string Host { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string MoreProcessingQueueName { get; set; }
    }
}
