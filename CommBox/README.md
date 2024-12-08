# CommBox Assignment

## Assignment Scenario

You are tasked to complete a technical exercise focusing on the implementation of backend functionalities for a hypothetical customer management API.

---

## Project Overview

The provided project structure includes:

- **Infra/Api/Program.cs**: Contains the API entry point, application setup, and middleware configuration.
- **Infra/Common/InMemoryCache.cs**: Implements thread-safe in-memory caching functionality.
- **Infra/Controllers/CustomersController.cs**: Manages API endpoints for customer operations.
- **Infra/Data/CustomerRepository.cs**: Handles customer-related database logic (currently unimplemented).
- **Infra/Data/CustomerDbContext.cs**: Defines the database context for managing customers.
- **CommBox.Tests/CustomersTests.cs**: Contains unit and integration test cases to validate API and business logic.

---

## Your Tasks

### 1. Implement the `GET /api/customers` Endpoint:
- **Functionality**:
  - Retrieve a list of customers from the database.
  - Use in-memory caching to optimize performance:
    - If the `forceRefresh` query parameter is `true`, bypass the cache and fetch fresh data.
    - Otherwise, return data from the cache if available.
- **Error Handling**:
  - Handle errors gracefully, ensuring proper logging for debugging.

### 2. Implement the `POST /api/customers` Endpoint:
- **Functionality**:
  - Requires **JWT-based authentication**.
    - Only users with the **`admin` role** are authorized to create customers.
  - Validate incoming requests:
    - Ensure the `Name` field is not empty.
  - Save new customer details to the database and return a **201 Created** response.
  - Clear or refresh the cache to ensure subsequent `GET` requests reflect the latest data.

### 3. Enhance the Cache Implementation:
- **Details**:
  - Update the in-memory cache to ensure thread safety using `ConcurrentDictionary`.

### 4. Unit and Integration Tests:
- **Requirements**:
  - Add and enhance test cases in `CustomersTests.cs` to validate the functionality of both endpoints.
  - Test edge cases:
    - Unauthorized access.
    - Invalid input.
    - Empty datasets.

---

## Technical Stack

- **Language**: C#
- **Framework**: ASP.NET Core
- **Database**: In-memory database (used in tests to simulate MSSQL).
- **Authentication**: JWT
- **Caching**: Thread-safe in-memory implementation

---

## Expected Output

- Clean, maintainable code adhering to best practices.
- Proper handling of errors and edge cases.
- At least 3-5 unit or integration tests demonstrating functional correctness.

---

## Evaluation Criteria

- Code readability and maintainability.
- Correctness and completeness of functionality.
- Handling of edge cases and error conditions.
- Quality and coverage of test cases.

---

## How to Run the Application

### 1. Install Dependencies:
- Open the project in **Visual Studio Code** or **Visual Studio**.
- Use the integrated terminal to restore NuGet packages:
  ```bash
  cd Infra/Api
  dotnet restore
  ```

### 2. Run the Application:
- Navigate to the `Infra/Api` directory:
  ```bash
  cd Infra/Api
  ```
- Start the application:
  ```bash
  dotnet run
  ```
- The application will be accessible at `http://localhost:5000` by default.

---

## How to Run the Tests

### 1. Install Dependencies:
- Open the project in **Visual Studio Code** or **Visual Studio**.
- Restore NuGet packages:
  ```bash
  dotnet restore
  ```

### 2. Run Tests:
- Navigate to the root directory containing the solution file:
  ```bash
  cd CommBox
  ```
- Execute tests using:
  ```bash
  dotnet test
  ```
- Review test results:
  - Verify that failing tests are due to unimplemented logic (expected behavior during simulation).

---

## Additional Notes

### Tests and Expected Failures:
- The provided tests in `CommBox.Tests/CustomersTests.cs` are currently failing as part of the simulation:
  - Missing JWT authentication in `POST /api/customers`.
  - Unimplemented database schema configuration in `CustomerDbContext.OnModelCreating`.
  - Unfinished in-memory caching logic.

### Next Steps for Completion:
- Implement missing features in:
  - `CustomersController` for authentication and role-based authorization.
  - `CustomerDbContext.OnModelCreating` for database schema configuration.
  - Thread-safe caching logic in `InMemoryCache`.
- Verify tests pass after implementing functionality.

### Deliverables:
- Submit the completed solution as a compressed file or repository link.
- Include instructions for running the application and tests locally.
