import { Component, OnInit } from '@angular/core';
import { DatashareService } from '../datashare.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mentorcreatecourse',
  templateUrl: './mentorcreatecourse.component.html',
  styleUrls: ['./mentorcreatecourse.component.scss']
})
export class MentorcreatecourseComponent implements OnInit {

  constructor(private data: DatashareService, private router: Router) { }

  sdate = ""
  edate = ""
  createCourseData = { MentorEmail: localStorage.getItem('email'), TechId: 0, StartDate: new Date, EndDate: new Date }
  techData
  message = ""
  edate2

  ngOnInit() {
    console.log('jj')
    console.log(this.data.techData)
    this.techData = this.data.techData
  }
  dateChange() {
    this.createCourseData.StartDate = new Date(this.sdate)
    console.log(this.createCourseData.StartDate)
    this.createCourseData.EndDate.setDate(this.createCourseData.StartDate.getDate() + (this.techData.duration));
    console.log(this.createCourseData.EndDate)
    this.edate2 = this.createCourseData.EndDate.toISOString().slice(0,10);
    // this.edate2 = this.createCourseData.EndDate.toLocaleDateString();
    console.log(this.edate2)
  }
  createCourse() {
    this.createCourseData.TechId = this.techData.id
    this.data.createMentorCourse(this.createCourseData)
      .subscribe(
        res => {
          this.router.navigate(['/mentorhome/mentorcreatedcourses'])
        },
        err => console.log(err)
      )
  }
}
