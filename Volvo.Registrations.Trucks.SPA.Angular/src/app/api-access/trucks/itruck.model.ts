import { IBusinessModel } from "../commons/ibusiness-model.model";
import { ITruckModel } from "./dtos/itruck-model.model";

export interface ITruck extends IBusinessModel {
    code: string;
    name: string;
    modelId: string;
    manufacturingYear: number;
    truckModel: ITruckModel;
}