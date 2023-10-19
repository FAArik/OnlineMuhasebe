using Newtonsoft.Json;
using OnlineMuhasebeServer.Application.Services;
using OnlineMuhasebeServer.Domain.Dtos;
using RabbitMQ.Client;
using System.Text;

namespace OnlineMuhasebeServer.Infrastructure.Services;

public sealed class RabbitMQService : IRabbitMQService
{
    public void SendQueue(ReportDto reportDto)
    {
        var factory = new ConnectionFactory();
        factory.Uri = new Uri("amqps://ytudmobq:Qn8kAlEK0p0Y-omldVZw0ZXzoYY0SR7a@sparrow.rmq.cloudamqp.com/ytudmobq");

        using var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        channel.QueueDeclare("Reports", true, false, false);
        var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(reportDto));
        channel.BasicPublish(string.Empty, "Reports", null, body);
    }
}
