﻿namespace SharedGarden.Web.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool IsDeleted { get; set; }
        public GardenModel Garden { get; set; }
    }
}
