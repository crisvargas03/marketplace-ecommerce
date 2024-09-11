﻿namespace marketplaceAPI.DAL.Models
{
    public class OrderItems : BaseEntity<long>
    {
        public long OrderId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Order Order { get; set; } = new Order();
        public Product Product { get; set; } = new Product();
    }
}
