﻿namespace SimpleMarket.Core.Models;

public class CartProduct
{
    public long Id { get; set; }

    public long CartId { get; set; }
    public Cart Cart { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }
}