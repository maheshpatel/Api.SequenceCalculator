using Api.SequenceCalculator.Service;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.SequenceCalculator.Controllers
{
    [EnableCors("http://localhost:4200","*","*")]
    public class SequenceCalculatorController : ApiController
    {
        private readonly ISequenceCalculatorService _sequenceCalculator;
        public SequenceCalculatorController(ISequenceCalculatorService sequenceCalculator)
        {
            _sequenceCalculator = sequenceCalculator;
        }

        [Route("v1/sequence/{number}"), HttpGet]
        public IHttpActionResult CalculateSequence(int number)
        {
            if (number <= 0)
                return BadRequest();

            var result = _sequenceCalculator.CalculateSequence(number);

            return Ok(result);
        }
    }
}