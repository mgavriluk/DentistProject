namespace Dentist.Domain
{
    public class Appointment : BaseEntity
    {
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int ConsultingRoomId { get; set; }
        public virtual ConsultingRoom ConsultingRoom { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
