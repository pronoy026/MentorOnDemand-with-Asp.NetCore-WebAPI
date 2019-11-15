import { Component, OnInit } from '@angular/core';
import { DatashareService } from '../datashare.service';

@Component({
  selector: 'app-mentortechnologies',
  templateUrl: './mentortechnologies.component.html',
  styleUrls: ['./mentortechnologies.component.scss']
})
export class MentortechnologiesComponent implements OnInit {

  constructor(private data : DatashareService) { }
  techs

  appliedCourses
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

}
