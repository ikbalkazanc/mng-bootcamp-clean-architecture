using Core.Persistense.Repositories;

namespace Domain.Entities;

public class Model : Entity
{
    public Model()
    {
    }

    public string Name { get; set; }
    public double BailyPrice { get; set; }
    public int ImageUrl { get; set; }
    public int TransmissionId { get; set; }
    public virtual Transmission Transmission { get; set; }
    public int FuelId { get; set; }
    public virtual Fuel Fuel { get; set; }
    public int BrandId { get; set; }
    public virtual Brand Brand { get; set; }
}