# HOL9 - NgRx State Management

## Objective

Move course and enrollment state into NgRx actions, reducers, selectors, and effects.

## Implemented in the cumulative project

- `store/course/` contains load actions, reducer, selectors, and the HTTP-backed effect.
- `store/enrollment/` contains enrollment actions, reducer, and selectors.
- `app.config.ts` registers the store, effects, and Store DevTools integration.
- `pages/course-list.component.ts` selects observable state and dispatches load/enrollment actions.

## Verification

Run the HOL10 project with JSON Server, open the Courses page, and inspect the `[Course] Load Courses` action flow in Redux DevTools.
