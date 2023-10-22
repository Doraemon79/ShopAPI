using CSharpFunctionalExtensions;
using ShopApi.Models;

namespace tutorialCreatWebAPI
{
    public interface IIceCreamAssembler
    {
         Result<ServedIceCream> GetFinishedIceCream(IceCreamTypes type, string[] flavours);
    }
}
