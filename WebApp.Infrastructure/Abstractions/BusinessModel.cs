namespace WebApp.Infrastructure.Abstractions
{
    public class BusinessModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BusinessType { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
    }
}
