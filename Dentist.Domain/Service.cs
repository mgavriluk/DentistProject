namespace Dentist.Domain
{
    public class Service : BaseEntity
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int? DiscountId { get; set; }
        public virtual Discount? Discount { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}
