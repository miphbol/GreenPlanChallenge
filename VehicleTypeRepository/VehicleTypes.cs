namespace Vehicle.Repository;

public class VehicleType
{
    public string CarType { get; set; }

    public List<string> vehicleModel { get; set; }  = new List<string>();

    public VehicleType(){}

    public VehicleType(string cartype)
    {
        CarType = cartype;
    }
}