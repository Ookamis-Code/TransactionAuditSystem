# Transaction Audit System
### *C# Logic & System Integrity Study*

## Overview
This project is a high-integrity transaction processor designed to handle financial data with a focus on **Deduplication**, **Persistence**, and **Exception Handling**. It demonstrates the bridge between algorithmic logic and defensive system engineering.

## Key Features
- **Idempotency Logic:** Uses `HashSet` identity tracking to prevent duplicate transactions (derived from FaceID logic).
- **Persistence Layer:** Implements an automated audit trail that survives system restarts via `System.IO`.
- **Defensive Design:** Robust exception handling using specific `try-catch` blocks to prevent system failure during I/O operations.
- **Financial Precision:** Utilizes the `decimal` type to ensure zero rounding errors in balance calculations.

## How to Run
1. Ensure you have the [.NET 8 SDK](https://dotnet.microsoft.com) installed.
2. Open your terminal in this folder.
3. Run `dotnet run`.
4. Review the console output and the generated `audit_log.txt`.
