import { Component, OnInit } from '@angular/core';
import { DatashareService } from '../datashare.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mentortechnologies',
  templateUrl: './mentortechnologies.component.html',
  styleUrls: ['./mentortechnologies.component.scss']
})
export class MentortechnologiesComponent implements OnInit {

  constructor(public data : DatashareService, private router: Router) { }
  techs
  tabletoggler: boolean

  ngOnInit() {
    this.data.getMentorTechs()
        .subscribe(
          res => {
            console.log(res)
            this.techs = res
                if (this.techs.length == 0) {
                  this.tabletoggler = false
                } else {
                  this.tabletoggler = true
                }
          },
          err => console.log(err)
        )
  }

  createCourse(techData) {
    this.data.techData = techData
    this.router.navigate(['/mentorhome/mentorcreatecourse'])
  }
}
