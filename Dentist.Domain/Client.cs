namespace Dentist.Domain
{
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        public int? DiscountId { get; set; }
        public virtual Discount? Discount { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}
