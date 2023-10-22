using System.ComponentModel.DataAnnotations;

namespace ShopApi
{
    public class Orders
    {
        public int Id { get; set; }
        public string OrderID { get; set; } = default!;
        public bool IsDelivered { get; set; }
        public double Price { get; set; }
    }
}
