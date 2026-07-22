# 2D Relativistic Particle Simulator

![C#](https://img.shields.io/badge/Language-C%23-blue?style=flat-square)
![Framework](https://img.shields.io/badge/Framework-.NET-512BD4?style=flat-square)
![Graphics](https://img.shields.io/badge/Graphics-Raylib--cs-informational?style=flat-square)

An interactive 2D physics simulation built in C# using **Raylib-cs**. The engine models Newtonian gravitational acceleration alongside relativistic event horizon bounds (Schwarzschild radius) to simulate particle trajectory deflections around a massive body.

---

## Key Features

* **Real-time Physics Engine:** Calculates Newtonian acceleration using inverse-square gravitational forces ($F = G \frac{m_1 m_2}{r^2}$) and delta-time numerical integration.
* **Event Horizon Absorption:** Dynamically calculates the Schwarzschild radius ($r_s = \frac{2GM}{c^2}$) and handles particle consumption upon crossing the event horizon.
* **Coordinate Mapping:** Transforms astronomical physics coordinates (meters) to screen-space pixel coordinates ($800 \times 600$ viewport).
* **Hardware-Accelerated Rendering:** Utilizes `Raylib-cs` bindings to maintain target 60 FPS rendering of dynamic particle systems.

---

## Technical Architecture

The codebase follows Object-Oriented Programming (OOP) principles, neatly separating physics constants, vector mathematical helpers, entity state, and rendering loops:

* `BlackHoleClass`: Represents the gravitational center and handles physics-to-screen coordinate mapping.
* `Particle`: Encapsulates velocity, mass, kinematic updates, and positional state.
* `BlackHoleMathHelper`: Static utility executing distance-squared computations, scalar force values, and event horizon radii.
* `Constants`: Centralized configuration defining physical constants (e.g., speed of light $c$, gravitational constant $G$, mass parameters).

---

## Mathematical Concepts Implemented

1. **Newtonian Gravitational Force:**
   $$F = G \frac{M \cdot m}{r^2}$$

2. **Acceleration & Kinematic Updates:**
   $$\vec{a} = \hat{d} \cdot \frac{F}{m}, \quad \vec{v}_{t+1} = \vec{v}_t + \vec{a} \cdot \Delta t, \quad \vec{p}_{t+1} = \vec{p}_t + \vec{v}_{t+1} \cdot \Delta t$$

3. **Schwarzschild Radius (Event Horizon Boundary):**
   $$r_s = \frac{2GM}{c^2}$$

---

## Tech Stack

* **Language:** C# (.NET)
* **Graphics Library:** [Raylib-cs](https://github.com/ChrisBoxx/Raylib-cs)
* **Math Library:** `System.Numerics.Vector2`

---

## Getting Started

### Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or higher)

### Installation & Running

1. Clone the repository:
   ```bash
   git clone [https://github.com/YOUR_GITHUB_USERNAME/BlackHoleSimulation.git](https://github.com/YOUR_GITHUB_USERNAME/BlackHoleSimulation.git)
   cd BlackHoleSimulation
