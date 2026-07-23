# Microservice HOL 1 — JWT Authentication

This ASP.NET Core Web API implements Question 1 from **Microservices - JWT**.

## Endpoints

| Endpoint | Authentication | Purpose |
| --- | --- | --- |
| `POST /api/auth/login` | None | Validates a demo user and returns a JWT. |
| `GET /api/secure/data` | Bearer JWT | Returns protected data for the authenticated user. |

Demo credentials: `kavya` / `Password@123`

## Run

```powershell
dotnet run --project .\JwtAuthMicroservice
```

Open `http://localhost:5182/swagger` when running with the included launch profile, call `POST /api/auth/login`, then paste `Bearer <token>` into Swagger's **Authorize** dialog before calling the protected endpoint.

## Evidence

The `Outputs` folder contains screenshots for successful login, protected-route access with a token, and the 401 response without a token.
