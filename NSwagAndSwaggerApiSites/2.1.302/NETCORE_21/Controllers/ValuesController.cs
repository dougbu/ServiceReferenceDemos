using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace NETCORE_21.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
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

        // POST api/values
        [Consumes("application/json", "text/json")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
