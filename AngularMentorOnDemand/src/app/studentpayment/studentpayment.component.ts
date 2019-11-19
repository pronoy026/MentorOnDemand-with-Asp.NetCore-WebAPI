import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DatashareService } from '../datashare.service';
import { AuthService } from '../auth.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-studentpayment',
  templateUrl: './studentpayment.component.html',
  styleUrls: ['./studentpayment.component.scss']
})
export class StudentpaymentComponent implements OnInit {

  courseData
  paymentSuccess: boolean
  notStudent: boolean
  eligibleStudent: boolean

  constructor(private _router: Router, private _datashare: DatashareService, private _auth: AuthService) { }

  ngOnInit() {
    this.courseData = this._datashare.selectedCourseForPayment
    this.paymentSuccess = false
    
          this._datashare.userEmail = localStorage.getItem('email')
          // this._datashare.userTypeStudent = true
          // this._datashare.userTypeMentor = false
          // this._datashare.userTypeAdmin = false
          if (localStorage.getItem('role')!='3') {
            this.notStudent = true
          } else {
            this.notStudent = false
            if (this.courseData !== undefined) {
              console.log(this.courseData)
              let StudentEmail = localStorage.getItem('email')
              let MentorSkillId = this.courseData.mentorSkillId
              this._datashare.checkCourse({StudentEmail, MentorSkillId})
                .subscribe(
                  res => {
                    this.eligibleStudent = res
                    console.log(this.eligibleStudent)
                  },
                  err => console.log(err)
                )
            }
          }

  }

  appliedCourse(course) {
    console.log('data came')
    console.log(course)
    let record = {
      StudentEmail : localStorage.getItem('email'),
      MentorSkillId : course.mentorSkillId,
      IsRequested : true,
      IsCompleted: false,
      IsRejected: false,
      IsRegistered: false,
      CompletionStatus: 0,
      Rating : 0
    }
    console.log(record)
    this._datashare.appliedCourse(record)
      .subscribe(
        res => { 
          this.paymentSuccess = true
          console.log('course applied successfully')
        },
        err => console.log(err)
      )
  }

}
