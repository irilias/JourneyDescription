using JourneyDescription.Models;
using JourneyDescription.Models.Base;
using JourneyDescription.Services.Descriptions;
using Microsoft.AspNetCore.Mvc;

namespace JourneyDescription.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardingCardsController : ControllerBase
    {
        private readonly ILogger<BoardingCardsController> logger;
        private readonly ISortingService<BoardingPass> sortingService;
        private readonly IFormatterService formatterService;

        public BoardingCardsController(
            ILogger<BoardingCardsController> logger
            , ISortingService<BoardingPass> sortingService
            , IFormatterService formatterService)
        {
            this.logger = logger;
            this.sortingService = sortingService;
            this.formatterService = formatterService;
        }

  
        [HttpPost]
        public IActionResult Sort([FromBody] BoardingPass[] boardingCards)
        {
            boardingCards = boardingCards ?? throw new ArgumentNullException(nameof(boardingCards));
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid Data.");
            }
            string[] result;
            try
            {
                logger.LogInformation($"Sorting boarding pass cards.");
                var sortedBoardingCards = sortingService.Sort(boardingCards);
                result = formatterService.Format(sortedBoardingCards);

            }
            // TODO : Catch custom exceptions and return BadRequest.
            catch (Exception ex)
            {
                logger.LogError($"An error has occured : {ex.Message}.");
                return StatusCode(500, "Internal Server Error.");
            }

            return Ok(result);
        }


    }
}
