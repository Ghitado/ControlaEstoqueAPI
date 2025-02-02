﻿using System.Text.Json.Serialization;

namespace ControlaEstoque.Application.DTOs;
public class ProductDTO
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ushort Stock { get; set; }
}
