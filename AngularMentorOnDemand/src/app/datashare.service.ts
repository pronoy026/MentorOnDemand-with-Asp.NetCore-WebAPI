import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DatashareService {

  public apiServer = "https://localhost:44342"

  userEmail = localStorage.getItem('email')
  userRole = localStorage.getItem('role')
  userTypeStudent : boolean
  userTypeMentor : boolean
  userTypeAdmin : boolean
  accType : string
  userName : string
  techData : any
  selectedCourseForPayment
  courseOverviewData

  
  private allMentorCoursesUrl = this.apiServer + "/api/admin/getallcourses"
  private _getAllStudentsUrl = this.apiServer + "/api/admin/getactiveusers/3"
  private _getAllCoursesUrl = "http://localhost:3000/api/allCourses"
  private _getAllMentorsUrl = this.apiServer + "/api/admin/getactiveusers/2"

  private _registerTechUrl = this.apiServer + "/api/admin/registertech"
  private _getAllTechsUrl = this.apiServer + "/api/mentor/gettechs"
  private _createCourseUrl = this.apiServer + "/api/mentor/creatementorskill"
  private _MentorSkillExistsUrl = this.apiServer + "/api/mentor/mentorskillexists"

  private _appliedCourseUrl = this.apiServer + "/api/student/applyforcourse"
  private _getStudentAllAppliedCoursesUrl = "http://localhost:3000/api/studentallappliedcourses"
  private _getMentorAllAppliedCoursesUrl = "http://localhost:3000/api/mentorallappliedcourses"
  private _deleteAppliedCourseUrl = "http://localhost:3000/api/deleteappliedcourse"

  private _registeredCourseUrl = "http://localhost:3000/api/registeredcourse"
  private _getStudentAllRegisteredCoursesUrl = "http://localhost:3000/api/studentallregisteredcourses"
  private _getMentorAllRegisteredCoursesUrl = "http://localhost:3000/api/mentorallregisteredcourses"
  private _updateRegisteredCourseUrl = "http://localhost:3000/api/updateregisteredcourse"

  private _completedCourseUrl = "http://localhost:3000/api/completedCourse"
  private _getStudentAllCompletedCoursesUrl = "http://localhost:3000/api/studentallcompletedcourses"
  private _getMentorAllCompletedCoursesUrl = "http://localhost:3000/api/mentorallcompletedcourses"

  private _checkCourseUrl = this.apiServer + "/api/student/checkcourse"
  private _searchUrl ="http://localhost:3000/api/search"

  constructor( private http : HttpClient) { }

  registerTech(tech) {
    return this.http.post<any>(this._registerTechUrl, tech)
  }

  getMentorTechs() {
    return this.http.get<any>(this._getAllTechsUrl)
  }

  createMentorCourse(course) {
    return this.http.post<any>(this._createCourseUrl, course)
  }

  mentorSkillExists(data) {
    return this.http.post<any>(this._MentorSkillExistsUrl, data)
  }

  //for courses tab in general
  getAllMentorCourses () {
    return this.http.get<any>(this.allMentorCoursesUrl)
  }


  //for adminhome
  getAllStudents () {
    return this.http.get<any>(this._getAllStudentsUrl)
  }

  getAllMentors () {
    return this.http.get<any>(this._getAllMentorsUrl)
  }
  getAllAdminCourses () {
    return this.http.get<any>(this._getAllCoursesUrl)
  }

  // applied courses
  appliedCourse(course) {
    return this.http.post<any>(this._appliedCourseUrl, course)
  }

  getStudentAllAppliedCourses(data) {
    return this.http.post<any>(this._getStudentAllAppliedCoursesUrl, data)
  }

  getMentorAllAppliedCourses(data) {
    return this.http.post<any>(this._getMentorAllAppliedCoursesUrl, data)
  }
  deleteAppliedCourse(data) {
    return this.http.post<any>(this._deleteAppliedCourseUrl, data)
  }

  //registered course
  registeredCourse(course) {
    return this.http.post<any>(this._registeredCourseUrl, course)
  }

  getStudentAllRegisteredCourses(data) {
    return this.http.post<any>(this._getStudentAllRegisteredCoursesUrl, data)
  }

  getMentorAllRegisteredCourses(data) {
    return this.http.post<any>(this._getMentorAllRegisteredCoursesUrl, data)
  }

  updateRegisteredCourses(data) {
    return this.http.put<any>(this._updateRegisteredCourseUrl, data)
  }

  //completed course
  completedCourse(course) {
    return this.http.post<any>(this._completedCourseUrl, course)
  }

  getStudentAllCompletedCourses(data) {
    return this.http.post<any>(this._getStudentAllCompletedCoursesUrl, data)
  }

  getMentorAllCompletedCourses(data) {
    return this.http.post<any>(this._getMentorAllCompletedCoursesUrl, data)
  }

  checkCourse(data) {
    return this.http.post<any>(this._checkCourseUrl, data)
  }

  search(data) {
    return this.http.post<any>(this._searchUrl, data)
  }

}
