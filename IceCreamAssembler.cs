using CSharpFunctionalExtensions;
using IcreCreamShop.Models;

namespace IcreCreamShop
{
    public class IceCreamAssembler : IIceCreamAssembler
    {


        public Result<ServedIceCream> GetFinishedIceCream(IceCreamTypes type, string[] flavours)
        {

            Flavors[] flavoursTranslated = FlavourTranslator(flavours);
            //IceCreamTypes iceCreamType = (IceCreamTypes)Enum.Parse(typeof(IceCreamTypes), type, true);
            ServedIceCream finalIceCream = new ServedIceCream(type, flavoursTranslated);

            return Result.Success(finalIceCream);
        }

        private Flavors[] FlavourTranslator(string[] flavours)
        {
            var inputString = "SaTurDaY";
            Flavors[] outputFlavours=new Flavors[] {};

            foreach(var el in flavours)
            {
                outputFlavours.Append((Flavors)Enum.Parse(typeof(Flavors), el, true));
            }
            return outputFlavours;
        }
    }
}
