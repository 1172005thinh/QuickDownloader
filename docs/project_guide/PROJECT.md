# PROJECT: QUICK DOWNLOADER

- **Project Name**: `Quick Downloader`
- **Author**: `1172005thinh (QuickComp.)`
- **Repo**: `QuickDownloader` on [GitHub](https://github.com/1172005thinh/QuickDownloader)
- **Description**: A local GUI application for downloading YouTube videos and playlists, built with C# and WPF, utilizing `yt-dlp` as the core downloading engine and `ffmpeg` for media processing tasks.
- **OS Support**: Windows 10 and later.
- **Programming Language**: C#.
- **Contact**: [GitHub Issues](https://github.com/1172005thinh/QuickDownloader/issues) for bug reports and feature requests, [GitHub Discussions](https://github.com/1172005thinh/QuickDownloader/discussions)

## Project Structure

**COMMAND**: Help me generate the plaintext for the current project structure.

```plaintext
quickdownloader/

```

## Features

1. **Auto-startup**
   - The application can be configured to start automatically when the user logs into Windows. This feature can be enabled or disabled in the "Settings" page.
   - If auto-startup is enabled, the user can choose to open the main window or minimize the application to the system tray through "Settings" page.
   - If auto-startup is disabled, the application will not launch on startup. To start the application, the user must manually launch it from the main executable file.
   - User can disable auto-startup at Task Manager > Startup tab.
   - By default, auto-startup is enabled and the application will minimize to the system tray.
2. **Auto-update**
   - The application can be configured to check for updates automatically when the application is launched. This feature can be enabled or disabled in the "Settings" page.
   - If auto-update is enabled, whenever the application is launched, it will check for updates by sending a request to the GitHub repository's releases page.
     - If a new release is found, the application does one of the following:
       - The application will be marked as "Update Available" and user can manually update the application in the "Settings" page. No notification about this update will be shown.
       - The application will be marked as "Update Available" and user will be notified about this update through a toast notification. User can choose:
         - Update now: The application will download the latest release and install it immediately.
         - Remind me: The application will remind the user about the update the next time it is launched if no other updates are found at the time of the next launch. If another update is found at the time of the next launch, override the previous reminder and notify the user about the new update instead.
       - The application will automatically download, close the application, install the latest release and restart it.
     - If no new release is found, the application will continue to launch normally without any notification.
   - If auto-update is disabled, the application will not check for updates when launched. To update, the user must manually check for updates in the "Settings" page and install the update if it is available.
   - If the application is updated to the latest version, notify user about the successful update through a toast notification.
   - By default, auto-update is enabled and the application will ask user to update through a toast notification when a new release is found.
3. **Toast Notifications**
   - The application will use toast notifications from Windows to notify users. This feature can be enabled or disabled in the "Settings" page.
   - Users can take quick actions directly from the toast notifications, such as opening a downloaded file, retrying a failed download, downloading an available update, etc.
   - If toast notifications are enabled, the application can be configured to specify which types of notifications to show, such as download completion, download failure, update availability, etc. Users can choose to enable or disable specific types of notifications in the "Settings" page.
   - If toast notifications are disabled, the application will not show any toast notifications. *WARN* The application relies on toast notifications to notify users. Disabling toast notifications may cause issues with some features.
   - By default, toast notifications are enabled and the application will show notifications for all types of events (download completion, download failure, update availability, etc).
4. **Localization**
   - The application supports both English (US) and Vietnamese languages, with the ability to easily add more languages in the future.
   - Users can switch between supported languages in the "Settings" page, and the application will update the UI text accordingly without needing to restart the application.
   - By default, the application is in English (US) language.
5. **Theme**
   - The application supports both light and dark themes.
   - Users can switch between light and dark themes in the "Settings" page, and the application will update the UI theme accordingly without needing to restart the application.
   - There is also an option to automatically switch between light and dark themes based on the system theme, called "System" theme.
   - By default, the application is in "System" theme.
6. **Auto-download**
   - The application can be configured to automatically download videos only when it is minimized to the system tray. This feature can be enabled or disabled in the "Settings" page.
   - If auto-download is enabled, whenever the application is minimized to the system tray, it will:
     - Monitor the clipboard for any changes. If the latest entry is a YouTube URL, the application will validate the URL.
     - If the URL is valid, the application does one of the following:
       - Notify the user with toast notification about the detected YouTube URL and ask if they want to download it. User can choose:
         - Download: The application will start downloading the video with the Default config profile. Continue monitoring even when the download is in progress.
         - Skip: The application will skip this URL and continue monitoring the clipboard for any changes.
       - Automatically start downloading the video with the Default config profile without asking the user for confirmation. Continue monitoring even when the download is in progress.
     - If the URL is invalid, the application will ignore it and continue monitoring the clipboard for any changes.
   - If auto-download is disabled, the application will not monitor the clipboard for any changes when it is minimized to the system tray. To download a video, the user must manually add the YouTube URL in the "Downloads" page and start the download from there.
   - By default, auto-download is enabled and the application will ask user for confirmation before downloading a detected YouTube URL when it is minimized to the system tray.
7. **Quick-download**
   - The application can be configured to quickly help users download videos only when it is opened as a GUI application and in the "Downloads" page. (Does not require the main window to be focused). This feature can be enabled or disabled in the "Settings" page.
   - If quick-download is enabled, whenever the application is opened as a GUI application and in the "Downloads" page, it does one of the following:
     - Half-automated:
       - User manually input the URL, it validates the URL input field in the "Download" page in real-time.
         - If the URL is valid, wait for X seconds of inactivity (no changes to the config profile and URL input):
           - If changes are made, stop timer and revalidate the manual changes.
             - If the URL and config profile are valid, restart the timer.
             - If the URL or config profile is invalid, wait for further changes.
           - If no changes are made, continue to wait till the timer reaches X seconds, then automatically start downloading the video with the selected config profile.
           - X can be configured in the "Settings" page, with a default value of 5 seconds, min 3, max 15.
         - If the URL is invalid, wait for changes to the URL input until it becomes valid, then start the timer as described above.
     - Full-automated:
       - *SIMILAR* to Half-automated, but without the timer. Once the URL is valid, it will immediately start downloading the video with the selected config profile without waiting for any inactivity.
   - If the quick-download is disabled, whenever the application is opened as a GUI application and in the "Downloads" page, it does:
     - User manually input the URL, it validates the URL input field in the "Download" page in real-time.
       - If the URL is valid, the users can manually start the download whenever they want as long as this task is present in the "Downloads" page. There is no timer in this mode.
       - If the URL is invalid, user cannot start the download until the URL becomes valid.
8. **Task Management**
   - The application allows users to manage their download tasks in the "Downloads" page.
   - Users can manage multiple download tasks at the same time in the "Downloads" page, min 1, max 16.
   - Users can view the open tasks as a list of tabs in a row (similar to a web browser's tab design).
   - Users can switch between open tasks by clicking on the corresponding tab.
   - Users can close an open task by clicking on the "X" button on the corresponding tab. If the task is in progress, the application will ask for confirmation before closing the task.
   - Users can close all open tasks by clicking on the "X" button at the end of the tab row. If there are any tasks in progress, the application will ask for confirmation before closing all tasks.
   - Users can create a new task by clicking on the "+" button next to the last tab. This will open a new tab with an empty URL input field and the Default config profile selected.
   - Users can multi-select open tasks (Multi-selection mode) to perform batch actions such as "Start", "Pause", "Resume", "Cancel". This can be done by holding CTRL key while clicking on the tabs to select multiple tasks, then use the batch action buttons in the "Toolbar" of the "Downloads" page to perform the desired action on all selected tasks. To deselect a task, simply click on the selected tab again while holding the CTRL key. To exit multi-selection mode, press ESC key.
   - By default, there is no open task in the "Downloads" page when the application is launched. Users can create a new task by clicking on the "+" button.
   - Minimizing the application to the system tray will not close any open tasks.
9. **Config Profiles**
   - The application allows users to create and manage multiple config profiles in the "Config" page, which are used in the "Downloads" page to specify the downloading options for each download task.
   - Users can manage multiple config profiles in the "Config" page, min 1, max 16.
   - Users can view the created config profiles as a list of tabs in a row (similar to a web browser's tab design).
   - Users can switch between created config profiles by clicking on the corresponding tab.
   - Users can delete a config profile by either clicking on the "X" button on the corresponding tab, or using the "Delete" button in the "Toolbar" of the "Config" page. The config profile should not be currently in-use by any "Download" tasks and is not "Default" profile to be deleted, else, the action is not allowed and the application will show a warning message to the user.
   - Users can create a new config profile by clicking on the "+" button next to the last tab. This will open a new tab with the name "New Profile" and the default options filled in. This action is available if the quantity of config profiles is less than 16, else, the action is not allowed and the application will show a warning message to the user.
   - Users can multi-select created config profiles (Multi-selection mode) to perform batch actions such as "Delete". This can be done by holding CTRL key while clicking on the tabs to select multiple config profiles, then use the batch action buttons in the "Toolbar" of the "Config" page to perform the desired action on all selected config profiles. To deselect a config profile, simply click on the selected tab again while holding the CTRL key. To exit multi-selection mode, press ESC key.
   - The application has a special "Default" config profile that cannot be deleted, which is used as the default options for downloading tasks when the user does not specify a config profile. Users can edit the options of the "Default" config profile, but cannot rename it.
   - By default, there is only 1 config profile, which is the "Default" config profile with the default options filled in.
10. **Profile Options**
    - Each config profile has a set of options that can be configured by the user to specify the downloading behavior for the download tasks that use this config profile.
    - The options include:
      - **Profile Name**: The name of the config profile. Can be edited to any name the user wants, except for "Default" which is reserved for the default config profile. This name is used to identify the config profile when selecting it for a download task in the "Downloads" page.
      - **Download Options**: The options that are passed to `yt-dlp`.
      - **Convert Options**: The options that are passed to `ffmpeg` for media processing tasks such as merging video and audio, converting formats, etc.
      - **Output Template**: The template for naming the output files, such as filename format, output directory, etc. This is used to specify how the downloaded files are named and where they are saved.
11. **Video Manager**
    - The application has a "Manager" page that allows users to view and manage the downloaded videos.
    - Currently this page is under development and will be implemented in the future updates. The features of this page will be announced when it is released.
12. **Built-in Search**
    - The application has a built-in search feature that allows users to search for YouTube videos directly from the application and download them without needing to open a web browser.
    - Currently this feature is under development and will be implemented in the future updates. The features of this search functionality will be announced when it is released.
13. **Settings**
    - The application has a "Settings" page that allows users to configure various settings of the application, such as auto-startup, auto-update, toast notifications, localization, theme, auto-download, quick-download, etc.
    - Users can access the "Settings" page from the sidebar navigation menu.
    - Currently, the "Settings" page is under development and only some basic settings are available. More settings options will be added in the future updates. The features of the "Settings" page will be announced when they are released.

## Phase

- There will be a priority order for implementing the features: Quick-download > Config Profiles > Profile Options > Task Management > Toast Notifications > Settings (most basics) > Auto-startup > Auto-download > Video Manager > Built-in Search > Auto-update > Localization > Theme > Settings (final)

- There are _ phases in total:

1. **Phase 1**: Planning and Designing (Current Phase)
   - Focus on planning and designing the project structure, architecture, and user interface.
   - Create a solid foundation for the project, which will allow for efficient development and implementation in the future.
   - No coding is required at this stage.
2. **Phase 2**: UI Template Development
   - Implement the most barebones visual template and basic UI layout.
   - No elements in the UI will be functional at this stage, except for the navigation between pages.
3. **Phase 3**: Download Page with core functionality
   - Implement the core functionality of the application, such as downloading videos using `yt-dlp`, media processing using `ffmpeg`. And implement the elements of "Downloads" page.
   - Once the download function works, we will move on to the next phase.
4. **Phase 4**: Config Page with core functionality
   - Implement the core functionality of the "Config" page, such as creating and managing config profiles, and using the options in the config profiles for downloading tasks.
   - Once the config profile management works, we will move on to the next phase.
5. **Phase 5**: Task Management
   - Implement the task management features in the "Downloads" page, such as managing multiple download tasks, multi-selection mode for batch actions, etc.
6. **Phase 6**: Toast Notifications
   - Implement the toast notification system and integrate it with the application to show notifications for various events such as download completion, download failure, update availability, etc.
7. **Phase 7**: Task Management
   - Implement the task management features in the "Downloads" page, such as managing multiple download tasks, multi-selection mode for batch actions, etc.
8. **Phase 8**: Settings Page with basic settings
   - Implement the "Settings" page with basic settings options such as toast notifications, auto-download, quick-download, etc.
9. **Phase 9**: Auto-startup
   - Implement the auto-startup feature, allowing the application to start automatically when the user logs into Windows, with options to open the main window or minimize to system tray.
10. **Phase 10**: Auto-download
    - Implement the auto-download feature, allowing the application to automatically download videos when it is minimized to the system tray and detects a valid YouTube URL in the clipboard.
11. **Phase 11**: Video Manager Page with core functionality
    - Implement the "Manager" page with core functionality to view downloaded videos. Managing them will be implemented in the future phases.
12. **Phase 12**: Built-in Search with core functionality
    - Implement the built-in search feature with core functionality to search for YouTube videos directly from the application. Downloading from search results will be implemented in the future phases.
13. **Phase 13**: Auto-update
    - Implement the auto-update feature, allowing the application to check for updates automatically when launched, and notify the user about available updates through toast notifications, with options to update immediately or remind later.
14. **Phase 14**: Localization and Theme
    - Implement the localization feature, allowing users to switch between supported languages in the "Settings" page, and update the UI text accordingly without needing to restart the application.
    - Implement the theme feature, allowing users to switch between light and dark themes, as well as an option to automatically switch based on the system theme, with immediate effect without needing to restart the application.
15. **Phase 15**: Finalize Settings Page
    - Add more settings options and finalize the "Settings" page with all the available settings for the application.
16. **Phase 16**: Additional Features and Improvements
    - After all the core features are implemented, we can focus on adding additional features, improving the user interface and user experience, optimizing performance, fixing bugs, etc. This phase will be ongoing and there is no specific end point for it.
17. **Phase 17**: Release and Maintenance
    - Prepare the application for release, such as creating a release package, writing documentation, etc. After the release, focus on maintaining the application by fixing bugs, adding new features based on user feedback, updating dependencies, etc.
