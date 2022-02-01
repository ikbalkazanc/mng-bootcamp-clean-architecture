using Core.Persistense.Repositories;

namespace Domain.Entities;

public class Brand : Entity
{
    public Brand()
    {
        Models = new HashSet<Model>();
    }

    public Brand(int id) : this()
    {
    }

    public string Name { get; set; }
    public virtual ICollection<Model> Models { get; set; }
}