# Hospital Care Database & Interface System

A full-stack database application combining a robust relational backend with a responsive desktop frontend interface. 

##  Database Architecture & UI
<img width="997" height="600" alt="Login1" src="https://github.com/user-attachments/assets/ba92bbad-8cea-4d6b-8623-219a5e145002" />
<img width="1187" height="652" alt="HP1" src="https://github.com/user-attachments/assets/979bb908-f394-4123-9e2f-3d12d834a87d" />
<img width="816" height="1024" alt="Hospital Management System ER diagram" src="https://github.com/user-attachments/assets/6f9b9400-2da7-40bf-9266-0646fa81a0ad" />


##  Tech Stack & Tools Used
* **Frontend Interface:** Visual Studio 2026 Community Edition (C# / .NET)
* **Backend Database:** MySQL Server
* **Database Management:** MySQL Workbench

##  Key Features
* **Relational Database Design:** Fully structured relational tables managing connected records securely.
* **CRUD Operations:** Complete frontend interface to Create, Read, Update, and Delete records directly from the database.
* **Data Integrity:** Implemented primary keys, foreign key constraints, and structured queries to prevent data anomalies.

##  How to Run and Set Up the Project

### 1. Database Setup
1. Open **MySQL Workbench** and connect to your local instance.
2. Open and execute the `database_setup.sql` file included in this repository to automatically generate the database schema, tables, and relationships.

### 2. Frontend Interface Setup
1. Open **Visual Studio**.
2. Open the solution file (`.sln`) located inside the project folder.
3. Check your database connection string in the code (e.g., `App.config` or database connection class) to ensure it matches your local MySQL `username` and `password`.
4. Press **Start** to run the application interface.
