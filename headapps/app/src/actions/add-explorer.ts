"use server";

import { VehicleService } from "@/lib/services/vehicle";
import { Vehicle } from "@/lib/types/vehicle";
import { v4 as uuid } from "uuid";
import { revalidatePath } from "next/cache";

/**
 * Server Action that adds a new Ford Explorer vehicle from the Next.js
 * frontend interface, delegating persistence to the centralized VehicleService.
 */
export async function addExplorer() {
 // Instantiate the service and register a new vehicle with a unique identifier
 const vehicleService = new VehicleService();
 vehicleService.add({
   id: uuid(),
   brand: "Ford",
   model: "Explorer",
   year: 2025
  } as Vehicle);
  
  // Invalidate the root path cache to reflect the change immediately
  revalidatePath("/");
}
