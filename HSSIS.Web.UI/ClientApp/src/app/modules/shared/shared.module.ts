import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeftNavMenuComponent } from './left-nav-menu/left-nav-menu.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { AngularMaterialModule } from 'src/app/angular.material.module';
import { RouterModule } from '@angular/router';
import { PopupHeaderComponent } from './popup-header/popup-header.component';

@NgModule({
  declarations: [
    LeftNavMenuComponent,
    HeaderComponent,
    FooterComponent,
    PopupHeaderComponent
  ],
  imports: [
    CommonModule,
    AngularMaterialModule,
    RouterModule
  ],
  exports:[
    LeftNavMenuComponent,
    HeaderComponent,
    PopupHeaderComponent
  ]
})
export class SharedModule { }
