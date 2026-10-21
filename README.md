# EventTicketingWebApp
# Event Ticketing Web Application

A web-based event ticketing platform built with **ASP.NET Core 8, Entity Framework Core, and SQL Server**. It supports event management, ticket bookings, promotional discounts, loyalty points, payment testing, and digital ticket generation.

![Home Page](.screenshots/index.png)

## Features

- **Event Management:** Create, update, and manage events, venues, categories, and ticket types.
- **User Roles:** Separate access for administrators, organizers, and customers.
- **Booking System:** Book tickets, apply discount codes, and redeem loyalty points.
- **Payment Integration:** Test ticket purchases using the PayHere sandbox.
- **Digital Tickets:** Generate QR-code tickets and downloadable PDF e-tickets.
- **Email Notifications:** Send booking confirmations using the configured email service.
- **Reports and Analytics:** Review bookings, sales, and event performance.
- **Database Seeding:** Optionally populate the database with sample records.
- **Security:** Authentication, role-based access, session management, and password hashing.

## Technology Stack

| Technology | Purpose |
|---|---|
| ASP.NET Core 8 MVC | Web application |
| Entity Framework Core 8 | Database access |
| Microsoft SQL Server | Database |
| ASP.NET Core Identity | Authentication |
| Bootstrap, jQuery | User interface |
| PayHere Sandbox | Payment testing |
| Mailtrap | Email testing |
| Git | Version control |

## Prerequisites

- Visual Studio 2022 or later
- .NET 8 SDK
- SQL Server, SQL Express, or LocalDB
- Git

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/anushkapubudu/EventTicketingWebApp.git
cd EventTicketingWebApp
```

### 2. Open the Project

Open `EventTicketingWebApp.sln` in Visual Studio 2022 or later and restore the NuGet packages.

Alternatively, run:

```bash
dotnet restore
```

### 3. Configure the Database

Update the `DefaultConnection` in `appsettings.json` to match your SQL Server instance.

Example for local development:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EventTicketDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
  }
}
```

Review the connection settings for your environment. The certificate option shown is intended for local development, not automatically for production.

### 4. Apply Database Migrations

```bash
dotnet ef database update
```

If required, install the Entity Framework CLI:

```bash
dotnet tool install --global dotnet-ef
```

### 5. Configure Optional Seed Data

Sample users, events, venues, bookings, tickets, and other records can be enabled through the `Seeding` section of `appsettings.json`. Merge the required settings into your existing configuration rather than replacing the entire file.

Check the project's seed configuration for the actual demo accounts and initialization behavior.

### 6. Configure Payment and Email Services

Configure the PayHere sandbox and Mailtrap credentials using the project's supported settings. Never commit real API keys, passwords, or service credentials to GitHub.

### 7. Run the Application

In Visual Studio, press **F5** or select **Start Debugging**.

Alternatively:

```bash
dotnet run
```

Open the local URL shown in the terminal or configured in `Properties/launchSettings.json`. The exact port may vary.

## Demo Accounts

The project documentation lists these sample accounts when the corresponding seed configuration is enabled:

| Role | Email | Password |
|---|---|---|
| Administrator | `admin@gmail.com` | `123456` |
| Organizer | `org@gmail.com` | `123456` |
| Customer | `cus@gmail.com` | `123456` |

The project also documents a separate administrator account. Actual credentials depend on the current seeding implementation, so verify them locally. These credentials are for demonstration only and must never be used in a public deployment.

## Testing Payments

The application uses the PayHere sandbox to test checkout without making real payments.

Example test card, if supported by your sandbox configuration:

- **Card number:** `4916217501611292`
- **Cardholder name:** Any valid test name
- **CVV:** Any three-digit test value
- **Expiry:** Any future date accepted by the sandbox

To test, select an event, proceed to checkout, complete the sandbox payment, and verify the booking status, confirmation, and generated ticket. Consult PayHere's official sandbox documentation for additional test scenarios.

## Project Architecture

The application follows a layered structure:

- **Controllers:** Handle application requests.
- **Business:** Contains services and interfaces.
- **Data:** Manages the database context, entities, and migrations.
- **Models:** Contains view models.
- **Helpers:** Provides utilities and enums.
- **Middleware:** Handles custom authentication-related processing.
- **Views and Static Assets:** Provide the user interface.

Key entities include `User`, `Event`, `EventCategory`, `EventVenue`, `TicketType`, `Booking`, `Transaction`, `PromotionalDiscount`, `LoyaltyPointsTransaction`, and `Report`.

## Learning Outcomes

This project demonstrates experience in ASP.NET Core MVC development, relational database design, authentication and authorization, event booking workflows, payment sandbox integration, QR/PDF ticket generation, email configuration, and responsive web development.

## Future Improvements

- Strengthen production payment verification and configuration.
- Expand automated tests for booking and payment workflows.
- Improve monitoring, logging, and error handling.
- Enhance accessibility and deployment security.

## Contributing

Fork the repository, create a feature branch, follow the existing coding style, add tests where appropriate, and submit a pull request.

## Copyright and Usage

Copyright © 2026 Lakshima Madurangi. All rights reserved.

This repository is publicly available for viewing and portfolio evaluation. Copying, modifying, or redistributing the original source code requires prior written permission, except where applicable law permits otherwise. Third-party components, dependencies, and assets remain subject to their respective licences.


