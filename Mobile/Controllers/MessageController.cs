using Contracts.Message;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Mobile.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IBus _bus;
    public MessageController(IBus bus)
    {
        _bus = bus;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] string message)
    {
        int id = Random.Shared.Next(1,99);

        await _bus.Publish(new MessageDTO(id,message));

        return Ok(new {id,message});
    }
}
