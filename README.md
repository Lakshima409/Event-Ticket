# EventTicketingWebApp

Event Ticketing Web Application

An online event ticketing platform built with ASP.NET Core MVC and .NET 8. The system allows event organizers to create and manage events while customers can discover events, book tickets, and manage their bookings. It also includes administration tools, payment integration, promotional discounts, loyalty points, and digital ticket generation.



About the Project

The Event Ticketing Web Application is designed to simplify event management and online ticket booking through a role-based platform. It supports three main user types: administrators, event organizers, and customers.

User Roles

1. Administrators

Manage events, venues, and user accounts.

Generate reports and review sales analytics.

Oversee promotional campaigns and discounts.

Monitor system activity and performance.

2. Event Organizers

Create and manage events with detailed information.

Configure multiple ticket types and pricing tiers.

Track ticket sales and generate event-specific reports.

Manage venue bookings and event logistics.

3. Customers

Browse and search events by category, date, or location.

Book tickets and complete checkout using the PayHere sandbox.

View bookings and download digital tickets.

Earn and redeem loyalty points.

Apply promotional codes to eligible purchases.

Features

Event Management: Create, update, and manage events.

Ticket Management: Support multiple ticket types and pricing options.

Payment Integration: Test ticket purchases through the PayHere sandbox.

Role-Based Access: Separate functionality for administrators, organizers, and customers.

Reporting and Analytics: Review sales and event performance.

Loyalty Program: Support points-based customer rewards.

Promotional Discounts: Apply discount codes and promotional offers.

Email Notifications: Send booking confirmations and other notifications through the configured email service.

QR Code Tickets: Generate digital tickets containing QR codes.

PDF E-Tickets: Generate downloadable ticket documents.

Seed Data: Optionally populate the database with sample users, events, bookings, and related records.

Technology Stack

Technology

Purpose

.NET 8

Application platform

ASP.NET Core MVC

Web application framework

Entity Framework Core

Database access and ORM

Microsoft SQL Server

Relational database

Bootstrap

Responsive user interface

jQuery

Client-side interactions

PayHere Sandbox

Payment testing

Mailtrap Email Sandbox

Email testing and previewing

Prerequisites

Before running the application, ensure you have:

Visual Studio 2022 or later.

.NET 8 SDK.

SQL Server, LocalDB, or another supported SQL Server instance.

Git.

Getting Started

1. Clone the Repository

git clone https://github.com/anushkapubudu/EventTicketingWebApp.git
cd EventTicketingWebApp

2. Open the Solution

Open EventTicketingWebApp.sln in Visual Studio 2022 or later.

Restore the NuGet packages if Visual Studio does not restore them automatically.

3. Configure the Database

Open appsettings.json and configure the DefaultConnection connection string to match your local SQL Server setup.

Example for a local SQL Server instance:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=EventTicketDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
  }
}

Note: Adjust the server name and authentication settings to match your environment. TrustServerCertificate=True is intended for local development scenarios and should not be copied into a production configuration without reviewing the security implications.

4. Configure Seed Data (Optional)

To populate the database with sample data, update the Seeding section in appsettings.json:

{
  "Seeding": {
    "Enabled": true,
    "SeedAdminUser": true,
    "SeedUsers": true,
    "SeedEventCategories": true,
    "SeedEventVenues": true,
    "SeedEvents": true,
    "SeedTicketTypes": true,
    "SeedPromotionalDiscounts": true,
    "SeedBookings": true,
    "SeedTickets": true,
    "SeedLoyaltyPoints": true
  }
}

Merge this section into your existing appsettings.json rather than replacing the entire file.

When seeding is enabled, the application is configured to create sample records for the selected entities. The exact database initialization behavior depends on the project's implementation.

Security note: Only use demo credentials and seed data in a local development environment. Never deploy publicly accessible accounts with default passwords.

5. Configure Payment and Email Services

The project uses the PayHere sandbox for payment testing and Mailtrap for email testing.

Configure the relevant service credentials and settings using the configuration mechanism supported by the project. Do not commit real API keys, passwords, or service credentials to GitHub.

6. Run the Application

Build the solution in Visual Studio.

Ensure SQL Server is running and the connection string is correct.

Press F5 or select Start Debugging.

Open the application in your browser:

https://localhost:7197

The URL assumes the application's development launch settings use this address. Check Properties/launchSettings.json if the application starts on a different port.

Demo Accounts

When the relevant seed options are enabled, the project provides the following demo accounts according to its configuration.

Role

Email

Password

Administrator

admin@gmail.com

123456

Organizer

org@gmail.com

123456

Customer

cus@gmail.com

123456

These credentials are intended for local demonstration only. Confirm that the accounts are created successfully by your current seed configuration before using them.

Running Without Seed Data

If you prefer to start without sample events and bookings:

Disable the seeding options in appsettings.json.

Configure the initial administrator account using the project's supported AdminUser settings, if applicable:

{
  "AdminUser": {
    "Email": "your-admin@example.com",
    "Password": "Use-A-Strong-Local-Password",
    "Username": "admin"
  }
}

Run the application and follow its administrator initialization process.

Register organizer and customer accounts through the registration page, if registration is enabled.

Create event categories, venues, events, ticket types, and promotional discounts through the relevant administrative interfaces.

The actual initialization behavior depends on the project's configuration and implementation.

Testing Payment Functionality

The application uses the PayHere sandbox to test payment processing without making real payments.

Example Sandbox Card

Use the following test card details if they are supported by your configured PayHere sandbox environment:

Field

Test Value

Card number

4916217501611292

Cardholder name

Any valid test name

CVV

Any 3-digit test value

Expiry date

Any future date accepted by the sandbox

Testing Steps

Start the application.

Open an event with available tickets.

Proceed to checkout.

Enter the supported sandbox test-card details.

Complete the test payment.

Verify the booking status and confirmation.

Check that the digital ticket is generated as expected.

For additional test cards and declined-payment scenarios, consult the official PayHere sandbox documentation.

Important: Sandbox test cards are not for real purchases. Payment success depends on the gateway configuration and the application's payment callback handling.

Project Structure

The main project components include:

EventTicketingWebApp.sln — Visual Studio solution.

appsettings.json — Application and development configuration.

Properties/launchSettings.json — Local development launch profiles, if present.

MVC controllers, models, and views — Application request handling and user interface.

Entity Framework Core components — Database access and persistence.

Database seeding components — Optional sample-data initialization.

Static assets — CSS, JavaScript, images, and other frontend resources.

.screenshots/ — Project screenshots used in this README.

The exact directory structure may vary depending on the current repository version.

Learning Outcomes

This project demonstrates practical experience with:

Developing an ASP.NET Core MVC application.

Working with relational databases and Entity Framework Core.

Implementing role-based application workflows.

Managing event bookings and ticket pricing.

Integrating a payment gateway in sandbox mode.

Generating QR-code tickets and downloadable PDFs.

Configuring email notifications and sample database records.

Building a responsive web interface with Bootstrap and jQuery.

Future Improvements

Potential areas for further development include:

Production-ready payment configuration and verification.

Automated tests for booking and payment workflows.

Improved monitoring, logging, and error handling.

Additional accessibility and responsive-design improvements.

Deployment configuration for a secure production environment.

Copyright and Usage

Copyright © 2026 Lakshima Madurangi. All rights reserved.

This repository is publicly available for viewing and portfolio evaluation purposes only. No permission is granted to copy, modify, redistribute, or otherwise reuse the original source code without prior written permission from the copyright holder, except where applicable law permits otherwise.

Third-party components, dependencies, and assets remain subject to their respective licences.
