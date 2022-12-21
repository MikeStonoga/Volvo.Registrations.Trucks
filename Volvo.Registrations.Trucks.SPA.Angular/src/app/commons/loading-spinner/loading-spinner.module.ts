import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoadingSpinnerComponent } from './loading-spinner.component';
import { SpinnerModule } from 'src/sdk/components/spinner/spinner.module';



@NgModule({
  declarations: [
    LoadingSpinnerComponent
  ],
  imports: [
    CommonModule,
    SpinnerModule,
  ],
  exports: [
    LoadingSpinnerComponent
  ]
})
export class LoadingSpinnerModule { }
