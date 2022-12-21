import { IHaveId } from "src/app/commons/components/models/i-have-id.model";

export interface IBusinessModel extends IHaveId {
    creationTime: Date;
    lastModificationTime?: Date;
}