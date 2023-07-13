import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RegisterProjectDialogComponent } from '../../manager/projects/register-project-dialog/register-project-dialog.component';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {

  isOpen=true;

  constructor(public dialog: MatDialog) { }

  logout() {
    console.log('Logging out...');
  }

  toggleSideNav(){
    this.isOpen = !this.isOpen;
  }

  openProjectsDialog(){
    const dialogRef = this.dialog.open(RegisterProjectDialogComponent);
  }

}
