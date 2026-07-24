# Student Course Portal — Angular Hands-On 1–10

This is one cumulative Angular 20 standalone project implementing the supplied exercise book. It intentionally excludes `node_modules`, build output, screenshots, commits, and any generated run artifacts.

## Run it manually

1. Open this folder in a terminal.
2. Run `npm install`.
3. In terminal 1 run `npm run api` to start JSON Server at `http://localhost:3000`.
4. In terminal 2 run `npm start`, then open `http://localhost:4200`.
5. Use `npm test` (or `npm test -- --code-coverage`) for the included specs.

Take screenshots yourself as you complete each relevant route/feature, then review `git status`, commit, and push when ready.

## Exercise map

| Hands-on | Implementation |
| --- | --- |
| 1–3 | Header/home, bindings, lifecycle logs, course cards, directives, highlight directive, credit pipe |
| 4–5 | Template-driven and reactive enrollment forms and validation |
| 6–7 | Services, nested courses route, lazy enrollment routes, auth and unsaved-change guards |
| 8 | JSON Server API, RxJS pipeline, auth/error/loading interceptors |
| 9 | NgRx actions, reducers, selectors, effects, and enrollment state |
| 10 | Course-card and HTTP service Jasmine specs |

Open `/enroll/reactive` to test the reactive form and its CanDeactivate prompt. The app expects JSON Server to be running before courses can load.
