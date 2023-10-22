using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace ShopApi.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IceCreamTypes
    {
        cup,
        cone
     }
}
