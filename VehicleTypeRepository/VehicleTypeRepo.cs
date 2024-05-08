namespace Vehicle.Repository;

public class VehicleTypeRepo
{
    private List<VehicleType> _listOfVehicleTypes = new List<VehicleType>();

    // Create

    public void AddVehicleTypeToList(VehicleType type)
    {
        _listOfVehicleTypes.Add(type);
    }

    public void AddCarToType(string vehicleFuelType, string carType )
    {
        foreach (VehicleType vehicleType in _listOfVehicleTypes)
        {
            if (vehicleType.CarType == vehicleFuelType)
            {
                vehicleType.vehicleModel.Add(carType);
            }
        }
    }

    // Read

    public List<VehicleType> GetVehicleTypeList()
    {
        return new List<VehicleType>(_listOfVehicleTypes);
    }

    // Update

    public bool UpdateExistingTypes(string originalVehicleType, VehicleType newVehicleType)
    {
        VehicleType oldType = GetTypeByName(originalVehicleType);

        if (oldType != null)
        {
            oldType.CarType = newVehicleType.CarType;

            return true;
        }
        else
        {
            return false;
        }
    }


    // Delete

    public bool RemoveTypeFromList(string cartype)
    {
        VehicleType type = GetTypeByName(cartype);

        if (type == null)
        {
            return false;
        }

        int initialCount = _listOfVehicleTypes.Count;
        _listOfVehicleTypes.Remove(type);

        if (initialCount > _listOfVehicleTypes.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void RemoveCarFromType(string vehicleFuelType, string carType )
    {
        foreach (VehicleType vehicleType in _listOfVehicleTypes)
        {
            if (vehicleType.CarType == vehicleFuelType)
            {
                vehicleType.vehicleModel.Remove(carType);
            }
        }
    }

    // Helper methods

    public VehicleType GetTypeByName(string cartype)
    {
        foreach (VehicleType type in _listOfVehicleTypes)
        {
            if (type.CarType.ToLower() == cartype.ToLower())
            {
                return type;
            }
        }

        return null;
    }
}

