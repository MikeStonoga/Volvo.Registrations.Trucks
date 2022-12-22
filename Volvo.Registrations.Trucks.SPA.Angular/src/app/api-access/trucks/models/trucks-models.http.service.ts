import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ReadOnlyHttpService } from "../../commons/read-only.http.service";
import { ITruckModel } from "../dtos/itruck-model.model";

@Injectable({
    providedIn: 'root'
  })
  export class TrucksModelsHttpService extends ReadOnlyHttpService<ITruckModel> {
  
    constructor(
      httpClient: HttpClient,
    ) {
      super('TrucksModels', httpClient)
    }
  }
  