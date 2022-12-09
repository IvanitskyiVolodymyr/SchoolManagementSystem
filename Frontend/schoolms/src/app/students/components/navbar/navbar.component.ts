import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  isShowing = false;
  openSidenavFlag = false;

  ngOnInit(){
    this.onResize(undefined);
  }

// eslint-disable-next-line
  onResize(event: any | undefined) {
    let width;

    if(event != undefined){
      width = event.target.innerWidth;
    }
    else{
      width = document.body.clientWidth;
    }

    if (width >= 720) {
      this.openSidenavFlag = false;
      this.isShowing = false;
    } 
    else {
      this.openSidenavFlag = true;
    }
  }

  sidenavToggle() {
    this.isShowing = !this.isShowing;
  }
}
