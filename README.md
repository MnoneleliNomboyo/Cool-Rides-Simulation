🚗 Cool Rides Production Simulation

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows%20Forms-0078D4?style=for-the-badge&logo=windows&logoColor=white)


📌 Overview
Cool Rides Production Simulation is a Windows Forms application that simulates an automobile manufacturing environment. The system manages two parallel assembly lines (cars and minibuses), a shared spraybooth, and a real‑time GUI that displays queue counts and status updates.

This project was developed as an assignment for IRUD301 to demonstrate the practical application of four key software design patterns.

🎯 Features
✅ Concurrent assembly lines – cars and minibuses are built simultaneously

✅ Realistic timing – each part and assembly step respects specified durations

✅ FIFO order processing – orders are executed in the sequence they arrive

✅ Shared spraybooth – processes one vehicle at a time (Singleton pattern)

✅ Live GUI updates – queue counters and status messages refresh every 200ms

✅ Thread‑safe – uses async/await, Task.Run, and Control.Invoke

🏗️ Design Patterns Implemented
Pattern	Implementation
Abstract Factory:	IVehiclePartsFactory, CarPartsFactory, MinibusPartsFactory
Factory Method:	VehicleFactory, CarFactory, MinibusFactory
Command:	IOrderCommand, BuildCarCommand, BuildMinibusCommand, assembly lines as invokers
Singleton:	Spraybooth with double‑checked locking
🕹️ Production Timings
Step	Car	Minibus
Chassis	2 seconds	2 seconds
Shell	2 seconds	3 seconds
Each wheel (×4)	0.5 second	0.5 second
Interior trim	1 second	2 seconds
Assembly	2 seconds	3 seconds
Painting (spraybooth)	5 seconds	7 seconds
🖥️ GUI Preview
<img width="878" height="455" alt="image" src="https://github.com/user-attachments/assets/df3808d4-aeef-46f8-8c67-b0c941ca0a00" />


🚀 Getting Started
Prerequisites
Visual Studio 2022 (or later)

.NET 6.0 or .NET 8.0 SDK

Windows OS (for Windows Forms)

Installation & Running
Download the ZIP folder and extract the solution

Open the solution
Double‑click IRUD_Assignment_StartUp.sln (or open via Visual Studio)

Build the project
Ctrl + Shift + B or Build → Build Solution

Run the application
F5 or click Start

Place orders

Select a vehicle type and colour using the radio buttons

Click the Order button

Watch the queue counters and status messages update in real time

🧪 Testing
Place multiple orders for the same assembly line to verify:

FIFO order execution

Queue count increments and decrements correctly

Spraybooth processes only one vehicle at a time

All timings match specifications


👥 Group Members
Name	Student Number
Naledi Mabuya

Anathi Silangwe: @AnathiSilangwe

Mnoneleli Nomboyo: @MnoneleliNomboyo

Lethabo Mothabeng: @Lethabo-joy

📚 Technologies Used
C# – primary programming language

.NET Windows Forms – GUI framework

Task Parallel Library (TPL) – threading and concurrency

Draw.io – class diagram creation

📄 Assignment Requirements Met
Singleton pattern (spraybooth)

Abstract Factory pattern (parts families)

Factory Method pattern (vehicle creation)

Command pattern (order queuing)

Real‑time GUI with queue counters

Thread safety and concurrency

All build and painting timings accurate

FIFO order execution per assembly line

📖 License
This project was created for academic purposes as part of the IRUD301 module.
All rights reserved by the group members.



Built with 💻 by Synchronized Strategy
Submission Date: 18/05/2026
