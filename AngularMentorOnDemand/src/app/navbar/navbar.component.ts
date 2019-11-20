import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BannerComponent } from '../banner/banner.component';
import { AuthService } from '../auth.service';
import { DatashareService } from '../datashare.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  userEmail
  noti=12

  constructor(public _datashare: DatashareService, private _authService: AuthService) { }

  ngOnInit() {
    if (this._authService.loggedIn()) {
      if (localStorage.getItem('role')=='3') {
        this._datashare.userTypeStudent = true
        this._datashare.userTypeMentor = false
        this._datashare.userTypeAdmin = false
      }
      if (localStorage.getItem('role')=='2') {
        this._datashare.userTypeStudent = false
        this._datashare.userTypeMentor = true
        this._datashare.userTypeAdmin = false
      }
      if (localStorage.getItem('role')=='1') {
        this._datashare.userTypeStudent = false
        this._datashare.userTypeMentor = false
        this._datashare.userTypeAdmin = true
      }
    }
  }

}
