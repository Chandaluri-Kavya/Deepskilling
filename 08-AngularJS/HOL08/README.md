# HOL8 - HTTP Client, RxJS and Interceptors

## Objective

Replace hard-coded course data with JSON Server API calls and add cross-cutting HTTP handling.

## Implemented in the cumulative project

- `db.json` supplies the mock courses, students, and enrollments API.
- `services/course.service.ts` performs GET, POST, PUT, and DELETE requests and uses `map`, `tap`, `retry`, and `catchError`.
- `interceptors/auth.interceptor.ts` attaches the mock bearer token.
- `interceptors/error-handler.interceptor.ts` handles global errors.
- `interceptors/loading.interceptor.ts` and `services/loading.service.ts` expose loading state.

## Verification

From HOL10/student-course-portal, run `npm run api` and `npm start`. Open the browser Network tab to verify API traffic and the Authorization header.
