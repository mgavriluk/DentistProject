namespace Dentist.Domain
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Service>? Services { get; set; }
        public ICollection<Client>? Clients { get; set; }    
    }
}
