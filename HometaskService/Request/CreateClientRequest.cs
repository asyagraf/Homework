namespace CarRentalService.Request
{
    public class CreateClientRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Experience { get; set; }
    }
}
