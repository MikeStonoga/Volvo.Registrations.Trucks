import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TruckModelSelectorComponent } from './truck-model-selector.component';
import { FormEntitySelectorModule } from 'src/sdk/components/forms/form-entity-selector/form-entity-selector.module';



@NgModule({
  declarations: [
    TruckModelSelectorComponent
  ],
  imports: [
    CommonModule,
    FormEntitySelectorModule,
  ],
  exports: [
    TruckModelSelectorComponent
  ]
})
export class TruckModelSelectorModule { }
