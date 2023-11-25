﻿namespace BookStore.Api.Model;

public class Book
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; } = 0;
}