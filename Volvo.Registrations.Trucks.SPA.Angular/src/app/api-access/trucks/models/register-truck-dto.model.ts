import { ITruck } from "../itruck.model";

export interface RegisterTruckDTORequirement {
    modelId: string;
}

export interface RegisterTruckDTOResult {
    truck: ITruck;
}
