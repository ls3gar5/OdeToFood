using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("about")]
    //[Route("{controller}/{action}")]
    public class AboutController
    {
        [Route("")] //that indeicates that is the default method to execute
        public string Phone()
        {
            return "1+5555+5555";
        }

       [Route("address")]
        public string Address()
        {
            return "Pje Curie 2668";
        }
    }
}
