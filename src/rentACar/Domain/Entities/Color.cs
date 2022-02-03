﻿using Core.Persistense.Repositories;

namespace Domain.Entities;

public class Color : Entity
{
    public Color()
    {
        Cars = new HashSet<Car>();
    }
    public Color(int id, string name) : this()
    {
        Id = id;
        Name = name;
    }
    public string Name { get; set; }
    public ICollection<Car> Cars { get; set; }
}