import { IBusinessModel } from "src/app/api-access/commons/ibusiness-model.model";

export interface ITruckModel extends IBusinessModel {
    year: number;
    name: string;
}