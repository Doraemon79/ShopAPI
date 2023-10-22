using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ShopApi.Models
{
    public class ServedIceCream
    {
        public IceCreamTypes Type { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Flavors[] Flavours { get; set; }

       public  ServedIceCream(IceCreamTypes type, Flavors[] flavours)
        {
            Type = type;
            Flavours = flavours;
        }
    }
}
