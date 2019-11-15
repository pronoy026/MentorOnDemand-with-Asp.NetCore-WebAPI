import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DatashareService } from './datashare.service';

@Injectable({
  providedIn: 'root'
})
export class BlockService {

  

  constructor( private http : HttpClient, private data: DatashareService) { }

  private _blockUnblockUserUrl = this.data.apiServer +"/api/admin/blockunblockuser/"
  
  private _allBlockedStudentsUrl = this.data.apiServer +"/api/admin/getblockedusers/3"
  private _allBlockedMentorsUrl = this.data.apiServer +"/api/admin/getblockedusers/2"

  private _blockMentorUrl = "http://localhost:3000/api/blockmentor"
  private _unblockMentorUrl = "http://localhost:3000/api/unblockmentor"


  private _blockCourseUrl = "http://localhost:3000/api/blockcourse"
  private _unblockCourseUrl = "http://localhost:3000/api/unblockcourse"
  private _onecourseUrl = "http://localhost:3000/api/onecourse"

  //student
  blockUnblockUser (user) {
    return this.http.get<any>(this._blockUnblockUserUrl+user.id)
  }

  allBlockedStudents() {
    return this.http.get<any>(this._allBlockedStudentsUrl)
  }

//mentor
  blockMentor (mentor) {
    return this.http.post<any>(this._blockMentorUrl, mentor)
  }

  unblockMentor (mentor) {
    return this.http.post<any>(this._unblockMentorUrl, mentor)
  }

  allBlockedMentors () {
    return this.http.get(this._allBlockedMentorsUrl)
  }


  blockCourse (course) {
    return this.http.post<any>(this._blockCourseUrl, course)
  }

  unblockCourse (course) {
    return this.http.post<any>(this._unblockCourseUrl, course)
  }

  oneCourse(data) {
    return this.http.get<any>(this._onecourseUrl, data)
  }
}
