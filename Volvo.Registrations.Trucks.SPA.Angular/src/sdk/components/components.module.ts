import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IconModule } from './icon/icon.module';
import { SpinnerModule } from './spinner/spinner.module';
import { TabsModule } from './tabs/tabs.module';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from './button/button.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    TabsModule,
    IconModule,
    FormsModule,
    ButtonModule,
    SpinnerModule,
  ],
  exports: [
    TabsModule,
    IconModule,
    FormsModule,
    ButtonModule,
    SpinnerModule,
  ]
})
export class ComponentsModule { }
