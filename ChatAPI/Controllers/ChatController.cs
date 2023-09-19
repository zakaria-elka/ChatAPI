using ChatAPI.Dtos;
using Microsoft.AspNetCore.Mvc;
using PusherServer;
using System.Net;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ChatAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class ChatController : Controller
    {
        [HttpPost("messages")]
        public async Task<ActionResult> Message(MessageDto dto )
        {
            var options = new PusherOptions
            {
                Cluster = "eu",
                Encrypted = true
            };

            var pusher = new Pusher(
       "1673010",
       "2b33e5b65cdbdcfca5b9",
       "14a39cbbc9080960246c",
       options);

            await pusher.TriggerAsync(
              "chat",
              "message",
              new { 
                  
                  sender=dto.sender,
                  receiver=dto.receiver,
                  message = dto.message
              
              }
              );

            return Ok(new string[] { "message envoyée" });
        
        }

       

    }
}
