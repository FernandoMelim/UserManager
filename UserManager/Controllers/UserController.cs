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
        public IEnumerable Get()
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