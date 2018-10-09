using Microsoft.Extensions.Configuration;

namespace OdeToFood
{
    public interface IGreeter
    {
        string GetMessageOfTheDay();
    }


    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration congigutarion)
        {
            _configuration = congigutarion;
        }

        public string GetMessageOfTheDay()
        {
            return _configuration["Greeting"];
        }
    }
}