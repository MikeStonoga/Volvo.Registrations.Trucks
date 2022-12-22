import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home.module.routing';
import {MatCardModule} from '@angular/material/card';
import { IconModule } from 'src/sdk/components/icon/icon.module';
import {  MatTooltipModule } from '@angular/material/tooltip';

@NgModule({
  declarations: [
    HomeComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    MatCardModule,
    IconModule,
    MatTooltipModule,
  ],
  exports: [
    HomeRoutingModule,
  ]
})
export class HomeModule { }
