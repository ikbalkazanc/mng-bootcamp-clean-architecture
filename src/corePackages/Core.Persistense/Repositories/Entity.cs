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

    public int Id { get; set; }
}