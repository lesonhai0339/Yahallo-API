using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace YAHALLO.Infrastructure.Kafka
{
    public sealed class KafkaProducer : IKafkaProducer, IDisposable
    {
        private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

        private readonly KafkaOptions _options;
        private readonly ILogger<KafkaProducer> _logger;
        private readonly IProducer<string, string>? _producer;

        public KafkaProducer(IOptions<KafkaOptions> options, ILogger<KafkaProducer> logger)
        {
            _options = options.Value;
            _logger = logger;

            if (!_options.Enabled)
            {
                return;
            }

            var config = new ProducerConfig
            {
                BootstrapServers = _options.BootstrapServers,
                ClientId = _options.ClientId,
                Acks = ParseAcks(_options.Acks),
                EnableIdempotence = true
            };

            _producer = new ProducerBuilder<string, string>(config).Build();
        }

        public async Task PublishAsync<TMessage>(
            string? topic,
            string key,
            TMessage message,
            CancellationToken cancellationToken = default)
        {
            if (_producer == null)
            {
                _logger.LogDebug("Kafka is disabled. Skipped publishing {MessageType}.", typeof(TMessage).Name);
                return;
            }

            var targetTopic = string.IsNullOrWhiteSpace(topic) ? _options.DefaultTopic : topic;
            var payload = JsonSerializer.Serialize(message, JsonOptions);

            await _producer.ProduceAsync(
                targetTopic,
                new Message<string, string>
                {
                    Key = key,
                    Value = payload
                },
                cancellationToken);
        }

        public void Dispose()
        {
            _producer?.Flush(TimeSpan.FromSeconds(5));
            _producer?.Dispose();
        }

        private static Acks ParseAcks(string value)
        {
            return Enum.TryParse<Acks>(value, ignoreCase: true, out var acks)
                ? acks
                : Confluent.Kafka.Acks.All;
        }
    }
}

