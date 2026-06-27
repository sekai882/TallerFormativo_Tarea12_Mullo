import { MemoryDatabase } from "../database/memory";
import { Vehicle } from "../types/vehicle";

/**
 * Service that encapsulates vehicle query and registration operations.
 * Follows the Single Responsibility Principle (SRP) by isolating data-access
 * logic from presentation components, keeping the component layer clean
 * and focused solely on rendering.
 */
export class VehicleService {
  private vehicleStorage = MemoryDatabase.instance;

  all(): Vehicle[]{
    return this.vehicleStorage.vehicles;
  }

  add(newVehicle: Vehicle): void {
    this.vehicleStorage.vehicles.push(newVehicle); 
  }
  
}