# HOL6 - Services and Dependency Injection

## Objective

Refactor portal data access into injectable services and use service methods from components.

## Implemented in the cumulative project

`HOL10/student-course-portal/src/app/services/` contains:

- `course.service.ts` - course retrieval and CRUD operations.
- `enrollment.service.ts` - enrollment and enrolled-student operations.
- `notification.service.ts` - shared user notifications.
- `auth.service.ts` - authentication state used by route guards.

The components consume these services through Angular dependency injection.  The final project is kept in HOL10 because the exercise book specifies one cumulative application.

## Verification

Start the API with `npm run api`, start Angular with `npm start`, then open the Courses and Enrollment pages.
