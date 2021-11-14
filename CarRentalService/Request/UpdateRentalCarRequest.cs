namespace CarRentalService.Request
{
    public class UpdateRentalCarRequest
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool IsAvailable { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public int? ClientId { get; set; }
    }
}
