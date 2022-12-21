import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ReadOnlyHttpService } from "../commons/read-only.http.service";
import { ITruck } from "./itruck.model";
import { AdjustTruckDTORequirement, AdjustTruckDTOResult } from "./models/adjust-truck-dto.model";
import { RegisterTruckDTORequirement, RegisterTruckDTOResult } from "./models/register-truck-dto.model";

@Injectable({
    providedIn: 'root'
  })
  export class TrucksHttpService extends ReadOnlyHttpService<ITruck> {
  
    constructor(
      httpClient: HttpClient,
    ) {
      super('Trucks', httpClient)
    }
  
  
    public register(requisito: RegisterTruckDTORequirement): Observable<RegisterTruckDTOResult | HttpErrorResponse> {
      return this.httpClient.post<RegisterTruckDTOResult | HttpErrorResponse>(`${this.baseUrl}/Register`, requisito);
    }
  
    public adjust(requisito: AdjustTruckDTORequirement): Observable<AdjustTruckDTOResult | HttpErrorResponse> {
      return this.httpClient.patch<AdjustTruckDTOResult | HttpErrorResponse>(`${this.baseUrl}/Adjust`, requisito);
    }
  }
  