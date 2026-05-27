namespace YAHALLO.Infrastructure.Kafka
{
    public class KafkaOptions
    {
        public const string SectionName = "Kafka";

        public bool Enabled { get; set; }
        public string BootstrapServers { get; set; } = "localhost:9092";
        public string ClientId { get; set; } = "yahallo-api";
        public string DefaultTopic { get; set; } = "yahallo.events";
        public string Acks { get; set; } = "All";
    }
}

