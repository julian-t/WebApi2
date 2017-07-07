using NLog;
using System.Web.Http;

namespace WebApi2.Models
{
    public class PersonController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        [HttpGet]
        [Route("api/People")]
        public IHttpActionResult GetAllPeople()
        {
            return Ok("Result for all people");
        }

        [HttpGet]
        [Route("api/People/{id:int}")]
        public IHttpActionResult GetById(int id)
        {
            if (id < 1 || id > 10)
                return NotFound();
            else
                return Ok("Found person " + id);
        }

        [HttpGet]
        [Route("api/People/{name:alpha}")]
        public IHttpActionResult GetByName(string name)
        {
            return Ok("Name was " + name);
        }
    }
}
