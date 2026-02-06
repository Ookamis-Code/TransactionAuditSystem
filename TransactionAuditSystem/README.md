# Transaction Audit System
### *Stateful System Architecture & Data Integrity Study*

## Overview
This project is a high-integrity transaction processor designed to simulate a professional banking middleware. It focuses on **Idempotency**, **Relational Persistence**, and **Automated Quality Assurance**. By bridging algorithmic logic with a durable database backend, it ensures that financial state remains consistent even across system restarts.

## Key Features
- **Relational Persistence (SQLite):** Implements a professional data layer using [Microsoft.Data.Sqlite](https://learn.microsoft.com). Transactions are "committed" to a relational table using **Parameterized Queries** to prevent SQL Injection.
- **State Hydration Logic:** Upon system startup, the engine "hydrates" its internal memory (HashSet) by querying the database. This ensures **Deduplication** persists across reboots.
- **Automated Unit Testing (xUnit):** Includes a dedicated test suite using [xUnit](https://xunit.net) to verify "Guard Clause" logic and deduplication integrity, ensuring the system remains "Bulletproof" during refactoring.
- **Defensive I/O Engineering:** Features a dual-logging strategy using both a SQL database for primary state and a flat-file audit trail with robust `try-catch` exception handling for redundancy.
- **Financial Precision:** Strictly utilizes the `decimal` type for all currency calculations to eliminate binary rounding errors common in floating-point types.

## Technical Stack
- **Language:** C# 12.0 (.NET 8 SDK)
- **Database:** SQLite (Relational)
- **Testing:** xUnit Framework
- **Tooling:** VS Code, .NET CLI, Git

## How to Run
1. Ensure you have the [.NET 8 SDK](https://dotnet.microsoft.com) installed.
2. Clone the repository and navigate to the project root.
3. To run the application: 
   ```bash
   dotnet run --project TransactionAuditSystem
