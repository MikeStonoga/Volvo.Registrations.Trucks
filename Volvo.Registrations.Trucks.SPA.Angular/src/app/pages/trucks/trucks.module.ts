import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrucksComponent } from './trucks.component';
import { RouterModule, Routes } from '@angular/router';
import { TabsModule } from 'src/sdk/components/tabs/tabs.module';
import { TrucksListModule } from './list/trucks-list.module';
import { TrucksListComponent } from './list/trucks-list.component';

const routes: Routes = [
  { path: '', redirectTo: 'info', pathMatch: 'full' },
  {
    path: 'info', component: TrucksComponent,
    children: [
      { path: '', redirectTo: 'list', pathMatch: 'full' },
      { path: 'list', component: TrucksListComponent },
      {
      //   path: 'registry', children: [
      //     { path: '', redirectTo: 'new', pathMatch: 'full' },
      //     { path: 'new', component: TrucksRegistrationComponent },
      //     { path: ':id', component: PessoasRegistrationComponent },
      //   ]
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
    TrucksListModule,
  ],
  exports: [RouterModule]
})
export class TrucksModule { }
