using System;

namespace cars_api_example.Models
{
    public class CarItem
    {
        public long Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public bool IsInStock { get; set; }
    }


}
