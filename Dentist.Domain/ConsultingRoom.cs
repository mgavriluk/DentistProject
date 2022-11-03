namespace Dentist.Domain
{
    public class ConsultingRoom : BaseEntity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string? OfficeNumber { get; set; }

        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<PhoneNumber>? PhoneNumbers { get; set; }
        public virtual ICollection<WorkingTime>? WorkingTimes { get; set; }
    }
}
