import { Component, inject } from '@angular/core';
import { AsyncPipe, NgFor } from '@angular/common';
import { EnrollmentService } from '../services/enrollment.service';

@Component({ standalone: true, imports: [AsyncPipe, NgFor], template: `<h1>Student Profile</h1><p>Enrolled courses:</p><ul><li *ngFor="let course of enrolledCourses$ | async">{{ course.name }} ({{ course.code }})</li></ul>` })
export class StudentProfileComponent {
  private readonly enrollment = inject(EnrollmentService);
  // This shared root service is also used by the course list, demonstrating HOL6 state sharing.
  enrolledCourses$ = this.enrollment.getEnrolledCourses();
}
