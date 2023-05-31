// app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './modules/navigation/login/login.component';
import { MainLayoutComponent } from './modules/navigation/main-layout/main-layout.component';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '', component: MainLayoutComponent, children: [
      { path: '', redirectTo: 'projects', pathMatch: 'full' },
      { path: 'projects', loadChildren: () => import('./modules/manager/manager.module').then(m => m.ManagerModule) },
    ]
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: '**', redirectTo: '/login' },
];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
