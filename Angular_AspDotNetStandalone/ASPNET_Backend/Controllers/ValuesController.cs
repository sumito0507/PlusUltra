using ASPNET_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPNET_Backend.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private List<HeroModel> heroes = new List<HeroModel> {
              new HeroModel {Id = 1, Name = "スーパーマン"},
              new HeroModel {Id = 2, Name = "バットマン"},
              new HeroModel {Id = 3, Name = "ウェブマトリクスマン"},
              new HeroModel {Id = 4, Name = "チャッカマン"},
              new HeroModel {Id = 5, Name = "スライムマン"}
          };
        // GET: api/<ValuesController>
        [HttpGet(Name = "GetValues")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        [HttpGet(Name = "GetValues")]
        public string Get(int id)
        {
            Debug.WriteLine("Get");
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            Debug.WriteLine("Post");
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            Debug.WriteLine("Put");
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Debug.WriteLine("Delete");
        }
    }
}
