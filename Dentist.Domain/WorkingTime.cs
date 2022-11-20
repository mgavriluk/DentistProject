namespace Dentist.Domain
{
    public class WorkingTime: BaseEntity
    {
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public int ConsultingRoomId { get; set; }
        public ConsultingRoom ConsultingRoom { get; set; }
    }
}
