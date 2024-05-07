namespace Vehicle.Repository;

public class Vehicle
{
    public string CarMake { get; set; }
    public string CarModel { get; set; }
    public int CarYear { get; set; }



    public Vehicle() {}

    public Vehicle(string carmake, string carmodel, int caryear)
    {
        CarMake = carmake;
        CarModel = carmodel;
        CarYear = caryear;
    }
}