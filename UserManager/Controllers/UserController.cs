using Microsoft.AspNetCore.Mvc;

namespace UserManager.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

        [HttpGet]
        [Route("/{id}")]
        public IEnumerable Get()
        {
        }

        [HttpGet]
        public IEnumerable GetAll()
        {
        }

        [HttpPost]
        public IEnumerable Post()
        {
        }

        [HttpDelete]
        public IEnumerable Delete()
        {
        }

        [HttpPatch]
        public IEnumerable Patch()
        {
        }
    }
}