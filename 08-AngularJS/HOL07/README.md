# HOL7 - Routing, Lazy Loading and Guards

## Objective

Add portal navigation, parameterised and nested routes, lazy-loaded enrollment routes, and guards.

## Implemented in the cumulative project

- `app.routes.ts` defines Home, Courses, Course Detail, Profile, Enrollment, and wildcard routes.
- `pages/courses-layout.component.ts` hosts the nested Courses router outlet.
- `features/enrollment/enrollment.routes.ts` is lazy loaded from `/enroll`.
- `guards/auth.guard.ts` protects Profile and Enrollment.
- `guards/unsaved-changes.guard.ts` confirms navigation away from a dirty reactive form.

## Verification

Run the cumulative project in HOL10, navigate to `/courses/1`, `/profile`, and `/enroll/reactive`, then change a field and try to leave the page.
