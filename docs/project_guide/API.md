# API & INTERNAL INTERFACES

Since Quick Downloader uses an In-Process architecture, there is no HTTP or IPC API. This document outlines the critical internal C# interfaces and the command-line integration contract with external tools.

## 1. Core Interfaces

### `IDownloadManager`
Central hub for managing download tasks.
```csharp
public interface IDownloadManager
{
    IReadOnlyObservableCollection<DownloadTask> Tasks { get; }
    Task EnqueueAsync(DownloadTask task);
    Task PauseAsync(string taskId);
    Task ResumeAsync(string taskId);
    Task CancelAsync(string taskId);
    Task CancelAllAsync();
}
```

### `IYtDlpService`
Handles extraction and downloading.
```csharp
public interface IYtDlpService
{
    Task<VideoMetadata> FetchMetadataAsync(string url);
    Task DownloadAsync(DownloadTask task, ConfigProfile profile, IProgress<DownloadProgress> progress, CancellationToken cancellationToken);
}
```

### `IConfigService`
Handles JSON persistence.
```csharp
public interface IConfigService
{
    AppSettings GetSettings();
    Task SaveSettingsAsync(AppSettings settings);
    
    IEnumerable<ConfigProfile> GetProfiles();
    Task SaveProfileAsync(ConfigProfile profile);
    Task DeleteProfileAsync(string profileId);
}
```

## 2. Data Persistence Schemas (JSON)

### AppSettings.json
```json
{
  "AutoStartup": true,
  "AutoUpdate": "Notify",
  "ToastNotificationsEnabled": true,
  "Language": "en-US",
  "Theme": "System",
  "AutoDownloadFromClipboard": true,
  "QuickDownloadDelaySeconds": 5,
  "MaxConcurrentDownloads": 3
}
```

### ConfigProfiles.json
```json
[
  {
    "Id": "default-000",
    "Name": "Default",
    "IsDefault": true,
    "DownloadOptions": {
      "Format": "bestvideo+bestaudio/best",
      "ResolutionRestrict": "1080p",
      "ExtractAudio": false
    },
    "OutputTemplate": "%(title)s.%(ext)s"
  }
]
```

## 3. CLI Integration Contract

### yt-dlp Output Parsing
`yt-dlp` will be executed with the `--newline` argument to ensure progress is flushed correctly.
The internal parser will use Regex to capture progress from `stdout`:
```regex
\[download\]\s+(?<percent>\d+\.\d+)%\s+of\s+(?<size>[~]?\d+\.\d+[a-zA-Z]+)\s+at\s+(?<speed>\d+\.\d+[a-zA-Z]+\/s)\s+ETA\s+(?<eta>\d+:\d+)
```

### FFmpeg Integration
`ffmpeg` will be utilized implicitly by `yt-dlp` for merging. The application will set the `ffmpeg` location parameter for `yt-dlp`:
`--ffmpeg-location "tools/ffmpeg.exe"`
