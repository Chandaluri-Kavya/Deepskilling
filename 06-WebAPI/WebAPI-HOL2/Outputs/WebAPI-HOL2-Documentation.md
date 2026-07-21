# WebAPI-HOL2 - Swagger Integration & Postman Testing

## Project Overview
This project demonstrates ASP.NET Core Web API with:
- **Swagger/OpenAPI** integration for API documentation
- **Custom routes** (api/Emp instead of api/Employee)
- **ProducesResponseType** for response documentation
- **Named routes** using the `Name` attribute
- **Postman** testing

---

## Part 1: Swagger Installation & Configuration

### 1.1 NuGet Package Installation
Package used: **Swashbuckle.AspNetCore**

Installed via:
```
dotnet add package Swashbuckle.AspNetCore
```

### 1.2 Swagger Configuration in Program.cs

```csharp
// Add Swagger/OpenAPI with custom configuration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Swagger Demo",
        Version = "v1",
        Description = "Employee API with Swagger Documentation",
        TermsOfService = new Uri("http://www.example.com/terms"),
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "John Doe",
            Email = "john@xyzmail.com",
            Url = new Uri("http://www.example.com")
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "License Terms",
            Url = new Uri("http://www.example.com/license")
        }
    });
});

// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
});
```

### 1.3 Using ProducesResponseType

Each API method documents response types:

```csharp
[HttpGet]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public ActionResult<IEnumerable<Employee>> GetAll()
{
    return Ok(Employees);
}
```

**Response Types documented:**
- **200 OK** - Successful GET request
- **201 Created** - Successful POST request
- **404 Not Found** - Resource not found
- **400 Bad Request** - Invalid input
- **500 Internal Server Error** - Server error

---

## Part 2: Accessing Swagger

### Steps to Access Swagger UI

1. **Run the application:**
   ```bash
   dotnet run
   ```

2. **Open browser and navigate to:**
   ```
   http://localhost:5094/swagger/index.html
   ```

3. **View Swagger Metadata:**
   - Title: "Swagger Demo"
   - Version: "v1"
   - Contact: John Doe (john@xyzmail.com)
   - License: License Terms

4. **Endpoints Listed:**
   - GET /api/Emp - Get all employees
   - GET /api/Emp/{id} - Get employee by ID
   - POST /api/Emp - Create employee
   - PUT /api/Emp/{id} - Update employee
   - DELETE /api/Emp/{id} - Delete employee

---

## Part 3: Route Attribute & Naming

### 3.1 Custom Route: "api/Emp"

```csharp
[ApiController]
[Route("api/[controller]")]  // Route is "api/Emp" (controller name)
public class EmpController : ControllerBase
{
    ...
}
```

**Why "Emp" instead of "Employee"?**
- Shorter, user-friendly endpoint name
- Easier to remember and type
- Reduces URL length

### 3.2 Named Routes for GET by ID

```csharp
[HttpGet("{id:int}", Name = "GetEmployeeById")]
public ActionResult<Employee> GetById(int id)
{
    ...
}
```

**Purpose of `Name` attribute:**
- Allows referencing the route by name
- Used in `CreatedAtRoute` for POST responses
- Makes refactoring easier

### 3.3 Multiple Methods with Same Verb

Using `ActionName` attribute:

```csharp
[HttpGet("{id:int}")]
[ActionName("GetEmployeeById")]
public ActionResult<Employee> GetById(int id) { ... }

[HttpGet("active")]
[ActionName("GetActiveEmployees")]
public ActionResult<IEnumerable<Employee>> GetActive() { ... }
```

This allows multiple GET methods without conflicts.

---

## Part 4: Testing with Postman

### 4.1 Postman Setup

1. **Download Postman** from https://www.postman.com/downloads/

2. **Create a New Collection:**
   - Click "+" to create new request
   - Click "Save as" and save to "Employee API Collection"

### 4.2 Postman Request Structure

#### Headers Tab
```
Content-Type: application/json
Authorization: Bearer {token}  (if needed)
```

#### Body Tab (for POST/PUT)
```json
{
  "name": "John Doe",
  "salary": 8000
}
```

#### Test 1: GET All Employees

**Postman Configuration:**
- **Method:** GET
- **URL:** http://localhost:5094/api/Emp
- **Headers:** None required
- **Body:** None

**Expected Response:**
```json
[
  { "id": 1, "name": "Alice Johnson", "salary": 5000 },
  { "id": 2, "name": "Bob Smith", "salary": 6500 },
  { "id": 3, "name": "Charlie Brown", "salary": 7200 }
]
```

**Status:** 200 OK

---

#### Test 2: GET Employee by ID

**Postman Configuration:**
- **Method:** GET
- **URL:** http://localhost:5094/api/Emp/1
- **Headers:** None required
- **Body:** None

**Expected Response:**
```json
{
  "id": 1,
  "name": "Alice Johnson",
  "salary": 5000
}
```

**Status:** 200 OK

---

#### Test 3: POST Create Employee

**Postman Configuration:**
- **Method:** POST
- **URL:** http://localhost:5094/api/Emp
- **Headers:** 
  ```
  Content-Type: application/json
  ```
- **Body:**
  ```json
  {
    "name": "David Wilson",
    "salary": 8500
  }
  ```

**Expected Response:**
```
Employee Added
```

**Status:** 201 Created

---

#### Test 4: PUT Update Employee

**Postman Configuration:**
- **Method:** PUT
- **URL:** http://localhost:5094/api/Emp/1
- **Headers:**
  ```
  Content-Type: application/json
  ```
- **Body:**
  ```json
  {
    "name": "Alice Johnson Updated",
    "salary": 5500
  }
  ```

**Expected Response:**
```
Employee Updated
```

**Status:** 200 OK

---

#### Test 5: DELETE Employee

**Postman Configuration:**
- **Method:** DELETE
- **URL:** http://localhost:5094/api/Emp/1
- **Headers:** None required
- **Body:** None

**Expected Response:**
```
Employee Deleted
```

**Status:** 200 OK

---

## Part 5: Route Attribute Key Points

| Feature | Description | Benefit |
|---------|-------------|---------|
| **Route("api/[controller]")** | Maps to controller name (Emp) | User-friendly URLs |
| **Name attribute** | Identifies routes by name | Enables CreatedAtRoute |
| **ActionName** | Aliases action methods | Allows multiple methods with same verb |
| **Produces** | Specifies response type | Swagger documentation |
| **ProducesResponseType** | Documents response codes | Clear API contract |

---

## Summary

**Swagger:**
- Installed via NuGet: Swashbuckle.AspNetCore
- Configured with metadata (Title, Contact, License)
- Accessed at: /swagger/index.html
- Automatically documents all endpoints

**Route Customization:**
- Changed route from "Employee" to "Emp"
- Used Name attribute for route identification
- Can use ActionName for method disambiguation

**Postman:**
- Test API endpoints with different HTTP methods
- Configure headers and request bodies
- View response status and data
- Create organized request collections

**Best Practices:**
- Always use ProducesResponseType for documentation
- Use meaningful route names
- Implement proper error handling
- Test all HTTP verbs
