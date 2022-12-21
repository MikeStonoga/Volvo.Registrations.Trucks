import { ITruck } from "../itruck.model";

export interface AdjustTruckDTORequirement {
    modelId: string;
}

export interface AdjustTruckDTOResult {
    truck: ITruck
}