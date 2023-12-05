import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LeftNavMenuComponent } from './left-nav-menu/left-nav-menu.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';



@NgModule({
  declarations: [
    LeftNavMenuComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    LeftNavMenuComponent
  ]
})
export class SharedModule { }
