# WebAPI-HOL2 - Quick Start Guide

## Project Structure
```
WebAPI-HOL2/
├── EmployeeApi/
│   ├── Controllers/
│   │   └── EmpController.cs        (Route: api/Emp)
│   ├── Models/
│   │   └── Employee.cs
│   ├── Filters/
│   │   └── SampleFilter.cs
│   ├── Program.cs                  (Swagger configuration)
│   └── EmployeeApi.csproj
├── Outputs/
│   ├── WebAPI-HOL2-Documentation.md
│   └── Employee-API-Postman-Collection.json
```

## How to Run

### Step 1: Build the Project
```bash
cd EmployeeApi
dotnet build
```

### Step 2: Run the Project
```bash
dotnet run
```

**Expected Output:**
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5094
```

### Step 3: Access Swagger
Open in browser:
```
http://localhost:5094/swagger/index.html
```

---

## Testing with Swagger

### 1. GET All Employees
- Click blue **GET** button: `/api/Emp`
- Click **Try it out**
- Click **Execute**
- Response: List of employees (200 OK)

### 2. GET Employee by ID
- Click blue **GET** button: `/api/Emp/{id}`
- Enter ID: `1`
- Click **Execute**
- Response: Single employee (200 OK)

### 3. POST Create Employee
- Click green **POST** button: `/api/Emp`
- Click **Try it out**
- Enter request body:
```json
{
  "name": "New Employee",
  "salary": 9000
}
```
- Click **Execute**
- Response: "Employee Added" (201 Created)

### 4. PUT Update Employee
- Click orange **PUT** button: `/api/Emp/{id}`
- Enter ID: `1`
- Enter request body:
```json
{
  "name": "Updated Name",
  "salary": 9500
}
```
- Click **Execute**
- Response: "Employee Updated" (200 OK)

### 5. DELETE Employee
- Click red **DELETE** button: `/api/Emp/{id}`
- Enter ID: `1`
- Click **Execute**
- Response: "Employee Deleted" (200 OK)

---

## Testing with Postman

### Step 1: Import Collection
1. Open Postman
2. Click **Import**
3. Select `Employee-API-Postman-Collection.json`
4. Click **Import**

### Step 2: Run Requests
1. Select a request from the collection
2. Click **Send**
3. View response in **Body** tab
4. Check **Status** code

### Step 3: Request Structure

**Headers Tab:**
```
Content-Type: application/json
```

**Body Tab (for POST/PUT):**
Raw JSON format
```json
{
  "name": "Employee Name",
  "salary": 10000
}
```

---

## Key Features

| Feature | Location | Purpose |
|---------|----------|---------|
| **Swagger Config** | Program.cs | API documentation with metadata |
| **Route** | EmpController | api/Emp endpoint |
| **ProducesResponseType** | Methods | Swagger response documentation |
| **Name Attribute** | GetById method | Route identification |
| **Postman Collection** | Outputs folder | Pre-configured requests |

---

## Important Notes

1. **Route is "api/Emp"** (not "api/Employee")
   - Changed for user-friendly endpoint

2. **Swagger Metadata:**
   - Title: "Swagger Demo"
   - Contact: John Doe
   - License: License Terms

3. **Response Messages:**
   - POST: "Employee Added"
   - PUT: "Employee Updated"
   - DELETE: "Employee Deleted"

4. **Status Codes:**
   - 200: Success
   - 201: Created
   - 404: Not Found
   - 400: Bad Request

---

## Troubleshooting

**Port 5094 already in use?**
```bash
netstat -ano | findstr :5094
taskkill /PID {process_id} /F
```

**Swagger not loading?**
- Check Program.cs has `app.UseSwagger()` and `app.UseSwaggerUI()`
- Verify Swashbuckle.AspNetCore is installed

**Postman showing "Could not get response"?**
- Ensure API is running (`dotnet run`)
- Check URL is correct: http://localhost:5094/api/Emp
- Verify Content-Type header is set to application/json
