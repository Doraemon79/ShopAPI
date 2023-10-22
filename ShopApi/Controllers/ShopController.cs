using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using ShopApi.Models;
using System.ComponentModel.DataAnnotations;
using tutorialCreatWebAPI;

namespace ShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ShopController> _logger;
        private readonly IIceCreamAssembler mIceCreamAssembler;

        public ShopController(ILogger<ShopController> logger, IIceCreamAssembler iceCreamAssembler)
        {
            _logger = logger;
            mIceCreamAssembler = iceCreamAssembler;
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
    }
}