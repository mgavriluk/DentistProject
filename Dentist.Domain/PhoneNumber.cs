namespace Dentist.Domain
{
    public class PhoneNumber : BaseEntity
    {
        public int ConsultingRoomId { get; set; }
        public string Number { get; set; }

        public virtual ConsultingRoom? ConsultingRoom { get; set; }
    }
}
