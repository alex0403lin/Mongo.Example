using Data.Models;

namespace WebAPI.Models
{
    public class OrderEditViewModel
    {
        public string Id { get; set; }
        public string OrderNumber { get; set; }
        public List<OrderItem> Products { get; set; }
    }
}