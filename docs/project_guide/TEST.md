# TESTING STRATEGY

This document outlines the testing methodologies and frameworks for Quick Downloader to ensure reliability and maintainability.

## 1. Testing Frameworks

- **Primary Framework**: xUnit (Standard, modern testing framework for .NET)
- **Mocking**: Moq (For simulating external services and I/O)
- **Assertions**: FluentAssertions (For highly readable test definitions)

## 2. Test Projects

### `QuickDownloader.Core.Tests`
Focuses on unit testing the backend business logic without needing a UI.
- **Regex & Parsers**: Strict unit tests for parsing `yt-dlp` console output strings into `DownloadProgress` objects.
- **URL Validation**: Tests against various valid/invalid YouTube, Shorts, and Playlist URLs.
- **DownloadManager**: Tests concurrency limits, pause/resume state management, and cancellation tokens.
- **ConfigService**: Tests JSON serialization/deserialization and fallback to default configurations.

### `QuickDownloader.GUI.Tests`
Focuses on unit testing the ViewModels.
- **ViewModel State**: Ensures that properties (e.g., `IsDownloading`, `CanExecute` for commands) correctly update based on underlying model changes.
- **Command Execution**: Mocks the core services to verify that UI commands (like `CancelCommand` or `DownloadCommand`) invoke the correct core methods.

## 3. Integration Testing

Given the reliance on external binaries (`yt-dlp.exe`), true E2E tests are prone to flakiness due to network conditions.
- **CLI Mocks**: We will simulate `yt-dlp` execution by creating a mock process runner that streams predefined string outputs (representing different download phases) to verify the application handles the entire lifecycle (Start -> Progress -> Merge -> Complete) correctly.
- **File System**: Integration tests for `ConfigService` will read/write to temporary directories to ensure file locking and permissions are handled gracefully.

## 4. UI/E2E Testing (Future Phase)
UI automation is deferred for future updates but will be structured to utilize WinAppDriver or FlaUI if required to simulate actual user clicks, dialog boxes, and navigation.

## 5. Coverage Goals
- **Core Library**: Target > 80% coverage. All critical paths (Download Management, Serialization, Parsing) must be fully tested.
- **GUI Library**: Target ViewModels coverage. Views (XAML) will not be unit tested directly.
