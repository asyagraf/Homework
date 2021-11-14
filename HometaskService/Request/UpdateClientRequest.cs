namespace CarRentalService.Request
{
    public class UpdateClientRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Experience { get; set; }
    }
}
