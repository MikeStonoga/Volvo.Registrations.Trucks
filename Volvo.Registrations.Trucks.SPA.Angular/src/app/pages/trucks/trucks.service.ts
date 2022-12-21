import { Injectable } from '@angular/core';
import { ITruck } from 'src/app/api-access/trucks/itruck.model';
import { TabbedService } from 'src/app/commons/components/models/tabbed.service.model';

@Injectable({
  providedIn: 'root'
})
export class TrucksService extends TabbedService<ITruck> {
}
