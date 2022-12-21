import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TabsComponent } from './tabs.component';
import { MatTabsModule } from '@angular/material/tabs';
import { RouterModule } from '@angular/router';
import { IconModule } from '../icon/icon.module';



@NgModule({
  declarations: [
    TabsComponent
  ],
  imports: [
    CommonModule,
    MatTabsModule,
    RouterModule,
    IconModule,
  ],
  exports: [
    TabsComponent,
  ]
})
export class TabsModule { }
