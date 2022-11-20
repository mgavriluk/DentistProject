namespace Dentist.Application.App.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }

        public int? DiscountId { get; set; }
    }
}
