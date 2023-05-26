using Bloggy.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Bloggy.AuthAPI.Controllers
{
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(Response<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
        }
    }
}
