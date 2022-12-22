import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormInputModule } from './form-input/form-input.module';
import { FormEntitySelectorModule } from './form-entity-selector/form-entity-selector.module';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormInputModule,
    FormEntitySelectorModule,
  ],
  exports: [
    FormInputModule,
    FormEntitySelectorModule,
  ]
})
export class FormsModule { }