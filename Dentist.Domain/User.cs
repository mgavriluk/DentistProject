namespace Dentist.Domain
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }

        public Client Client { get; set; }
    }
}
