import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DatashareService {

  public apiServer = "https://localhost:44342"

  userEmail = localStorage.getItem('email')
  userRole = localStorage.getItem('role')
  userTypeStudent: boolean
  userTypeMentor: boolean
  userTypeAdmin: boolean
  accType: string
  userName: string
  techData: any
  selectedCourseForPayment
  courseOverviewData

  notiMentor
  notiStudent


  private allMentorCoursesUrl = this.apiServer + "/api/admin/getallcourses"
  private _getAllStudentsUrl = this.apiServer + "/api/admin/getactiveusers/3"
  private _getAllCoursesUrl = "http://localhost:3000/api/allCourses"
  private _getAllMentorsUrl = this.apiServer + "/api/admin/getactiveusers/2"

  private _registerTechUrl = this.apiServer + "/api/admin/registertech"
  private _getAllTechsUrl = this.apiServer + "/api/mentor/gettechs"
  private _createCourseUrl = this.apiServer + "/api/mentor/creatementorskill"
  private _MentorSkillExistsUrl = this.apiServer + "/api/mentor/mentorskillexists"

  private _appliedCourseUrl = this.apiServer + "/api/student/applyforcourse"
  private _studentRegisterCourseUrl = this.apiServer + "/api/student/registercourse"
  private _getStudentAllAppliedCoursesUrl = this.apiServer + "/api/student/getappliedcourses/"
  private _getStudentAllRegisteredCoursesUrl = this.apiServer + "/api/student/getregisteredcourses/"
  private _getStudentAllCompletedCoursesUrl = this.apiServer + "/api/student/getcompletedcourses/"
  private _getStudentAllRejectedCoursesUrl = this.apiServer + "/api/student/getrejectedcourses/"
  private _getStudentAllConfirmedCoursesUrl = this.apiServer + "/api/student/getconfirmedcourses/"
  private _studentCourseCompletionStatusUpdateUrl = this.apiServer + "/api/student/coursecompletionstatusupdate"
  private _studentCourseCompletionUpdateUrl = this.apiServer + "/api/student/coursecompletionupdate"

  private _getMentorAllAppliedCoursesUrl = this.apiServer + "/api/mentor/getappliedcourses/"
  private _getMentorAllRegisteredCoursesUrl = this.apiServer + "/api/mentor/getregisteredcourses/"
  private _getMentorAllCompletedCoursesUrl = this.apiServer + "/api/mentor/getcompletedcourses/"
  private _getMentorAllRejectedCoursesUrl = this.apiServer + "/api/mentor/getrejectedcourses/"
  private _getMentorAllConfirmedCoursesUrl = this.apiServer + "/api/mentor/getconfirmedcourses/"
  private _mentorAcceptCourseUrl = this.apiServer + "/api/mentor/acceptcourse"
  private _mentorRejectCourseUrl = this.apiServer + "/api/mentor/rejectcourse"


  private _registeredCourseUrl = "http://localhost:3000/api/registeredcourse"

  private _checkCourseUrl = this.apiServer + "/api/student/checkcourse"
  private _searchUrl = "http://localhost:3000/api/search"

  constructor(private http: HttpClient) { }

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
  getAllMentorCourses() {
    return this.http.get<any>(this.allMentorCoursesUrl)
  }


  //for adminhome
  getAllStudents() {
    return this.http.get<any>(this._getAllStudentsUrl)
  }

  getAllMentors() {
    return this.http.get<any>(this._getAllMentorsUrl)
  }
  getAllAdminCourses() {
    return this.http.get<any>(this._getAllCoursesUrl)
  }


  //registered course
  registeredCourse(course) {
    return this.http.post<any>(this._registeredCourseUrl, course)
  }


  ////////////////////////student course api calls
  appliedCourse(course) {
    return this.http.post<any>(this._appliedCourseUrl, course)
  }

  studentRegisterCourse(course) {
    return this.http.post<any>(this._studentRegisterCourseUrl, course)
  }

  getStudentAllAppliedCourses(data) {
    return this.http.get<any>(this._getStudentAllAppliedCoursesUrl+data)
  }
  getStudentAllRegisteredCourses(data) {
    return this.http.get<any>(this._getStudentAllRegisteredCoursesUrl+data)
  }

  getStudentAllCompletedCourses(data) {
    return this.http.get<any>(this._getStudentAllCompletedCoursesUrl+data)
  }

  getStudentAllRejectedCourses(data) {
    return this.http.get<any>(this._getStudentAllRejectedCoursesUrl+data)
  }

  getStudentAllConfirmedCourses(data) {
    return this.http.get<any>(this._getStudentAllConfirmedCoursesUrl+data)
  }

  courseCompletionStatusUpdate(course) {
    return this.http.post<any>(this._studentCourseCompletionStatusUpdateUrl, course)
  }

  courseCompletionUpdate(course) {
    return this.http.post<any>(this._studentCourseCompletionUpdateUrl, course)
  }

  ///////////////////////mentor course api calls
  mentorAcceptCourse(course) {
    return this.http.post<any>(this._mentorAcceptCourseUrl, course)
  }

  mentorRejectCourse(course) {
    return this.http.post<any>(this._mentorRejectCourseUrl, course)
  }

  getMentorAllAppliedCourses(data) {
    return this.http.get<any>(this._getMentorAllAppliedCoursesUrl + data)
  }

  getMentorAllRegisteredCourses(data) {
    return this.http.get<any>(this._getMentorAllRegisteredCoursesUrl + data)
  }

  getMentorAllRejectedCourses(data) {
    return this.http.get<any>(this._getMentorAllRejectedCoursesUrl + data)
  }

  getMentorAllCompletedCourses(data) {
    return this.http.get<any>(this._getMentorAllCompletedCoursesUrl + data)
  }

  getMentorAllConfirmedCourses(data) {
    return this.http.get<any>(this._getMentorAllConfirmedCoursesUrl + data)
  }


  //
  checkCourse(data) {
    return this.http.post<any>(this._checkCourseUrl, data)
  }

  search(data) {
    return this.http.post<any>(this._searchUrl, data)
  }

  private _getMentorNotificationsUrl = this.apiServer + '/api/mentor/getnotifications/'
  private _deleteMentorNotificationsUrl = this.apiServer + '/api/mentor/deletenotifications/'
  private _deleteMentorNotificationByIdUrl = this.apiServer + '/api/mentor/deletenotificationbyid/'


  private _getStudentNotificationsUrl = this.apiServer + '/api/student/getnotifications/'
  private _deleteStudentNotificationsUrl = this.apiServer + '/api/student/deletenotifications/'
  private _deleteStudentNotificationByIdUrl = this.apiServer + '/api/student/deletenotificationbyid/'

  getMentorNotifications(email) {
    return this.http.get<any>(this._getMentorNotificationsUrl+email)
  }

  deleteMentorNotifications(email) {
    return this.http.get<any>(this._deleteMentorNotificationsUrl+email)
  }

  deleteMentorNotificationById(id) {
    return this.http.get<any>(this._deleteMentorNotificationByIdUrl+id)
  }


  getStudentNotifications(email) {
    return this.http.get<any>(this._getStudentNotificationsUrl+email)
  }

  deleteStudentNotifications(email) {
    return this.http.get<any>(this._deleteStudentNotificationsUrl+email)
  }

  deleteStudentNotificationById(id) {
    return this.http.get<any>(this._deleteStudentNotificationByIdUrl+id)
  }

}
