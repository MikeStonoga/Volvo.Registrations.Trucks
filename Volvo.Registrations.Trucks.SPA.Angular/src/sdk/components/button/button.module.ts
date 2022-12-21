import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ButtonComponent } from './button.component';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { IconModule } from '../icon/icon.module';


@NgModule({
  declarations: [
    ButtonComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule,
    IconModule,
    MatTooltipModule,
  ],
  exports: [
    ButtonComponent,
    MatTooltipModule,
  ]
})
export class ButtonModule { }
