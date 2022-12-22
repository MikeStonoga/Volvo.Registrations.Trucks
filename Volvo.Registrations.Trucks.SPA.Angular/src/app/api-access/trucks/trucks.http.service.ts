import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ReadOnlyHttpService } from "../commons/read-only.http.service";
import { ITruck } from "./itruck.model";
import { AdjustTruckDTORequirement, AdjustTruckDTOResult } from "./dtos/adjust-truck-dto.model";
import { RegisterTruckDTORequirement, RegisterTruckDTOResult } from "./dtos/register-truck-dto.model";
import { RemoveTruckDTORequirement, RemoveTruckDTOResult } from "./dtos/remove-truck-dto.model";

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

    public remove(requisito: RemoveTruckDTORequirement): Observable<RemoveTruckDTOResult | HttpErrorResponse> {
      return this.httpClient.delete<RemoveTruckDTOResult | HttpErrorResponse>(`${this.baseUrl}/Remove`, { body: requisito });
    }
  
  }
  