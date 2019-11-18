import { Component, OnInit } from '@angular/core';
import { DatashareService } from '../datashare.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {
  
  mentorCourseList

  mentorName
  mentorRating
  mentorNoOfTrainings
  expYears


  constructor(public _dataService: DatashareService, private _router : Router) { }

  ngOnInit() {
    // this.getCourses()
    this.getMentorCourses()
  }

  getMentorCourses() {
    this._dataService.getAllMentorCourses()
      .subscribe(
        res =>{ 
          this.mentorCourseList = res
          console.log(res)
        },
        err => console.log(err)
      )
  }

  modalDataChange(data) {

    this.mentorName =data.mentor.name
    this.mentorRating =data.rating
    this.mentorNoOfTrainings= data.nooftrainings
    this.expYears =data.mentor.experience

  }

  makePayment(course) {
    this._dataService.selectedCourseForPayment = course
    this._router.navigate(['/studentpayment'])
  }
}
