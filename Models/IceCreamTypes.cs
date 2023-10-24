using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace IcreCreamShop.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IceCreamTypes
    {
        cup,
        cone
     }
}
