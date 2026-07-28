import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ActivatedRoute, provideRouter } from '@angular/router';
import { provideMockStore, MockStore } from '@ngrx/store/testing';
import { CourseListComponent } from './course-list.component';
import { Course } from '../models/course.model';
import { EnrollmentService } from '../services/enrollment.service';

describe('CourseListComponent with MockStore', () => {
  let fixture: ComponentFixture<CourseListComponent>;
  let store: MockStore;
  const courses: Course[] = [
    { id: 1, name: 'Data Structures', code: 'CS101', credits: 4, gradeStatus: 'passed' },
    { id: 2, name: 'Angular Fundamentals', code: 'NG201', credits: 3, gradeStatus: 'pending' }
  ];
  const route = { snapshot: { queryParamMap: { get: () => null } } };

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CourseListComponent],
      providers: [
        provideRouter([]),
        { provide: ActivatedRoute, useValue: route },
        { provide: EnrollmentService, useValue: { isEnrolled: () => false, enroll: () => undefined, unenroll: () => undefined } },
        provideMockStore({ initialState: { course: { courses, loading: false, error: null }, enrollment: { enrolledCourseIds: [] } } })
      ]
    }).compileComponents();
    fixture = TestBed.createComponent(CourseListComponent);
    store = TestBed.inject(MockStore);
  });

  it('renders course cards from the supplied store state', () => {
    fixture.detectChanges();
    expect(fixture.nativeElement.querySelectorAll('app-course-card').length).toBe(2);
  });

  it('renders the loading indicator when the store is loading', () => {
    store.setState({ course: { courses: [], loading: true, error: null }, enrollment: { enrolledCourseIds: [] } });
    fixture.detectChanges();
    expect(fixture.nativeElement.textContent).toContain('Loading courses...');
  });
});
