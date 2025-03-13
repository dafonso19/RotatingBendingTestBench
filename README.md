# RotatingBendingTestBench

Hey there! This is my project for a rotating bending test bench web app.

I built it to simulate tests, save results, and show them in a table and graph.

I made a web app using ASP.NET Core to simulate a test

## Overview

- **Setup**: Started with a basic ASP.NET Core MVC project with SQLite to store data. I made models for `TestSimulator` (the test), `TestData` (steps), and `TestResult` (timestamp, speed, stress, temp).
- **Form**: Added a form at `/Test` to input a test name, rotation speed (RPM), and duration (seconds). Right now, it only takes 1 step (so "Data: 1" always).
- **Simulation**: When you click "Start Test", it saves the test, runs (adds some random variation to speed, stress, and temp), and saves results to the database.
- **Results Page**: After the test, you go to `/Test/Result/{id}`. It shows the test name, how many steps (Data) and results, a table with timestamps, speed, stress, and temp, and a graph of speed over time.


## How to Run the Project

**Get the Code**: Clone it or download the zip

**Set Up the Database**:

-Go to the project folder and drop any old database `dotnet ef database drop` 
- Add a migration: `dotnet ef migrations add InitialCreateWithTestSimulator`
- Update the database: `dotnet ef database update`

**Run the App**:
- Start the app: `dotnet run`
- Or open in Visual Studio and hit F5.

**Use the App**:

- Fill in a test name (like "Test 1"), speed (like 1000 RPM), and duration (like 10 seconds).
- Click "Start Test".
- You’ll see the results at `/Test/Result/{id}` with a table and graph.

## Limitations

**Only 1 Step**: The form only lets you add 1 step, so "Data: 1" is always 1.
**Results Count**: For a 10-second test, I get 9 results sometimes instead of 10.
**Database**: Using SQLite, which is fine for now, but might need a bigger database
