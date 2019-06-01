using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Template22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // POST api/values/matches
        [HttpPost("matches")]
        public ICollection<string> Matches(string[] possibilities, StringComparison comparisonType)
        {
            var matches = new List<string>();
            foreach (var possibility in possibilities)
            {
                if (string.Equals("match", possibility, comparisonType))
                {
                    matches.Add(possibility);
                }
            }

            return matches;
        }

        // GET api/values
        [HttpGet]
        [Produces("application/json")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values
        [HttpGet("too")]
        [Produces("application/xml")]
        public Model GetToo()
        {
            return new Model
            {
                UserName = User.ToString(),
            };
        }

        // POST api/values
        [Consumes("application/xml")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        public class Model
        {
            public string UserName { get; set; }
        }
    }
}
