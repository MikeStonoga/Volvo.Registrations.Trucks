import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TruckRegistryComponent } from './truck-registry.component';
import { FormsModule } from 'src/sdk/components/forms/forms.module';
import { ButtonModule } from 'src/sdk/components/button/button.module';
import { FormInputModule } from 'src/sdk/components/forms/form-input/form-input.module';
import { ReactiveFormsModule } from '@angular/forms';
import { TruckModelSelectorModule } from 'src/app/commons/components/trucks/models/selectors/selector/truck-model-selector.module';



@NgModule({
  declarations: [
    TruckRegistryComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    FormInputModule,
    ButtonModule,
    TruckModelSelectorModule,
  ],
  exports: [
    TruckRegistryComponent
  ]
})
export class TruckRegistryModule { }
