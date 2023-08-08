import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RegisterProjectDialogComponent } from '../../manager/projects/register-project-dialog/register-project-dialog.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {

  isOpen=false;

  constructor(
    public dialog: MatDialog,
    private router: Router) {

    }

  logout() {
    console.log('Logging out...');
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  toggleSideNav(){
    this.isOpen = !this.isOpen;
  }

  openProjectsDialog(){
    const dialogRef = this.dialog.open(RegisterProjectDialogComponent);
  }

}
