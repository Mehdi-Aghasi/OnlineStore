# 🛒 OnlineStore Backend API

![.NET](https://img.shields.io/badge/.NET-8.0%2F9.0-512BD4?style=flat&logo=dotnet)
![C#](https://img.shields.io/badge/C%23-12-239120?style=flat&logo=c-sharp)
![EF Core](https://img.shields.io/badge/EF%20Core-Code--First-512BD4)
![Architecture](https://img.shields.io/badge/Architecture-Clean-blue)
![Pattern](https://img.shields.io/badge/Pattern-CQRS-green)

A robust, scalable, and secure RESTful API for an E-commerce platform built with **.NET Core**, adhering to **Clean Architecture** principles and the **CQRS** pattern.

---

## 🏗️ Architecture

The solution follows the **Clean Architecture (Onion Architecture)** approach to ensure separation of concerns and maintainability:

- **Domain Layer:** Entities, Value Objects, Enumerations, Repository Interfaces (Core logic, no dependencies).
- **Application Layer:** CQRS (Commands/Queries), DTOs, Validators, Mappers, Interfaces.
- **Infrastructure Layer:** EF Core DbContext, Repository Implementations, Identity Service, Migrations.
- **Presentation Layer:** Web API Controllers, Swagger, DI Setup.

---

## 🛠️ Technologies & Libraries

- **Framework:** .NET 8 / .NET 9
- **Language:** C# 12
- **Database:** SQL Server
- **ORM:** Entity Framework Core (Code-First)
- **Auth:** ASP.NET Core Identity + JWT Bearer
- **Mediator:** MediatR (for CQRS)
- **Validation:** FluentValidation
- **Mapping:** AutoMapper
- **Documentation:** Swagger / Swashbuckle
- **Logging:** Built-in Logging

---

## ✨ Key Features

### 🔐 Authentication & Authorization
- User Registration & Login
- JWT Token Generation & Validation
- Role-Based Access Control (Admin, Customer)

### 📦 Product Management
- Create, Update, Delete Products (Admin)
- View Products & Details
- Categorization

### 🛒 Shopping Cart
- Add/Remove Items
- Persistent Cart per User
- Calculate Totals

### 📋 Order Management
- Checkout & Order Creation
- Order History
- Status Tracking (Pending, Paid, Shipped)

### 💳 Payment
- Mock Payment Gateway Implementation
- Verify Transactions

---

## 🚀 Getting Started

Follow these steps to run the project locally:

### Prerequisites
- .NET SDK (8.0 or later)
- SQL Server (LocalDB or Docker)

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/YOUR-USERNAME/OnlineStore.git
   cd OnlineStore