using System.ComponentModel.Design;
using System.Runtime.Serialization;
using Vehicle.Repository;

namespace Vehicle_Console;

public class ProgramUI
{
    private VehicleRepository _vehicleRepo = new VehicleRepository();
    private VehicleTypeRepo _typeRepo = new VehicleTypeRepo();

    public void Run()
    {
        SeedVehicleList();
        SeedTypeList();
        Menu();
    }

    // Menu

    private void Menu()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            System.Console.WriteLine("Select a menu option:\n" +
            "1. Add a car to the list of vehicles\n" +
            "2. View all cars\n" +
            "3. Update a car's information\n" +
            "4. Remove a car from the list of vehicles\n" +
            "5. Add a powertrain type\n" +
            "6. View powertrain types\n" +
            "7. Update a powertrain type\n" +
            "8. Delete a powertrain type\n" +
            "9. Add a vehicle to a powertrain type\n" +
            "10. Remove a vehicle from a powertrain type\n" +
            "11. Exit");
        
        
        string input = System.Console.ReadLine();

        switch (input)
        {
            case "1":
            AddVehicleToList();
            break;

            case "2":
            GetVehicleList();
            break;

            case "3":
            UpdateExistingVehicles();
            break;

            case "4":
            RemoveVehicleFromList();
            break;

            case "5":
            AddVehicleTypeToList();
            break;

            case "6":
            GetVehicleTypeList();
            break;

            case "7":
            UpdateExistingTypes();
            break;
        
            case "8":
            RemoveTypeFromList();
            break;

            case "9":
            AddCarToType();
            break;

            case "10":
            RemoveCarFromType();
            break;

            case "11":
            System.Console.WriteLine("Closing application...");
            keepRunning = false;
            break;

            default:
            System.Console.WriteLine("Please enter a valid number.");
            break;
        }

        System.Console.WriteLine("Please press any key to continue...");
        System.Console.ReadKey();
        System.Console.Clear();

        }
    }

        // Create a car
        private void AddVehicleToList()
        {
            System.Console.Clear();
            Vehicle.Repository.Vehicle newCar = CreateNewVehicleObject();
            _vehicleRepo.AddVehicleToList(newCar);
        }

        // Create a powertrain type
        private void AddVehicleTypeToList()
        {
            System.Console.Clear();
            VehicleType newVehicleType = CreateNewTypeObject();
            _typeRepo.AddVehicleTypeToList(newVehicleType);
        }

        // View current car list

        private void GetVehicleList()
        {
            System.Console.Clear();

            List<Vehicle.Repository.Vehicle> listOfVehicles = _vehicleRepo.GetVehicleList();
            foreach (Vehicle.Repository.Vehicle car in listOfVehicles)
            {
                System.Console.WriteLine(
                    $"Make: {car.CarMake}\n" +
                    $"Model: {car.CarModel}\n" +
                    $"Year: {car.CarYear}"
                );
            }
        }

        // View current powertrain type list

        private void GetVehicleTypeList()
        {
            System.Console.Clear();

            List<VehicleType> listOfTypes = _typeRepo.GetVehicleTypeList();
            foreach (VehicleType type in listOfTypes)
            {
                System.Console.WriteLine(
                    $"Type: {type.CarType}"
                );
            }
        }

        // Update vehicle info

        private void  UpdateExistingVehicles()
        {
            GetVehicleList();

            System.Console.WriteLine("Enter the model of vehicle you would like to update:");

            string oldModel = System.Console.ReadLine();
            Vehicle.Repository.Vehicle newCar = CreateNewVehicleObject();

            bool wasUpdated = _vehicleRepo.UpdateExistingVehicles(oldModel, newCar);

            if (wasUpdated)
            {
                System.Console.WriteLine("Vehicle succesfully updated.");
            }
            else
            {
                System.Console.WriteLine("Could not update vehicle.");
            }
        }

        private static Vehicle.Repository.Vehicle CreateNewVehicleObject()
        {
            Vehicle.Repository.Vehicle newCar = new Vehicle.Repository.Vehicle();

            // Make

            System.Console.WriteLine("Enter the make of the vehicle");
            newCar.CarMake = System.Console.ReadLine();

            // Model

            System.Console.WriteLine("Enter the model of the vehicle");
            newCar.CarModel =  System.Console.ReadLine();

            // Year
            System.Console.WriteLine("Enter the year of the vehicle");
            string carYear = System.Console.ReadLine();
            newCar.CarYear = int.Parse(carYear);

            return newCar;
        }

        // Update powertrain types

        private void UpdateExistingTypes()
        {
            GetVehicleTypeList();

            System.Console.WriteLine("Enter the type of powertrain you wish to update:");

            string oldCarType = System.Console.ReadLine();
            VehicleType newType = CreateNewTypeObject();

            bool wasUpdated = _typeRepo.UpdateExistingTypes(oldCarType, newType);

            if (wasUpdated)
            {
                System.Console.WriteLine("Type succesfully updated.");
            }
            else
            {
                System.Console.WriteLine("Could not update type.");
            }
        }

        private static VehicleType CreateNewTypeObject()
        {
            VehicleType newType = new VehicleType();

            // Type
            System.Console.WriteLine("Enter the new powertrain type.");
            System.Console.ReadLine();

            return newType;
        }

        // Remove a car from the list

        private void RemoveVehicleFromList()
        {
            System.Console.Clear();

            GetVehicleList();

            System.Console.WriteLine("Enter the model of the car you wish to delete.");
            string input = System.Console.ReadLine();

            bool wasDeleted = _vehicleRepo.RemoveVehicleFromList(input);

            if (wasDeleted)
            {
                System.Console.WriteLine("The car was successfully deleted.");
            }
            else
            {
                System.Console.WriteLine("Could not remove vehicle.");
            }
        }

        // Remove a powertrain type from the list

        private void RemoveTypeFromList()
        {
            System.Console.Clear();

            GetVehicleTypeList();

            System.Console.WriteLine("Enter the powertrain type you wish to delete.");
            string input = System.Console.ReadLine();

            bool wasDeleted = _typeRepo.RemoveTypeFromList(input);

            if (wasDeleted)
            {
                System.Console.WriteLine("The type was deleted.");
            }
            else
            {
                System.Console.WriteLine("Could not delete type.");
            }
        }

        // Add a car to a powertrain type

        private void AddCarToType()
        {
            System.Console.Clear();

            GetVehicleTypeList();

            System.Console.WriteLine("Please enter the powertrain type the car will be added to.");

            string powertrainType = System.Console.ReadLine();

            GetVehicleList();

            System.Console.WriteLine("Please enter the model of the car you wish to add to a powertrain type.");

            string vehicleModel = System.Console.ReadLine();
            _typeRepo.AddCarToType( powertrainType, vehicleModel);
        }

        // Remove a car from a powertrain type

        private void RemoveCarFromType()
        {
            System.Console.Clear();

            GetVehicleTypeList();

            System.Console.WriteLine("Please enter the powertrain type the car will be removed from.");

            string powertrainType = System.Console.ReadLine();
            var typeToDisplay = _typeRepo.GetTypeByName(powertrainType);

            foreach (string i in typeToDisplay.vehicleModel)
            {
                System.Console.WriteLine(i);
            }

            System.Console.WriteLine("Please enter the model of the car that will be removed from the powertrain.");

            string vehicleModel = System.Console.ReadLine();
            _typeRepo.RemoveCarFromType(powertrainType, vehicleModel);
        }

        // Seed information

        private void SeedVehicleList()
        {
            Vehicle.Repository.Vehicle mustang = new Vehicle.Repository.Vehicle("Ford", "Mustang", 1968);
            Vehicle.Repository.Vehicle prius = new Vehicle.Repository.Vehicle("Toyota", "Prius", 2023);
            Vehicle.Repository.Vehicle plaid = new Vehicle.Repository.Vehicle("Tesla", "Plaid", 2022);

            _vehicleRepo.AddVehicleToList(mustang);
            _vehicleRepo.AddVehicleToList(prius);
            _vehicleRepo.AddVehicleToList(plaid);
        }

        private void SeedTypeList()
        {
            VehicleType gas = new VehicleType("Gas");
            VehicleType hybrid = new VehicleType("Hybrid");
            VehicleType electric = new VehicleType("Electric");

            _typeRepo.AddVehicleTypeToList(gas);
            _typeRepo.AddVehicleTypeToList(hybrid);
            _typeRepo.AddVehicleTypeToList(electric);
        }

}



