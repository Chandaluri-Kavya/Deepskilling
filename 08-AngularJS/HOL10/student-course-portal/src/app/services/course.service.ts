import { Injectable } from '@angular/core'; import { HttpClient } from '@angular/common/http'; import { Observable, throwError } from 'rxjs'; import { catchError, map, retry, tap } from 'rxjs/operators'; import { Course } from '../models/course.model';
@Injectable({ providedIn: 'root' })
export class CourseService {
  private readonly api = 'http://localhost:3000/courses';
  constructor(private http: HttpClient) {}
  getCourses(): Observable<Course[]> { return this.http.get<Course[]>(this.api).pipe(map(courses => courses.filter(c => (c.credits ?? 0) > 0)), tap(courses => console.log('Courses loaded:', courses.length)), retry(2), catchError(err => { console.error(err); return throwError(() => new Error('Failed to load courses. Please try again.')); })); }
  getCourseById(id: number): Observable<Course> { return this.http.get<Course>(`${this.api}/${id}`); }
  createCourse(course: Omit<Course, 'id'>): Observable<Course> { return this.http.post<Course>(this.api, course); }
  updateCourse(course: Course): Observable<Course> { return this.http.put<Course>(`${this.api}/${course.id}`, course); }
  deleteCourse(id: number): Observable<void> { return this.http.delete<void>(`${this.api}/${id}`); }
}
