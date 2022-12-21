import { IBusinessModel } from "../commons/ibusiness-model.model";
import { ITruckModel } from "./models/itruck-model.model";

export interface ITruck extends IBusinessModel {
    modelId: string;
    manufacturingYear: number;
    truckModel: ITruckModel;
}