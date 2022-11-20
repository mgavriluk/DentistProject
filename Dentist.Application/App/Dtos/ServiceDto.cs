using Dentist.Domain;

namespace Dentist.Application.App.Dtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int? DiscountId { get; set; }
    }
}
