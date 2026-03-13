# UI/UX

This document provides a guide to the user interface (UI) and user experience (UX) design of the Quick Downloader project.

## Design Principles

1. **Simplicity**: The interface should be clean and straightforward, allowing users to easily navigate and use the application without confusion.
2. **Consistency**: The design should maintain a consistent look and feel across all screens and components to create a cohesive user experience.
3. **Modern WPF**: The UI should leverage modern WPF design principles, including the use of styles, templates, and data binding to create a responsive and visually appealing interface.

## Note

- All positions and sizes mentioned in this document are measured in pixels (px) with scale 100%.
- Size of shapes (such as buttons, icons, etc.) are measured in width x height format (e.g., 100x50 px).
- Positions are measured in (x, y) format, where x is the horizontal distance from the left edge of the main window to the element's left vertical border line and y is the vertical distance from the top edge of the main window to the element's top horizontal border line (e.g., (100, 50) means 100 px from the left edge and 50 px from the top edge).

## Style

### Fonts

- Use: "Segoe UI" as the primary font for all text elements in the application. There are many sizes and styles of "Segoe UI" font, which will be described later with short codes for easy reference.
  - **S_R**: Segoe UI, 10pt, regular
  - **S_B**: Segoe UI, 10pt, bold
  - **S_I**: Segoe UI, 10pt, italic
  - **S_BI**: Segoe UI, 10pt, bold italic
  - **M_R**: Segoe UI, 12pt, regular
  - **M_B**: Segoe UI, 12pt, bold
  - **M_I**: Segoe UI, 12pt, italic
  - **M_BI**: Segoe UI, 12pt, bold italic
  - **L_R**: Segoe UI, 16pt, regular
  - **L_B**: Segoe UI, 16pt, bold
  - **L_I**: Segoe UI, 16pt, italic
  - **L_BI**: Segoe UI, 16pt, bold italic
  - **XL_B**: Segoe UI, 20pt, bold

### Colors & Themes

- The color scheme of the application should be follow these themes.
- There are two main themes:
  - **Light**:
    - Background Color: #FFFFFF
    - Primary Color: #FF0000
    - Secondary Color: #F0F0F0
    - Regular Text Color: #000000
    - Info Text Color: #3D3D3D
    - Warning Text Color: #FFA500
    - Error Text Color: #FF0000
    - Success Text Color: #00A300
    - URL Text Color: #0000FF
    - Disabled Text Color: #A9A9A9
    - None: transparent
  - **Dark**:
    - Background Color: #181818
    - Primary Color: #FF0000
    - Secondary Color: #282828
    - Regular Text Color: #FFFFFF
    - Info Text Color: #CFCFCF
    - Warning Text Color: #D18800
    - Error Text Color: #D10000
    - Success Text Color: #008000
    - URL Text Color: #2E2EFF
    - Disabled Text Color: #494949
    - None: transparent
- There is option to specify which theme to apply in the application settings, and the application should remember the user's choice and apply it on the next launch. By default, the application should use the Light theme.

### Spacing

- All elements should have a consistent spacing around them:

```plaintext
      [Top Space]             [Top Space]             [Top Space]
[Left][Element_A][Right][Left][Element_B][Right][Left][Element_C][Right]
      [Bottom Sp]             [Bottom Sp]             [Bottom Sp]
      [Top Space]             [Top Space]             [Top Space]
[Left][Element_D][Right][Left][Element_E][Right][Left][Element_F][Right]
      [Bottom Sp]             [Bottom Sp]             [Bottom Sp]
```

- Top Space: 0 px
- Bottom Sp(ace): 0 px
- Left: 0 px
- Right: 0 px
- No padding.

### Localization

- The application support localization for multiple languages.
- All text content in the GUI application should be stored in external RESX files located in the `/src/QuickDownloader.GUI/Resources/Langs/` directory, with each file corresponding to a specific language (e.g., `en-US.resx` for English, `vi-VN.resx` for Vietnamese).
- Text outside of the GUI application, such as context menu items in the system tray is stored in `/assets/langs/` directory, with each file corresponding to a specific language (e.g., `en-US.resx` for English, `vi-VN.resx` for Vietnamese).
- If a text content is missing in the current language file, the application should fallback to English hardcoded strings as a default.
- The text described in elements of this document is in English and should be used as the default hardcoded strings for fallback.

### Icons

- All icons used in the application should be stored in the `/src/QuickDownloader.GUI/Resources/Icons/` directory.
- There are two set of icons:
  - **Light** theme icons: designed for **Light** theme, the file name of these icons should end with null, e.g., `app_icon_16.ico`.
  - **Dark** theme icons: designed for **Dark** theme, the file name of these icons should end with `_dark`, e.g., `app_icon_16_dark.ico`.
  - For quick documentation, the icons specified in the elements of this document are all light theme icons, and the corresponding dark theme icons can be easily inferred by adding `_dark` at the end of the file name before the extension.
- The application should automatically switch between the light and dark icons based on the current theme.
- If an icon is missing for the current theme, the application fallbacks to the error universal icon (`err_icon_16.ico`) as a default (in both **Light** and **Dark** theme).

## UI/UX Components

1. Main Window
   - Header
   - Sidebar
   - Content Area
   - Tooltips
   - Footer
   - Context Menu
   - Dialog Boxes
   - Taskbar Icon
2. System Tray
   - System Tray Icon
   - System Tray Context Menu
   - System Tray Behavior
3. Toast Notifications
   - Toast Notifications Icon
   - Toast Notifications Content

## 1. Main Window

- The application has a one and only one main window that servers as the central hub for all user interactions.
- Main window design:
  - Size: 800x600 px (default value at first launch), resizable by users, remember the last window size.
  - Position: centered on the screen (default value at first launch), movable by users, remember the last window position.
  - Minimum size: 600x400 px.
  - Color: Follow the color scheme of the current theme.
  - Font: There is none text used.
- Elements:
  - **Header**: Contains the application icon and title with window control buttons (minimize, maximize, close).
  - **Sidebar**: A vertical navigation menu on the left side of the window, allowing users to access different features and settings.
  - **Content Area**: The main area of the window where the primary content and functionality are displayed.
  - **Tooltips**: Small pop-up boxes that provide additional information about UI elements when users hover over them.
  - **Footer**: A horizontal bar at the bottom of the window that displays status information.
  - **Context Menu**: A right-click context menu that provides quick access to common actions and settings.
  - **Dialog Boxes**: Modal windows that appear for specific actions, such as canceling multiple downloading tasks, deleting downloaded files, resetting settings, etc. And for displaying error messages, warnings, and informational messages.
  - **Taskbar Icon**: An icon (only one instance) in the desktop taskbar.

### 1.1 Header

- The header contains the application icon and title, providing a clear indication of the application's identity with the window control buttons (minimize, maximize, close).
- Do not use the default window title bar provided by the WPF framework. Instead, create a custom header for more control over the design and functionality.
- Header design:
  - Width: 100% of the main window width.
  - Height: 40 px.
  - Color: Follow the color scheme of the current theme.
  - Font: Varies based on the element, see the elements section below for details.
  - Position: (0, 0).
- Elements:
  - **Application Icon**:
    - Text: None.
    - Size: 40x40 px.
    - Space: already defined.
    - Position: (0, 0).
    - Tooltip: None.
    - Icon: `/src/QuickDownloader.GUI/Resources/Icons/app_icon_16.ico`.
      - Size: 16x16 px.
      - Alignment: Centered.
    - Background: None.
    - Action: None.
  - **Application Title**:
    - Text: "Quick Downloader".
      - Source: `/src/QuickDownloader.GUI/Resources/Langs/en-US.resx`, key: `app_title`.
      - Text Alignment: Centered vertically, left-aligned horizontally.
      - Color: Default Text Color.
      - Background: None.
      - Font: M_R.
    - Size: 200x40 px.
    - Space: already defined.
    - Position: (app icon width, 0).
    - Tooltip: None.
    - Icon: None.
    - Background: None.
    - Action: None.
  - **Window Control Buttons**:
    - Minimize Button:
      - Text: None.
      - Size: 50x40 px.
      - Space: already defined.
      - Position: (main window width - button width * 3, 0).
      - Tooltip: "Minimize".
        - Source: `/src/QuickDownloader.GUI/Resources/Langs/en-US.resx`, key: `minimize_button_tooltip`.
        - Text Alignment: Centered vertically, left-aligned horizontally.
        - Color: Default Text Color.
        - Background: Secondary Color.
        - Font: S_R.
      - Icon: `/src/QuickDownloader.GUI/Resources/Icons/minimize_button_icon_16.ico`.
        - Size: 16x16 px.
        - Alignment: Centered.
      - Background: None.
      - Action:
        - On hover: change background color to Secondary Color, show tooltip.
        - On click: minimize the main window to the taskbar.
    - Maximize Button:
      - Text: None.
      - Size: 50x40 px.
      - Space: already defined.
      - Position: (main window width - button width * 2, 0).
      - Tooltip: "Maximize".
        - Source: `/src/QuickDownloader.GUI/Resources/Langs/en-US.resx`, key: `maximize_button_tooltip`.
        - Text Alignment: Centered vertically, left-aligned horizontally.
        - Color: Default Text Color.
        - Background: Secondary Color.
        - Font: S_R.
      - Icon: `/src/QuickDownloader.GUI/Resources/Icons/maximize_button_icon_16.ico`
        - Size: 16x16 px.
        - Alignment: Centered.
      - Background: None.
      - Action:
        - On hover: change background color to Secondary Color, show tooltip.
        - On click: toggle between maximizing the main window to fill the screen and restoring it to its previous size and position.
    - Close Button:
      - Text: None.
      - Size: 50x40 px.
      - Space: already defined.
      - Position: (main window width - button width * 1, 0).
      - Tooltip: "Close".
        - Source: `/src/QuickDownloader.GUI/Resources/Langs/en-US.resx`, key: `close_button_tooltip`.
        - Text Alignment: Centered vertically, left-aligned horizontally.
        - Color: Default Text Color.
        - Background: Secondary Color.
        - Font: S_R.
      - Icon: `/src/QuickDownloader.GUI/Resources/Icons/close_button_icon_16.ico`.
        - Size: 16x16 px.
        - Alignment: Centered.
      - Background: None.
      - Action:
        - On hover: change background color to Primary Color, show tooltip.
        - On click: minimize the application to the system tray instead of closing it completely. No taskbar icon should be shown when the application is minimized to the system tray. The application can be restored by opening the system tray icon, right-click the application icon to open context menu with options to restore or exit the application. This system tray icon and context menu will be described in the later section of this document.

### 1.2 Sidebar

- The sidebar is a vertical navigation menu on the left side of the main window, allowing users to access different pages and settings of the application.
- Pages:
  - **Download**: Acts as the main page of the application, where to input URL links, quickly brief through video details, switch between Simple and Advanced download modes and managing downloading tasks.
  - **Config**: Manages advance download configuration settings as profiles. Each profile contains a set of configuration settings that can be applied to downloading tasks. Users can create, edit, delete, import, export profiles, and set a default profile that will be applied to all advanced downloading tasks by default in **Download** page.
  - **Manager**: Manages downloaded files, where users can view the list of downloaded files, open the selected file, open the folder containing the selected file, delete the selected files, search for downloaded files by name, and sort the list of downloaded files by name, size, or date.
  - **Search**: Provides a built-in search functionality that allows users to search for videos directly within the application using YouTube's search engine, and quickly brief through video details and download videos from the search results.
  - **Settings**: Manages application settings.
- Sidebar design:
  - Width: 80 px.
  - Height: height of the main window - 40*2 px.
  - Color: Follow the color scheme of the current theme.
  - Font: There is none text used.
  - Position: (0, header height).
- Elements:
  - **Download Page Button**:
    - Text: None.
    - Size: 80x80 px.
    - Space: already defined.
    - Position: (0, header height + button height * 0).
    - Tooltip: "Download".
      - Source: `/src/QuickDownloader.GUI/Resources/Langs/en-US.resx`, key: `download_page_button_tooltip`.
      - Text Alignment: Centered vertically, left-aligned horizontally.
      - Color: Default Text Color.
      - Background: Secondary Color.
      - Font: S_R.
    - Icon: `/src/QuickDownloader.GUI/Resources/Icons/download_page_button_icon_32.ico`.
      - Size: 32x32 px.
      - Alignment: Centered.
    - Background: None.
    - Action:
      - On hover: change background color to Secondary Color, show tooltip.
      - On click: navigate to the Download page in the content area if the button is not disabled.
      - Active page: when the current page is Download page, the button is disabled. Change background color to Primary Color.
      - Inactive page: when the current page is not Download page, the button is enabled. Change background color to None.
  - **Config Page Button**:
    - Text: None.
    - Size: 80x80 px.
    - Space: already defined.
    - Position: (0, header height + button height * 1).
    - Tooltip: "Config".
      - Source: `/src/QuickDownloader.GUI/Resources/Langs/en-US.resx`, key: `config_page_button_tooltip`.
      - Text Alignment: Centered vertically, left-aligned horizontally.
      - Color: Default Text Color.
      - Background: Secondary Color.
      - Font: S_R.
    - Icon: `/src/QuickDownloader.GUI/Resources/Icons/config_page_button_icon_32.ico`.
      - Size: 32x32 px.
      - Alignment: Centered.
    - Background: None.
    - Action:
      - On hover: change background color to Secondary Color, show tooltip.
      - On click: navigate to the Config page in the content area if the button is not disabled.
      - Active page: when the current page is Config page, the button is disabled. Change background color to Primary Color.
      - Inactive page: when the current page is not Config page, the button is enabled. Change background color to None.
  - **Manager Page Button**:
    - Text: None.
    - Size: 80x80 px.
    - Space: already defined.
    - Position: (0, header height + button height * 2).
    - Tooltip: "Manager".
      - Source: `/src/QuickDownloader.GUI/Resources/Langs/en-US.resx`, key: `manager_page_button_tooltip`.
      - Text Alignment: Centered vertically, left-aligned horizontally.
      - Color: Default Text Color.
      - Background: Secondary Color.
      - Font: S_R.
    - Icon: `/src/QuickDownloader.GUI/Resources/Icons/manager_page_button_icon_32.ico`.
      - Size: 32x32 px.
      - Alignment: Centered.
    - Background: None.
    - Action:
      - On hover: change background color to Secondary Color, show tooltip.
      - On click: navigate to the Manager page in the content area if the button is not disabled.
      - Active page: when the current page is Manager page, the button is disabled. Change background color to Primary Color.
      - Inactive page: when the current page is not Manager page, the button is enabled. Change background color to None.
  - **Search Page Button**:
    - Text: None.
    - Size: 80x80 px.
    - Space: already defined.
    - Position: (0, header height + button height * 3).
    - Tooltip: "Search".
      - Source: `/src/QuickDownloader.GUI/Resources/Langs/en-US.resx`, key: `search_page_button_tooltip`.
      - Text Alignment: Centered vertically, left-aligned horizontally.
      - Color: Default Text Color.
      - Background: Secondary Color.
      - Font: S_R.
    - Icon: `/src/QuickDownloader.GUI/Resources/Icons/search_page_button_icon_32.ico`.
      - Size: 32x32 px.
      - Alignment: Centered.
    - Background: None.
    - Action:
      - On hover: change background color to Secondary Color, show tooltip.
      - On click: navigate to the Search page in the content area if the button is not disabled.
      - Active page: when the current page is Search page, the button is disabled. Change background color to Primary Color.
      - Inactive page: when the current page is not Search page, the button is enabled. Change background color to None.
  - **Settings Page Button**:
    - Text: None.
    - Size: 80x80 px.
    - Space: already defined.
    - Position: (0, main window height - footer height - button height).
    - Tooltip: "Settings".
      - Source: `/src/QuickDownloader.GUI/Resources/Langs/en-US.resx`, key: `settings_page_button_tooltip`.
      - Text Alignment: Centered vertically, left-aligned horizontally.
      - Color: Default Text Color.
      - Background: Secondary Color.
      - Font: S_R.
    - Icon: `/src/QuickDownloader.GUI/Resources/Icons/settings_page_button_icon_32.ico`.
      - Size: 32x32 px.
      - Alignment: Centered.
    - Background: None.
    - Action:
      - On hover: change background color to Secondary Color, show tooltip.
      - On click: navigate to the Settings page in the content area if the button is not disabled.
      - Active page: when the current page is Settings page, the button is disabled. Change background color to Primary Color.
      - Inactive page: when the current page is not Settings page, the button is enabled. Change background color to None.

### 1.3 Content Area

- The content area is the main area of the window where the primary content and functionality are displayed. It changes based on the page selected from the sidebar.
- Content area design:
  - Size: (main window width - sidebar width) x (main window height - header height - footer height).
  - Color: Follow the color scheme of the current theme.
  - Font: There is none text used in the content area itself, but each page displayed in the content area may have its own font specifications for its elements, which will be described in the later sections of this document.
  - Position: (sidebar width, header height).

#### 1.3.1 Download Page

- At this early version, this page is still under design and development.
- Temporarily elements:
  - **In Dev Label**:
    - Text: "Download page is under development".
      - Source: None, hardcoded string.
      - Text Alignment: Centered.
      - Color: Default Text Color.
      - Background: None.
      - Font: M_R.
    - Size: 200x40 px
    - Space: already defined.
    - Position: (content area width / 2 - label width / 2, content area height / 2 - label height / 2).
    - Tooltip: None.
    - Icon: None.
    - Background: None.
    - Action: None.

#### 1.3.2 Config Page

- At this early version, this page is still under design and development.
- Temporarily elements:
  - **In Dev Label**:
    - Text: "Config page is under development".
      - Source: None, hardcoded string.
      - Text Alignment: Centered.
      - Color: Default Text Color.
      - Background: None.
      - Font: M_R.
    - Size: 200x40 px.
    - Space: already defined.
    - Position: (content area width / 2 - label width / 2, content area height / 2 - label height / 2).
    - Tooltip: None.
    - Icon: None.
    - Background: None.
    - Action: None.

#### 1.3.3 Manager Page

- At this early version, this page is still under design and development.
- Temporarily elements:
  - **In Dev Label**:
    - Text: "Manager page is under development".
      - Source: None, hardcoded string.
      - Text Alignment: Centered.
      - Color: Default Text Color.
      - Background: None.
      - Font: M_R.
    - Size: 200x40 px.
    - Space: already defined.
    - Position: (content area width / 2 - label width / 2, content area height / 2 - label height / 2).
    - Tooltip: None.
    - Icon: None.
    - Background: None.
    - Action: None.

#### 1.3.4 Search Page

- At this early version, this page is still under design and development.
- Temporarily elements:
  - **In Dev Label**:
    - Text: "Search page is under development".
      - Source: None, hardcoded string.
      - Text Alignment: Centered.
      - Color: Default Text Color.
      - Background: None.
      - Font: M_R.
    - Size: 200x40 px.
    - Space: already defined.
    - Position: (content area width / 2 - label width / 2, content area height / 2 - label height / 2).
    - Tooltip: None.
    - Icon: None.
    - Background: None.
    - Action: None.

#### 1.3.5 Settings Page

- At this early version, this page is still under design and development.
- Temporarily elements:
  - **In Dev Label**:
    - Text: "Settings page is under development".
      - Source: None, hardcoded string.
      - Text Alignment: Centered.
      - Color: Default Text Color.
      - Background: None.
      - Font: M_R.
    - Size: 200x40 px.
    - Space: already defined.
    - Position: (content area width / 2 - label width / 2, content area height / 2 - label height / 2).
    - Tooltip: None.
    - Icon: None.
    - Background: None.
    - Action: None.

### 1.4 Tooltips

- Tooltips are small pop-up boxes that provide additional information about UI elements when users hover over them.
- Design:
  - Size: Auto-adjust based on the content, with a maximum width of 200 px.
  - Hover delay: 1 second after hovering over the element.
  - Disappear delay: immediately when the mouse leaves the element.
  - Font, source, text alignment, color, and background of the tooltip are specified in the element section of each UI component that has a tooltip.

### 1.5 Footer

- The footer is a horizontal bar at the bottom of the main window that displays status information.
- Footer design:
  - Width: 100% of the main window width.
  - Height: 40 px.
  - Color: Follow the color scheme of the current theme.
  - Font: Varies based on the element, see the elements section below for details.
  - Position: (0, main window height - footer height).
- Elements: In this early version, no element is defined for the footer. It will be defined in future updates. For now, the footer is just an empty bar.

### 1.6 Context Menu

- The context menu is a right-click menu that provides quick access to common actions and settings related to the element that is right-clicked.
- In this early version, the context menu is still under design and development. It will be defined in future updates. For now, there is no context menu implemented in the application.

### 1.7 Dialog Boxes

- Dialog boxes are modal windows that appear for specific actions, such as canceling multiple downloading tasks, deleting downloaded files, resetting settings, etc. And for displaying error messages, warnings, and informational messages.
- In this early version, dialog boxes are still under design and development. They will be defined in future updates. For now, there is no dialog box implemented in the application.

### 1.8 Taskbar Icon

- The taskbar icon is an icon that appears in the desktop taskbar when the application is running, allowing users to quickly access the application and its features.
- Icon:
  - Source: `/assets/icons/app_icon_32.ico`.
  - Size: 32x32 px.
  - Alignment: Centered.
- Behavior: Default by the operating system, with the addition of the following custom behavior:
  - When the application is minimized to the system tray, no taskbar icon should be shown.
  - The application can be restored by opening the system tray icon, right-click the application icon to open context menu with options to restore or exit the application. This system tray icon and context menu will be described in the later section of this document.

## 2. System Tray

- When the application is minimized to the system tray, it should display an icon in the system tray area of the taskbar, allowing users to quickly access the application and its features without taking up space in the taskbar.

### 2.1 System Tray Icon

- The icon is dynamically changed based on the current status of the application, such as idle, on-going, paused, warning, error, update available, etc. Each status corresponds to a specific icon that visually represents the status of the application.
- Icons:
  - Idle: `/assets/icons/system_tray_idle_icon_16.ico`.
  - On-going: `/assets/icons/system_tray_ongoing_icon_16.ico`.
  - Paused: `/assets/icons/system_tray_paused_icon_16.ico`.
  - Warning: `/assets/icons/system_tray_warning_icon_16.ico`.
  - Error: `/assets/icons/system_tray_error_icon_16.ico`.
  - Update Available: `/assets/icons/system_tray_update_available_icon_16.ico`.

### 2.2 System Tray Context Menu

- The system tray icon has a right-click context menu with dynamic menu items based on the current status of the application.
- In this early version, the context menu is still under design and development. For now, only some basic menu items are defined.
- Menu items:
  - **Open GUI**:
    - Text: "Open GUI".
      - Source: `/assets/langs/en-US.resx`, key: `system_tray_open_gui_menu_item`.
      - Text Alignment: Centered vertically, left-aligned horizontally.
      - Color: Default Text Color.
      - Background: None.
      - Font: S_R.
    - Icon: `/assets/icons/system_tray_open_gui_menu_item_icon_16.ico`.
      - Size: 16x16 px.
      - Alignment: Centered.
    - Action: When clicked, restore the main window if it is minimized to the system tray, and bring it to the foreground.
    - Visibility: Always visible when the application is running, regardless of the current status of the application.
  - **Exit**:
    - Text: "Exit".
      - Source: `/assets/langs/en-US.resx`, key: `system_tray_exit_menu_item`.
      - Text Alignment: Centered vertically, left-aligned horizontally.
      - Color: Default Text Color.
      - Background: None.
      - Font: S_R.
    - Icon: `/assets/icons/system_tray_exit_menu_item_icon_16.ico`.
      - Size: 16x16 px.
      - Alignment: Centered.
    - Action: When clicked, exit the application completely (Kill the downloading tasks immediately without any confirmation or saving progress, and close the application).
    - Visibility: Always visible when the application is running, regardless of the current status of the application.
  - **Check for updates**:
    - Text: "Check for updates".
      - Source: `/assets/langs/en-US.resx`, key: `system_tray_check_for_updates_menu_item`.
      - Text Alignment: Centered vertically, left-aligned horizontally.
      - Color: Default Text Color.
      - Background: None.
      - Font: S_R.
    - Icon: `/assets/icons/system_tray_check_for_updates_menu_item_icon_16.ico`.
      - Size: 16x16 px.
      - Alignment: Centered.
    - Action: When clicked, open GUI and navigate to the settings page, scroll to the update sections and check for updates (unimplemented yet, will be implemented in future updates).
    - Visibility: Only visible when the application is idle and there is no announcement of update available. If there is an announcement of update available, this menu item will be hidden and the **Update now** entry will be shown instead.
  - **Update now*:
    - Text: "Update now!".
      - Source: `/assets/langs/en-US.resx`, key: `system_tray_update_now_menu_item`.
      - Text Alignment: Centered vertically, left-aligned horizontally.
      - Color: Default Text Color.
      - Background: None.
      - Font: S_R.
    - Icon: `/assets/icons/system_tray_update_now_menu_item_icon_16.ico`.
      - Size: 16x16 px.
      - Alignment: Centered.
    - Action: When clicked, update the application to the latest version (unimplemented yet, will be implemented in future updates).
    - Visibility: Only visible when there is an announcement of update available and the application is idle. If there is no announcement of update available, this menu item will be hidden and the **Check for updates** entry will be shown instead.

### 2.3 System Tray Behavior

- When the application is minimized to the system tray, it should display:
  - If the application is idle: show idle icon.
  - If there is at least one on-going downloading task: show on-going icon.
  - If all downloading tasks are paused: show paused icon.
  - If there is at least one downloading task with warning status and no downloading task with error status: show warning icon.
  - If there is at least one downloading task with error status: show error icon.
  - If there is an update available for the application: show update available icon (regardless of the downloading tasks status).

## 3. Toast Notifications

- Toast notifications are small pop-up messages that appear on the desktop screen to provide users with timely information about the application's status, such as when a downloading task is completed, when there is an error, when an update is available, etc.
- In this early version, toast notifications are still under design and development. They will be defined in future updates. For now, there is only some basic design guidelines for toast notifications.

### 3.1 Toast Notifications Icon

- Each toast notification should have an icon that visually represents the type of notification, such as success, error, warning, info, etc.
- Icons:
  - Success: `/assets/icons/toast_notification_success_icon_16.ico`.
  - Error: `/assets/icons/toast_notification_error_icon_16.ico`.
  - Info: `/assets/icons/toast_notification_info_icon_16.ico`.
  - Update Available: `/assets/icons/toast_notification_update_available_icon_16.ico`.

### 3.2 Toast Notifications Content

- Each toast notification should have a title and a message that provide users with information about the notification.
- Design:
  - **Title**:
    - Text: "Quick Downloader".
      - Source: `/assets/langs/en-US.resx`, key: `toast_notification_title`.
    - Font: S_B.
    - Color: Default Text Color.
    - Background: None.
  - **Message**:
    - Text: Varies based on the type of notification, such as "Downloading task completed successfully", "An error occurred while downloading", "YouTube URL found in clipboard", "An update is available for Quick Downloader", etc.
      - Source: `/assets/langs/en-US.resx`, with different keys for different types of notifications (e.g., `toast_notification_success_message`, `toast_notification_error_message`, `toast_notification_info_message`, `toast_notification_update_available_message`).
    - Font: S_R.
    - Color: Default Text Color.
    - Background: None.
  - **Actions**: Some toast notifications may have action buttons that allow users to quickly respond to the notification, such as "Open file", "Retry", "Download", "Update now", etc.
    - Action buttons design:
      - Text: Varies based on the type of action (e.g., "Open file", "Retry", "Download", "Update now", "Remind me", "Skip").
        - Source: `/assets/langs/en-US.resx`, with different keys for different types of actions (e.g., `toast_notification_open_file_action`, `toast_notification_retry_action`, `toast_notification_download_action`, `toast_notification_update_now_action`, `toast_notification_remind_me_action`, `toast_notification_skip_version_action`).
      - Font: S_R.
      - Color: Default Text Color.
      - Background: None.
