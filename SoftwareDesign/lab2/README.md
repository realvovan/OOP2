# Messaging Application (C#)
## Project Description

This project is a simple messaging application built using C# and ASP.NET Core. It supports direct messages and group chats, allowing users to send and receive messages in real time.

The backend uses a REST API for core operations (sending messages, retrieving history) and SignalR for real-time communication between clients. Messages are stored in a database, and a queue system is used to handle message processing asynchronously.

This project is designed as a university lab assignment and demonstrates concepts such as layered architecture, dependency injection, real-time communication, and database interaction.

## How to Run the Program
#### 1. Requirements
* .NET SDK (6 or newer)
* SQLite (or included via EF Core
#### 2. Setup

Clone the repository:

*git clone \<your-repo-url>*

*cd \<your-project-folder>*

Restore dependencies:

*dotnet restore*

Apply database migrations (if used):

*dotnet ef database update*

#### 3. Run Backend

*dotnet run*

The API will start (typically at):

http://localhost:5000

SignalR hub endpoint:

/chat

#### 4. Run Frontend (WinForms)
Open the solution in Visual Studio

Set the WinForms project as startup project

Run the application

## Project Structure
/models

&emsp;Data models (User, Message, Channel, etc.)

/services

&emsp;Business logic (MessageService, UserService, QueueService, AuditLogService)

/storage

&emsp;Database context and configurations (Entity Framework)

/main

&emsp;Application entry point (Program.cs)

## Implemented Features
* Direct messaging between users
* Real-time message delivery using SignalR
* Message storage in database
* Queue-based message processing
* Audit logging of user actions