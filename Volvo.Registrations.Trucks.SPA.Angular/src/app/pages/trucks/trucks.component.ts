import { Component, OnInit } from '@angular/core';
import { ITruck } from 'src/app/api-access/trucks/itruck.model';
import { TabbedComponent } from 'src/app/commons/components/models/tabbed.component.model';
import { TrucksService } from './trucks.service';

@Component({
  selector: 'app-trucks',
  templateUrl: './trucks.component.html',
  styleUrls: ['./trucks.component.scss']
})
export class TrucksComponent extends TabbedComponent<ITruck, TrucksService> {
  constructor(
    service: TrucksService,
  ) {
    super(service);
  }
}
