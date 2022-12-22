import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormEntitySelectorComponent } from './form-entity-selector.component';
import { IconModule } from '../../icon/icon.module';
import { MatDialogModule } from '@angular/material/dialog';
import { FormInputModule } from '../form-input/form-input.module';



@NgModule({
  declarations: [
    FormEntitySelectorComponent,
  ],
  imports: [
    CommonModule,
    FormInputModule,
    IconModule,
    MatDialogModule,
  ],
  exports: [
    FormEntitySelectorComponent,
  ]
})
export class FormEntitySelectorModule { }
