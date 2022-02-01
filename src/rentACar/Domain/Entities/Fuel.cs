namespace Domain.Entities;

public class Fuel
{
    public Fuel()
    {
        Models = new HashSet<Model>();
    }
    public string Name { get; set; }
    public ICollection<Model> Models { get; set; }
}