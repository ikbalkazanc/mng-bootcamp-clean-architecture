using Core.Persistense.Repositories;

namespace Domain.Entities;

public class Color : Entity
{
    public Color()
    {
        Cars = new HashSet<Car>();
    }
    public string Name { get; set; }
    public ICollection<Car> Cars { get; set; }
}