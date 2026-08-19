using Microsoft.AspNetCore.Mvc;

namespace PrimeSieve.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrimeSieveController : Controller
    {
        [HttpGet("isprime")]
        public IActionResult IsPrime(int n)
        {
            bool isPrime = PrimeSieveLib.PrimeSieve.IsPrime(n, out bool outOfBounds);
            if (outOfBounds)
                return Content($"Value {n} too high, max allowed is {PrimeSieveLib.PrimeSieve.MAX_PRIME}");

            return Content(isPrime ? "yes" : "no");
        }
    }
}
