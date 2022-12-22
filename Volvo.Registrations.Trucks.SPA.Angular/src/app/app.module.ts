import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { LoadingInterceptor } from './commons/interceptors/loading.http.interceptor';
import { MenuComponent } from './menu/menu.component';
import { ComponentsModule } from 'src/sdk/components/components.module';
import { IconModule } from 'src/sdk/components/icon/icon.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { LoadingSpinnerModule } from './commons/loading-spinner/loading-spinner.module';
import { SdkModule } from 'src/sdk/sdk.module';
import { MatSidenavModule } from '@angular/material/sidenav';
import { PagesModule } from './pages/pages.module';
import { MatIconModule } from '@angular/material/icon';
import { TrucksHttpService } from './api-access/trucks/trucks.http.service';
import { FormInputModule } from 'src/sdk/components/forms/form-input/form-input.module';
import { ButtonModule } from 'src/sdk/components/button/button.module';
import { TruckModelTableSelectorComponent } from './commons/components/trucks/models/selectors/table-selector/truck-model-table-selector.component';
import { TrucksModelsHttpService } from './api-access/trucks/models/trucks-models.http.service';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    TruckModelTableSelectorComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTabsModule,
    PagesModule,
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    FormInputModule,
    ButtonModule,
    IconModule,
    SdkModule,
    LoadingSpinnerModule,
    ComponentsModule,
  ],
  providers: [
    TrucksHttpService,
    TrucksModelsHttpService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoadingInterceptor,
      multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
