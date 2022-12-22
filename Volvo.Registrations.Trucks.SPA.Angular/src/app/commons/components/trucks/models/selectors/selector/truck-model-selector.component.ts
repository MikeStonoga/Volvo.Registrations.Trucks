import { ComponentType } from '@angular/cdk/portal';
import { Component, Input, OnInit } from '@angular/core';
import { TruckModelTableSelectorComponent } from '../table-selector/truck-model-table-selector.component';

@Component({
  selector: 'app-truck-model-selector',
  templateUrl: './truck-model-selector.component.html',
  styleUrls: ['./truck-model-selector.component.scss']
})
export class TruckModelSelectorComponent implements OnInit {
  @Input() label: string = "Model";
  @Input() idControlName: string = "ModelId"
  @Input() nameControlName: string = "TruckModelName";
  @Input() idInitialValue?: string;
  @Input() nameInitialValue?: string;
  
  public get tableSelectorComponentType(): ComponentType<TruckModelTableSelectorComponent> { return TruckModelTableSelectorComponent; }
  constructor() { }

  ngOnInit(): void {
  }

}
