import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home.component';
import { StudentProfileComponent } from './pages/student-profile.component';
import { CoursesLayoutComponent } from './pages/courses-layout.component';
import { CourseListComponent } from './pages/course-list.component';
import { CourseDetailComponent } from './pages/course-detail.component';
import { NotFoundComponent } from './pages/not-found.component';
import { authGuard } from './guards/auth.guard';
export const routes: Routes = [
  { path: '', component: HomeComponent, title: 'Student Course Portal' },
  { path: 'courses', component: CoursesLayoutComponent, children: [{ path: '', component: CourseListComponent }, { path: ':id', component: CourseDetailComponent }] },
  { path: 'profile', component: StudentProfileComponent, canActivate: [authGuard] },
  { path: 'enroll', canActivate: [authGuard], loadChildren: () => import('./features/enrollment/enrollment.routes').then(m => m.ENROLLMENT_ROUTES) },
  { path: '**', component: NotFoundComponent }
];
