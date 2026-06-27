import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { VehicleService } from "@/lib/services/vehicle";
import { Vehicle } from "@/lib/types/vehicle";

/**
 * Server Component that queries and renders the table of registered vehicles.
 * Because it is a Server Component, data fetching occurs on the server without
 * requiring client-side effects or state management — a clean separation
 * consistent with the Single Responsibility Principle (SRP).
 */
export const VehicleList = async () => {
  async function fetchVehicles(): Promise<Vehicle[]> {
    const vehicleService = new VehicleService();
    return vehicleService.all();
  }

  const fleetList = await fetchVehicles();
  return (
    <Table>
      <TableHeader>
        <TableRow>
          <TableHead>ID</TableHead>
          <TableHead>Brand</TableHead>
          <TableHead>Model</TableHead>
          <TableHead>Year</TableHead>
        </TableRow>
      </TableHeader>
      <TableBody>
        {fleetList.map((vehicleItem) => (
          <TableRow key={vehicleItem.id}>
            <TableCell>{vehicleItem.id}</TableCell>
            <TableCell>{vehicleItem.brand}</TableCell>
            <TableCell>{vehicleItem.model}</TableCell>
            <TableCell>{vehicleItem.year}</TableCell>
          </TableRow>
        ))}
      </TableBody>
    </Table>
  );
};
