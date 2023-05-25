import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from "./menu/menu.component";

import { NavigationRoutingModule } from './navigation-routing.module';
import { LoginComponent } from './login/login.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    MenuComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    NavigationRoutingModule,
    SharedModule
  ]
})
export class NavigationModule { }
