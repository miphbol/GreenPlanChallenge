namespace Vehicle.Repository;

public class VehicleRepository
{
    private List<Vehicle> _vehicleList = new List<Vehicle>();

    // Create

    public void AddVehicleToList(Vehicle car)
    {
        _vehicleList.Add(car);
    }

    // Read

    public List<Vehicle> GetVehicleList()
    {
        return new List<Vehicle>(_vehicleList);
    }

    // Update

    public bool UpdateExistingVehicles(string originalModel, Vehicle newCar)
    {
        Vehicle oldCar = GetVehicleByModel(originalModel);

        if (oldCar != null)
        {
            oldCar.CarMake = newCar.CarMake;
            oldCar.CarModel = newCar.CarModel;
            oldCar.CarYear = newCar.CarYear;

            return true;
        }
        else
        {
            return false;
        }
    }

    // Delete

    public bool RemoveVehicleFromList(string carmodel)
    {
        Vehicle car = GetVehicleByModel(carmodel);

        if (car == null)
        {
            return false;
        }

        int initialCount = _vehicleList.Count;
        _vehicleList.Remove(car);

        if (initialCount > _vehicleList.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



    // Helper method

    public Vehicle GetVehicleByModel(string carmodel)
    {
        foreach (Vehicle car in _vehicleList)
        {
            if (car.CarModel == carmodel)
            {
                return car;
            }
        }

        return null;
    }
}