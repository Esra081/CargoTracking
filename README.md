# Cargo Tracking Website

A role-based cargo shipment and tracking web application built with **ASP.NET Core MVC (.NET 7)**, **Entity Framework Core** and **SQL Server**.

Customers create shipment requests and follow their packages with a tracking number; personnel approve requests and update each shipment's status along its route. Every status change is stored, so the full delivery history of a package can be viewed.

## Features

**Customer**
- Register / log in (ASP.NET Core Identity)
- Create a new shipment request (sender, receiver, addresses, weight, package description)
- Track a shipment by tracking number
- View the full status history of own shipments
- Manage profile

**Personnel**
- Dashboard and order list
- Approve or reject pending shipment requests
- Update shipment status (directly or by tracking number), with branch information
- Manage branches, customers, employees and tracking status definitions (CRUD)

**General**
- Role-based access (Customer / Personnel) with Identity and session
- Shipment status history table (`ShipmentStatusHistory`) recording status, branch, user and time
- Public pages: home, services, about us, why us, blog, contact

## Tech Stack

| Layer | Technology |
| --- | --- |
| Backend | C#, ASP.NET Core MVC (.NET 7) |
| Data | Entity Framework Core 7 (Code First, migrations), SQL Server |
| Auth | ASP.NET Core Identity, roles, session |
| Frontend | Razor Views, Bootstrap, jQuery |

## Data Model

`AppUser` (Identity) · `Customer` · `Employee` · `Branch` · `Shipment` · `ShipmentStatusHistory` · `TrackingStatus`

## Getting Started

1. Install the .NET 7 SDK and SQL Server (or LocalDB).
2. Update `DefaultConnection` in `CargoTrackingg/CargoTrackingg/appsettings.json` to point to your SQL Server instance.
3. Create the database:
   ```bash
   cd CargoTrackingg/CargoTrackingg
   dotnet ef database update
   ```
4. Run the app:
   ```bash
   dotnet run
   ```

On first run a demo personnel account is created: `personel1@cargo.com` / `Test@1234` (for local testing only).
