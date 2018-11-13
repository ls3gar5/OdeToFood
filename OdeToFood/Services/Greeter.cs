using Microsoft.Extensions.Configuration;

namespace OdeToFood.Services
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
            var tst = _configuration.GetValue<string>("Greeting");
            return _configuration["Greeting"];
        }
    }
}
