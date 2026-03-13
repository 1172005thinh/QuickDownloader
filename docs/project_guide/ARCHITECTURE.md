# ARCHITECTURE

This document outlines the high-level architecture of the Quick Downloader application.

## 1. System Architecture

Quick Downloader employs an **In-Process Architecture** utilizing the MVVM (Model-View-ViewModel) design pattern. The application runs as a single process (the WPF GUI) which holds references to the Core logic library. It does not use a background Windows Service or Inter-Process Communication (IPC), ensuring a simplified development lifecycle and reduced overhead.

When "minimized to system tray", the WPF Window is simply hidden (`Visibility = Collapsed`), while the application process continues to run, manage downloads, and monitor the clipboard.

## 2. Component Diagram

```plaintext
+-----------------------------------------------------------+
|                  QuickDownloader.GUI                      |
|  +---------+   +--------------+   +-------------------+   |
|  |  Views  |-->|  ViewModels  |-->| Application State |   |
|  +---------+   +--------------+   +-------------------+   |
+-------|----------------|----------------------------------+
        |                | Data Binding / Commands
+-------v----------------v----------------------------------+
|                  QuickDownloader.Core                     |
|  +----------------+  +-----------------+  +------------+  |
|  | DownloadManager|  | ConfigService   |  | UpdateMgr  |  |
|  +--------|-------+  +-----------------+  +------------+  |
|           v                                               |
|  +----------------+  +-----------------+                  |
|  |  YtDlpService  |  | FFmpegService   |                  |
|  +--------|-------+  +--------|--------+                  |
+-----------|-------------------|---------------------------+
            |                   | Process Execution
     +------v------+     +------v------+
     | yt-dlp.exe  |     | ffmpeg.exe  |
     +-------------+     +-------------+
```

## 3. Core Components

### 3.1 Frontend (`QuickDownloader.GUI`)
- **App.xaml.cs**: Handles application lifecycle, single-instance enforcement, system tray integration, and theme initialization.
- **Views**: XAML definitions built using `ModernWpf` for a modern Windows 10/11 look and feel.
- **ViewModels**: Implements `INotifyPropertyChanged`. Acts as the bridge between the UI and the Core services.

### 3.2 Backend (`QuickDownloader.Core`)
- **DownloadManager**: Manages the queue of `DownloadTask` objects. Handles concurrent limits, pause/resume logic, and cancellation.
- **YtDlpService**: A wrapper around `yt-dlp.exe`. Constructs CLI arguments based on user config profiles, reads standard output to extract progress, and handles errors.
- **FFmpegService**: A wrapper around `ffmpeg.exe` for post-processing tasks (e.g., merging video and audio).
- **ConfigService**: Handles serialization and deserialization of application settings and download profiles to/from JSON.
- **ClipboardMonitorService**: Hooks into the Windows clipboard API to detect YouTube URLs when Auto-Download is enabled.

## 4. Data Flow

1. **User Action**: User enters a URL and clicks "Download" in the View.
2. **ViewModel**: Validates the URL and creates a new `DownloadTask` model.
3. **Core Request**: ViewModel passes the `DownloadTask` to the `DownloadManager`.
4. **Execution**: `DownloadManager` assigns the task to `YtDlpService`.
5. **CLI Process**: `YtDlpService` spawns `yt-dlp.exe` with arguments, intercepting `stdout` via events.
6. **Progress Update**: `YtDlpService` fires progress events -> `DownloadManager` updates `DownloadTask` -> ViewModel notifies View -> Progress bar updates.

## 5. Threading Model

- **UI Thread**: Exclusively handles UI rendering and user interactions. No blocking operations.
- **Task Parallel Library (TPL)**: All core services use `async/await`. 
- **Process Threads**: External processes (`yt-dlp`, `ffmpeg`) run in their own OS threads. Output reading is handled asynchronously.
- **Concurrency**: `DownloadManager` limits simultaneous downloads using a `SemaphoreSlim`.

## 6. Error Handling

- **Local Validation**: Fast-fail URL validation and configuration checking.
- **CLI Errors**: `stderr` from external processes is captured and parsed to provide user-friendly error messages via Toast Notifications.
- **Global Catch**: Unhandled exceptions in the GUI are caught in `App.xaml.cs` (`DispatcherUnhandledException`), logged via Serilog, and presented to the user safely to prevent hard crashes.
