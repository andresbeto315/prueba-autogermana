﻿using Domain.Entities;

namespace Domain.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public CategoryEntity Category { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public object Image { get; set; }
        public bool State { get; set; }
    }
}