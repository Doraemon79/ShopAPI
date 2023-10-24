using CSharpFunctionalExtensions;
using IcreCreamShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace IcreCreamShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IIceCreamAssembler mIceCreamAssembler;

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IIceCreamAssembler mIceCreamAssembler)
        {
            _logger = logger;
            this.mIceCreamAssembler = mIceCreamAssembler;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<IceCreamShop> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new IceCreamShop
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }



        [HttpGet(Name = "GetIceCream")]
        [ProducesResponseType(typeof(ServedIceCream), StatusCodes.Status200OK)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetIceCream(
        [Required(AllowEmptyStrings = false)] IceCreamTypes ContainerType,
        [Required(AllowEmptyStrings = false)] string flavours)
        {
            string[] inputFlavours = flavours.Split(',').Select(sValue => sValue.Trim()).ToArray();

            Result<ServedIceCream> finalIceCream = mIceCreamAssembler.GetFinishedIceCream(ContainerType, inputFlavours);
            return finalIceCream.IsSuccess
                ? Ok(finalIceCream.Value) :
                NotFound("object not found");
        }

//        [HttpPost(Name = "AddIceCreamOrder")]
//        [ProducesResponseType(typeof(ServedIceCream), StatusCodes.Status200OK)]
//        [ProducesResponseType(404)]
//        public async Task<ActionResult> AddIceCreamOrder(
//        [Required(AllowEmptyStrings = false)] IceCreamTypes ContainerType,
//        [Required(AllowEmptyStrings = false)] string flavours)
//        {
//            string[] inputFlavours = flavours.Split(',').Select(sValue => sValue.Trim()).ToArray();

//            Result<ServedIceCream> finalIceCream = mIceCreamAssembler.AddOrder(ContainerType, inputFlavours);
//            return finalIceCream.IsSuccess
//                ? Ok(finalIceCream.Value) :
//                NotFound("object not found");
//        }

//        [HttpDelete(Name = "DeleteIceCreamOrder")]
//        [ProducesResponseType(typeof(ServedIceCream), StatusCodes.Status200OK)]
//        [ProducesResponseType(404)]
//        public async Task<ActionResult> DeleteIceCreamOrder(
//[Required(AllowEmptyStrings = false)] IceCreamTypes ContainerType,
//[Required(AllowEmptyStrings = false)] string flavours)
//        {
//            string[] inputFlavours = flavours.Split(',').Select(sValue => sValue.Trim()).ToArray();

//            Result<ServedIceCream> finalIceCream = mIceCreamAssembler.DeleteOrder(ContainerType, inputFlavours);
//            return finalIceCream.IsSuccess
//                ? Ok(finalIceCream.Value) :
//                NotFound("object not found");
//        }
    }
}