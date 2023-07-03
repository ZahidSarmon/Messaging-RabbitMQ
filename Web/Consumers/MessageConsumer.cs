using Contracts.Message;
using MassTransit;

namespace Web.Consumers;

public class MessageConsumer : IConsumer<MessageDTO>
{
    ILogger<MessageConsumer> _logger;
    public MessageConsumer(ILogger<MessageConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<MessageDTO> context)
    {
        _logger.LogInformation($"Received : {nameof(MessageDTO)}");

        _logger.LogInformation($"id:{context.Message.Id} and message:{context.Message.Message}");

        await Task.CompletedTask;
    }
}
