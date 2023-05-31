import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from "./menu/menu.component";

import { NavigationRoutingModule } from './navigation-routing.module';
import { LoginComponent } from './login/login.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MainLayoutComponent } from './main-layout/main-layout.component';


@NgModule({
  declarations: [
    MenuComponent,
    LoginComponent,
    MainLayoutComponent
  ],
  imports: [
    CommonModule,
    NavigationRoutingModule,
    SharedModule
  ],
  exports: [MenuComponent]
})
export class NavigationModule {

 }
