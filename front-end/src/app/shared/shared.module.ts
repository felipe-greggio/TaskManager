import { NgModule } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { InputTextModule } from 'primeng/inputtext';
import { HttpClientModule } from '@angular/common/http';

const MaterialComponents = [
  MatButtonModule
]

const PrimeComponents = [
  ButtonModule,
  CardModule,
  MessagesModule,
  MessageModule,
  InputTextModule
]

@NgModule({
  imports: [
    MaterialComponents,
    PrimeComponents,
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports: [
    MaterialComponents,
    PrimeComponents,
    ReactiveFormsModule
  ]
})
export class SharedModule { }
