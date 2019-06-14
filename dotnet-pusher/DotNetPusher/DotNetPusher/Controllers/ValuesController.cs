using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PusherServer;

namespace DotNetPusher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Pusher _pusher;

        public ValuesController()
        {
            var options = new PusherOptions
            {
                Cluster = "us2",
                Encrypted = true
            };

            _pusher = new Pusher(
                "804048",
                "6d039c28c516b925cfae",
                "e349461f252fc4aea847",
                options);
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
           await _pusher.TriggerAsync(
                "jiraya",
                "message",
                new { message = "hello world" });

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
