import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrucksComponent } from './trucks.component';
import { RouterModule, Routes } from '@angular/router';
import { TabsModule } from 'src/sdk/components/tabs/tabs.module';
import { TrucksListModule } from './list/trucks-list.module';
import { TrucksListComponent } from './list/trucks-list.component';
import { TruckRegistryComponent } from './registry/truck-registry.component';
import { ButtonModule } from 'src/sdk/components/button/button.module';
import { FormInputModule } from 'src/sdk/components/forms/form-input/form-input.module';
import { TruckRegistryModule } from './registry/truck-registry.module';

const routes: Routes = [
  { path: '', redirectTo: 'info', pathMatch: 'full' },
  {
    path: 'info', component: TrucksComponent,
    children: [
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'list', component: TrucksListComponent },
      {
        path: 'registration', children: [
          { path: '', redirectTo: 'new', pathMatch: 'full' },
          { path: 'new', component: TruckRegistryComponent },
          { path: ':id', component: TruckRegistryComponent },
        ]
      },
    ]
  }
];


@NgModule({
  declarations: [
    TrucksComponent,
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    TabsModule,
    ButtonModule,
    FormInputModule,
    TrucksListModule,
    TruckRegistryModule,
  ],
  exports: [RouterModule]
})
export class TrucksModule { }
