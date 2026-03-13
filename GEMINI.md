# QuickDownloader - Project Context

## Project Overview

**QuickDownloader** is a local GUI application designed for downloading YouTube videos and playlists. It is built using C# and WPF, utilizing `yt-dlp` as the core downloading engine and `ffmpeg` for media processing tasks.

- **Target OS:** Windows 10 and later.
- **Language/Framework:** C# / .NET / WPF.
- **Key Capabilities:** Auto-startup, auto-update, toast notifications, localization (EN, VN), dark/light theming, auto-download from clipboard, quick-download, robust task management, and flexible config profiles.

## Architecture & Structure

The codebase is organized into a modular structure:

- **`docs/`**: Extensive project documentation including API, Architecture, UI/UX, Testing, and overall Project guidelines (`PROJECT.md`).
- **`src/`**: The main source code, split into:
  - **`QuickDownloader.Core`**: The backend logic handling downloads, background services (`DownloadManager`, `FFmpegService`, `YtDlpService`), models, and an IPC Server.
  - **`QuickDownloader.GUI`**: The frontend WPF application, employing the MVVM pattern (Models, Views, ViewModels) and an IPC Client.
  - **`QuickDownloader.Shared`**: Shared models, constants, and interfaces to facilitate communication between Core and GUI.
- **`tests/`**: Unit and integration tests for Core and GUI projects.
- **`tools/`**: External binary dependencies (`ffmpeg.exe`, `yt-dlp.exe`).
- **`assets/`**: Images, icons, and localization resources (`.resx` files).

## Building, Running, and Testing

Based on standard .NET development practices, the following commands apply:

- **Build the Solution:**
  ```bash
  dotnet build QuickDownloader.sln
  ```
- **Run the Application:**
  ```bash
  dotnet run --project src/QuickDownloader.GUI/QuickDownloader.GUI.csproj
  ```
  *(Note: You may need to ensure `QuickDownloader.Core` is also running if it operates as a separate backend service communicating via IPC.)*
- **Run Tests:**
  ```bash
  dotnet test QuickDownloader.sln
  ```

## Development Conventions

- **Design Pattern:** The GUI strictly follows the MVVM (Model-View-ViewModel) architecture.
- **Inter-Process Communication (IPC):** Communication between the `Core` and `GUI` is handled via IPC (`IPCServer.cs` and `IPCClient.cs`).
- **Development Phases:** The project is being developed in strict phases (outlined in `docs/project_guide/PROJECT.md`). Consult the documentation before introducing new features to ensure they align with the current development phase.
- **Documentation:** Changes to core functionality, API, or UI/UX should be reflected in the respective markdown files within the `docs/project_guide/` directory.

> **Note to AI Agent:** Before implementing or modifying significant chunks of logic, always review `docs/project_guide/PROJECT.md` and related documentation to stay aligned with the project's phased roadmap.
