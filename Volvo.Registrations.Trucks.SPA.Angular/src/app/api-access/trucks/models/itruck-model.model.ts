import { IBusinessModel } from "../../commons/ibusiness-model.model";

export interface ITruckModel extends IBusinessModel {
    name: string;
    year: number;
}