﻿namespace ControlaEstoque.Domain.Entities;

public abstract class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
}

