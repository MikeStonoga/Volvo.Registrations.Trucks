import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IconComponent } from './icon.component';
import { MatIconModule } from '@angular/material/icon';



@NgModule({
  declarations: [
    IconComponent
  ],
  imports: [
    CommonModule,
    MatIconModule,
  ],
  exports: [
    MatIconModule,
    IconComponent,
  ]
})
export class IconModule { }