import { NgModule } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { MessagesModule } from 'primeng/messages';
import { MessageModule } from 'primeng/message';
import { InputTextModule } from 'primeng/inputtext';
import { HttpClientModule } from '@angular/common/http';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatDialogModule} from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import {MatCardModule} from '@angular/material/card';
import {MatSelectModule} from '@angular/material/select';
import { ProjectStatusPipe } from './Utils/project-status.pipe';
import { MixedCdkDragDropModule } from 'angular-mixed-cdk-drag-drop';
import {DragDropModule} from '@angular/cdk/drag-drop';

const MaterialComponents = [
  MatButtonModule,
  MatSidenavModule,
  MatListModule,
  MatToolbarModule,
  MatIconModule,
  MatDialogModule,
  MatInputModule,
  MatFormFieldModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatCardModule,
  MatSelectModule,
  DragDropModule
]

const PrimeComponents = [
  ButtonModule,
  CardModule,
  MessagesModule,
  MessageModule,
  InputTextModule,
]


MixedCdkDragDropModule.forRoot({ autoScrollStep: 4 });

@NgModule({
  imports: [
    MaterialComponents,
    PrimeComponents,
    ReactiveFormsModule,
    HttpClientModule,
    MixedCdkDragDropModule
  ],
  exports: [
    MaterialComponents,
    PrimeComponents,
    ReactiveFormsModule
  ],
  declarations: [
    ProjectStatusPipe
  ]
})
export class SharedModule { }
