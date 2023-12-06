import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
//import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BaseComponent } from './modules/base/base.component';
import { SharedModule } from './modules/shared/shared.module';
import { AssetCategoryComponent } from './modules/master/asset-category/asset-category.component';
import { AngularMaterialModule } from './angular.material.module';
import { AppRoutingModule } from './app-routing.module';
import { MasterModule } from './modules/master/master.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpErrorInterceptor } from './_helpers/http-error-interceptor';
import { HttpProgressInterceptor } from './_helpers/http-progress-interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    //CounterComponent,
    FetchDataComponent,
    BaseComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,   
    BrowserAnimationsModule, 
    FormsModule,
    MasterModule,
    SharedModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [    
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: HttpProgressInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
