import { Component, OnInit } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { AuthService } from '../auth.service';
import { Router } from '@angular/router';
import { DatashareService } from '../datashare.service';

@Component({
  selector: 'app-mentorhome',
  templateUrl: './mentorhome.component.html',
  styleUrls: ['./mentorhome.component.scss']
})
export class MentorhomeComponent implements OnInit {

  constructor(private _auth: AuthService, private _router: Router, public _datashare: DatashareService) { }

  ngOnInit() {
        this._datashare.userEmail = localStorage.getItem('email')
        this._datashare.userTypeStudent = false
        this._datashare.userTypeMentor = true
        this._datashare.userTypeAdmin = false
        if (localStorage.getItem('role')!='2') {
          this._router.navigate(['/signin'])
        }

  }

}
