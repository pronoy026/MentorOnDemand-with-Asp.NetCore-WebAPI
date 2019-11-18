import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MentorcreatedcoursesComponent } from './mentorcreatedcourses.component';

describe('MentorcreatedcoursesComponent', () => {
  let component: MentorcreatedcoursesComponent;
  let fixture: ComponentFixture<MentorcreatedcoursesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MentorcreatedcoursesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MentorcreatedcoursesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
