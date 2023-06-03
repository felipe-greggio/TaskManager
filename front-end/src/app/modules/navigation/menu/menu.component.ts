import { Component } from '@angular/core';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {

  isOpen=true;

  constructor() { }

  logout() {
    // Handle your logout action here.
    console.log('Logging out...');
  }

  toggleSideNav(){

    this.isOpen = !this.isOpen;

  }

}
