# 🚀 Shipment Management System

A complete **Shipment Management System** built with **ASP.NET Core**, applying **Clean Architecture** and **SOLID principles** to ensure scalability, maintainability, and real-world enterprise-level structure.

---

## 🧩 Project Overview

This system manages shipment operations, tracking, and workflow across multiple stages — from creation to delivery.  
It includes:
- A full **Admin Dashboard** to manage and monitor shipments.
- A **Base Website (User Interface)** to interact with API endpoints.
- A **Workflow** for shipment lifecycle (Created → Approved → ReadyForShipment → Shipped → Delivered → Returned → Deleted).

---

## ⚙️ Tech Stack

| Layer | Technology / Tools |
|-------|--------------------|
| **Frontend (UI)** | ASP.NET Core Razor / HTML / CSS / JS |
| **Backend (API)** | ASP.NET Core Web API |
| **Database** | SQL Server (Entity Framework Core) |
| **Mapping** | AutoMapper |
| **Architecture** | Clean Architecture (Domain, Data Access, Business Logic, UI) |
| **Patterns** | Repository, Unit of Work, Dependency Injection |
| **Validation** | Fluent API & Data Annotations |
| **Asynchronous** | Task / Await |
| **Localization** | Resource Files (multi-language support) |

---

## 🧠 Key Features Implemented

✅ **Clean Architecture Layers**
- Domain Layer  
- Data Access Layer (DAL)  
- Business Logic Layer (BL)  
- Base UI Layer  

✅ **Core Patterns**
- **Generic Repository**
- **Generic Service**
- **Unit of Work**
- **Dependency Injection**

✅ **Other Features**
- Authentication & Authorization  
- DTOs with AutoMapper  
- Fluent API & Data Annotations  
- Async/await & threading for better performance  
- Resource-based localization (all texts managed from one place)  
- Shipment workflow system:

Created → Approved → ReadyForShipped → Shipped → Delivered → Returned → Deleted




"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=Shipping;Trusted_Connection=True;MultipleActiveResultSets=true"
}

dotnet run
