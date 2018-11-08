using Microsoft.Extensions.Configuration;

namespace OdeToFood
{
    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration congigutarion)
        {
            //I can read appsettings.json
            _configuration = congigutarion;
        }

        public string GetMessageOfTheDay()
        {
            return _configuration["Greeting"];
        }
    }
}
