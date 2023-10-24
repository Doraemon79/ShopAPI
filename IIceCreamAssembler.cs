using CSharpFunctionalExtensions;
using IcreCreamShop.Models;

namespace IcreCreamShop
{
    public interface IIceCreamAssembler
    {
         Result<ServedIceCream> GetFinishedIceCream(IceCreamTypes type, string[] flavours);
    }
}
