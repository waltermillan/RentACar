# 🚗 Rent A Car Project

Car rental application — a classic CRUD system. This platform enables efficient, secure, and fast vehicle rental management. You can monitor all active rentals, add new vehicles to the fleet, and register customers with ease.

---

## 📅 Changelog

- **14/02/2025**: Initial release — Backend, Frontend, and Database.
- **26/02/2025**: 
  - **Backend**: API refactored to follow RESTful conventions, ensuring route correctness and pluralization.  
  - **Frontend**: URL invocation fixes.
- **05/04/2025**: 
  - **Backend**: Added `User` entity and login module. Also added `Users` and `Roles` tables, including full DDL scripts for all entities.
  - **Frontend**: Implemented localStorage to persist user session data. Improved UI styling and cleaned up code. Added component testing using `ng test` (Karma/Jasmine) — several fixes were made thanks to this.
  - Used **Angular Material** for message popups.  
  - Added Entity-Relationship Diagram (ERD).

---

## 🎯 Objective

To practice building a full-stack application using .NET (C#), SQL, and Angular (TypeScript), incorporating design patterns and Onion Architecture. The system connects to a SQLite database via Entity Framework and uses Docker and DBeaver for environment setup and management.

### Technologies:

- **.NET (C#)** and **SQL Server**
- **Angular (TypeScript)**
- **Design Patterns**
- **Onion Architecture**

---

## 🚀 Features

### 🔧 Backend

- Structured around **Onion Architecture**
- Implements several **Design Patterns**:
  - `BaseEntity`
  - `UnitOfWork`
  - `Repository`
  - `DTO` (Data Transfer Object)
- **Key Libraries**:
  - **Encryption**:
    - `System.Security.Cryptography` (AES-256)
  - **Logging**:
    - `Serilog`
    - `Serilog.Extensions.Logging`
    - `Serilog.Sinks.File`
  - **ORM**:
    - `Microsoft.EntityFrameworkCore.SqlServer`
    - `Microsoft.EntityFrameworkCore.Tools`

---

### 💻 Frontend

- Built with **Angular 18.2.14**
- Features:
  - Reactive Forms
  - `AuthService` and HTTP Interceptors
  - Custom Pipes and Shared Modules
  - Angular Material for UI components and popups
  - Unit testing with Karma and Jasmine (`ng test`)

---

### 🗄️ Database

- Uses **MariaDB**, deployed via **Docker Desktop**
- Includes:
  - Entity-Relationship Diagram (ERD)
  - Sample data insertion scripts (`.sql`)
  - **DDL scripts** (for schema creation)
  - **DML scripts** (for sample data insertion)

---

## 🧪 Installation

### ✅ Prerequisites

Make sure the following tools are installed on your machine:

- [.NET SDK 9.0.200](https://dotnet.microsoft.com/)
- [Docker Desktop 4.40.0+](https://www.docker.com/)
- [Node.js + npm](https://nodejs.org/) (for the frontend)
- [Postman 11.44.3](https://www.postman.com/downloads/)

---

### 🔧 Setup Steps

1. Clone the repository:
    ```bash
    git clone https://github.com/waltermillan/RentACar.git
    ```

2. Follow the setup video guide (coming soon):
    - [Version 1 - Display Version](#)

3. Complete the remaining setup steps as described in the project documentation.

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).
