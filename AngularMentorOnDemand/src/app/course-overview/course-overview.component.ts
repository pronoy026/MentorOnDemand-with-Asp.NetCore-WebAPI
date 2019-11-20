import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DatashareService } from '../datashare.service';

@Component({
  selector: 'app-course-overview',
  templateUrl: './course-overview.component.html',
  styleUrls: ['./course-overview.component.scss']
})
export class CourseOverviewComponent implements OnInit {

  course
  selectValue

  constructor(private _router: Router, private _datashare: DatashareService) { }

  ngOnInit() {
    this.course = this._datashare.courseOverviewData
  }
  updateRegisteredCourse() {
    let value = parseInt(this.selectValue, 10)
    if(value<=this.course.completionStatus)
    {
      alert(`Please select completion percentage higher than ${this.course.completionStatus} %`)
    }
    if(this.selectValue===undefined) {
      alert('Please select completion percentage to proceed!')
    }
    if (value>this.course.completionStatus && value!= 100 && this.selectValue!==undefined) {

      let record = {
        StudentEmail : localStorage.getItem('email'),
        MentorSkillId : this.course.mentorSkillId,
        CompletionStatus : value
      }

      this._datashare.courseCompletionStatusUpdate(record)
        .subscribe(
          res => {
            this.course.completionStatus = value
            alert(`Course completion percentage updated successfully to ${this.course.completionStatus} %`)
            this._router.navigate(['/studenthome/studentregisteredcourses'])
          },
          err => console.log(err)
        )
    }
    if (value== 100 && this.selectValue!==undefined) {
      this.courseCompletion()
    }
  }
  courseCompletion() {
    let record = {
      StudentEmail : localStorage.getItem('email'),
      MentorSkillId : this.course.mentorSkillId,
      CompletionStatus : 100
    }
    this._datashare.courseCompletionUpdate(record)
        .subscribe(
          res => this._router.navigate(['/studenthome/studentcompletedcourses']),
          err => console.log(err)
        )
  }
}
