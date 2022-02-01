﻿using Core.Persistense.Repositories;

namespace Domain.Entities;

public class Car : Entity
{
    public int ColorId { get; set; }
    public virtual Color Color { get; set; }
    public int ModelId { get; set; }
    public virtual Model Model { get; set; }
    public short ModelYear { get; set; }
    public string Plate{ get; set; }
}