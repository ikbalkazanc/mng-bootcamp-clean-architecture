using System.ComponentModel.DataAnnotations;

namespace Core.Persistense.Repositories;

public class Entity
{
    public Entity()
    {
    }

    public Entity(int id)
    {
        Id = id;
    }
    [Key]
    public int Id { get; set; }
}