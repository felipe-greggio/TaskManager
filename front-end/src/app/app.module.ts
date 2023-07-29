import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavigationModule } from "./modules/navigation/navigation.module";
import { SharedModule } from "./shared/shared.module";
import { MixedCdkDragDropModule } from 'angular-mixed-cdk-drag-drop';


MixedCdkDragDropModule.forRoot({ autoScrollStep: 4 });
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NavigationModule,
    SharedModule,
    MixedCdkDragDropModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
