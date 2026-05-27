namespace YAHALLO.Infrastructure.Kafka
{
    public interface IKafkaProducer
    {
        Task PublishAsync<TMessage>(
            string? topic,
            string key,
            TMessage message,
            CancellationToken cancellationToken = default);
    }
}

