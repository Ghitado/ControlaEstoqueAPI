﻿namespace ControlaEstoque.API.Models;
public abstract class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
}

