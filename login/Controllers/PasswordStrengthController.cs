using entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Zxcvbn;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordStrengthController : ControllerBase
    {
        IPasswordStrengthService _passwordStrengthService;
        public PasswordStrengthController(IPasswordStrengthService passwordStrengthService) {
            _passwordStrengthService = passwordStrengthService;
        }


        // GET: api/<CategoriesController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] string password)
        {
            return Ok(_passwordStrengthService.passwordScore(password));
        }

    }
}
