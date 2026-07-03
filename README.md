# 🎮 Royal Run

An endless runner game made in Unity based on the course Complete C# Unity 3D Game Development in Unity 6.

---

## 📝 Project Description

Play as a king making his escape through falling objects and dangerous spikes and see how far you can get! Collect coins and power-ups along the way!

* **Key Features:** Physics for objects, speed up mechanic, save highscores
* **Genre & Mechanics:** Action, Endless Runner
* **Platforms:** PC

---

## 🚀 Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### 📋 Prerequisites

To open and modify this project, you will need:
* **Unity Hub** installed.
* **Unity Editor** version `6000.3.7f1`
* A compatible IDE (e.g., **Visual Studio**, **Rider**, or **VS Code** with Unity extensions).
* **Git** installed on your system.

### 🛠️ Installation & Setup

1. **Clone the Repository**
   ```bash
   git clone https://github.com/Murilo-Matsuora/royal-run-game.git
   cd royal-run-game
   ```
   
2. **Open the Project in Unity**
   * Launch **Unity Hub**.
   * Click the **Add** button (or **Open** > **Add project from disk**).
   * Navigate to the directory where you cloned the repository and select the root folder (the folder containing the `Assets`, `Packages`, and `ProjectSettings` directories).
   * Ensure the Editor version matches the one specified for the project. If prompted, download the correct version via Unity Hub.

3. **Initial Compilation**
   * Allow Unity to import assets and generate local library files (this may take a few minutes on the first launch).
   * Open the primary scene from the Project window: `Assets/Scenes/Main.unity` (or your initial scene name).

---

## 🕹️ How to Run & Play

### Within the Unity Editor
1. Open the project in the Editor.
2. Open the main menu or starting scene: `Assets/Scenes/MainMenu.unity`.
3. Click the **Play** button (▶️) at the top center of the editor layout.

### Building a Standalone Executable
1. Go to `File` > `Build Settings...`.
2. Select your target platform (e.g., **PC, Mac & Linux Standalone**).
3. Ensure all necessary scenes are included in the **Scenes In Build** list.
4. Click **Build**, select a destination directory (commonly a `Builds/` folder ignored by Git), and run the resulting executable file.

---

### 🎮 Controls
* **Move:** `W`, `A`, `S` and `D`
* **Jump:** `Spacebar`

---

## 🛠️ Built With

* [Unity](https://unity.com/) - Game Engine
* [C#](https://learn.microsoft.com/en-us/dotnet/csharp/) - Programming Language


---

![Royal Run Gameplay](Documentation/RoyalRun.gif)
