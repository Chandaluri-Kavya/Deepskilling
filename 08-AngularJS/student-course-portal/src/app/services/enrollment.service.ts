import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Course } from '../models/course.model';
import { CourseService } from './course.service';

@Injectable({ providedIn: 'root' })
export class EnrollmentService {
  private enrolledCourseIds: number[] = [];

  // Injecting CourseService demonstrates service-to-service dependency injection.
  constructor(private readonly courses: CourseService) {}

  enroll(id: number) { if (!this.enrolledCourseIds.includes(id)) this.enrolledCourseIds.push(id); }
  unenroll(id: number) { this.enrolledCourseIds = this.enrolledCourseIds.filter(courseId => courseId !== id); }
  isEnrolled(id: number) { return this.enrolledCourseIds.includes(id); }
  getEnrolledIds() { return [...this.enrolledCourseIds]; }
  getEnrolledCourses(): Observable<Course[]> {
    return this.courses.getCourses().pipe(map(courses => courses.filter(course => this.isEnrolled(course.id))));
  }
}
