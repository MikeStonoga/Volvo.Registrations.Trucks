import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrucksListComponent } from './trucks-list.component';
import { TableModule } from 'src/sdk/components/table/table.module';
import { ButtonModule } from 'src/sdk/components/button/button.module';



@NgModule({
  declarations: [
    TrucksListComponent
  ],
  imports: [
    CommonModule,
    TableModule,
    ButtonModule,
  ]
})
export class TrucksListModule { }
