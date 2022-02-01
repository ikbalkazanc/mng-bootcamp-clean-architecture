using Core.Persistense.Repositories;

namespace Domain.Entities;

public class Transmission : Entity
{
    public Transmission()
    {
        Models = new HashSet<Model>();
    }
    public string Name { get; set; }
    public ICollection<Model> Models { get; set; }
}