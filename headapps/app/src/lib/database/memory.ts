import { Vehicle } from "../types/vehicle";

/**
 * Singleton pattern implementation adapted for the Next.js server runtime.
 * MemoryDatabase retains vehicles in memory for the entire lifetime of the server process.
 * The singleton reference is stored on `globalThis` so that it survives Hot Module
 * Replacement (HMR) reloads during development, preventing data loss between edits.
 */
export class MemoryDatabase {
  vehicles: Vehicle[] = [];
  
  private constructor() {
    this.vehicles = [];
  }

  static get instance() {
    // Store the reference in the global scope to persist across module reloads
    const globalRef = globalThis as any;
    if (!globalRef._memoryDatabaseInstance) {
      globalRef._memoryDatabaseInstance = new MemoryDatabase();
    }
    return globalRef._memoryDatabaseInstance;
  }
}

// Export the single shared instance of the in-memory vehicle storage
export const memoryDatabase = MemoryDatabase.instance;