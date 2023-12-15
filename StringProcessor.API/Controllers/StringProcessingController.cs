using Microsoft.AspNetCore.Mvc;
using StringProcessor.Domain;

namespace StringProcessor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StringProcessingController : ControllerBase
    {
        private readonly IStringProcessor _stringProcessor;

        public StringProcessingController(IStringProcessor stringProcessor)
        {
            _stringProcessor = stringProcessor;
        }

        [HttpGet]
        public ActionResult<string> Get(string input)
        {
            return _stringProcessor.Process(input);
        }
    }
}
