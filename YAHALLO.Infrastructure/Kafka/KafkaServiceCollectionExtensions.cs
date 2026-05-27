using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YAHALLO.Infrastructure.Kafka
{
    public static class KafkaServiceCollectionExtensions
    {
        public static IServiceCollection AddKafka(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<KafkaOptions>(configuration.GetSection(KafkaOptions.SectionName));
            services.AddSingleton<IKafkaProducer, KafkaProducer>();
            return services;
        }
    }
}

