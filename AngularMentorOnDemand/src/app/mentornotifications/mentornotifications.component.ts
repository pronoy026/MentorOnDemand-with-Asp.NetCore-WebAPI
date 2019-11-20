import { Component, OnInit } from '@angular/core';
import { NotificationService } from '../notification.service';
import { DatashareService } from '../datashare.service';

@Component({
  selector: 'app-mentornotifications',
  templateUrl: './mentornotifications.component.html',
  styleUrls: ['./mentornotifications.component.scss']
})
export class MentornotificationsComponent implements OnInit {

  notifications
  tabletoggler : boolean

  constructor(private _notification : NotificationService, private data : DatashareService) { }

  ngOnInit() {
    let email = localStorage.getItem('email')
    this.data.getMentorNotifications(email)
        .subscribe(
          res => {
            console.log(res)
            this.notifications = res
            if (this.notifications.length == 0) {
              this.tabletoggler = false
            } else {
              this.tabletoggler = true
            }
          },
          err => {
            console.log(err)
          }
        )
  }

}
