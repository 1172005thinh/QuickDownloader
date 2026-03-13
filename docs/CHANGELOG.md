# CHANGELOG

## Unreleased

### v0.0.4 - March 13, 2026

Phase 2 - UI Template Development (Main Window Shell):

1. Initialized WPF GUI project (`QuickDownloader.GUI`) with ModernWpfUI dependencies.
2. Configured custom `MainWindow.xaml` with `WindowStyle="None"` and `WindowChrome` to remove the default OS title bar while retaining resize capabilities.
3. Implemented the custom 40px Header, including:
   - Application Icon (`err_icon_16.ico` fallback) and Title.
   - Custom styled Minimize, Maximize, and Close buttons with proper hover effects (including primary red color for close).
4. Defined the overall Grid layout for the Main Window, establishing reserved columns/rows for the Sidebar (80px), Content Area, and Footer (40px).
5. Addressed missing UI placeholder files and blank resource dictionaries to ensure a successful compilation.
6. Added `IconHelper` utility and attached property `IconHelper.IconName` to dynamically resolve light/dark icons and provide a fallback to `err_icon_16.ico` when requested icons are missing.

### v0.0.3 - March 13, 2026

Documentation phase finalized and architecture established:

1. Received clarifications from the project owner regarding architecture, technologies, and features.
2. Settled on an **In-Process Architecture** (WPF GUI referencing Core library), removing unnecessary IPC complexity.
3. Defined technological stack (ModernWpf, Serilog, Newtonsoft.Json).
4. Generated complete `ARCHITECTURE.md` establishing component interactions and data flow.
5. Generated `API.md` outlining internal C# interfaces and JSON persistence schemas.
6. Generated `TEST.md` detailing testing frameworks (xUnit, Moq) and mock CLI integration strategies.
7. Prepared project structure for Phase 2 implementation.

### v0.0.2 - March 2, 2026

Documentation review and analysis:

1. Comprehensive review of all project documentation completed.
2. Identified missing information requiring clarification:
   - Core technology integration details (yt-dlp, FFmpeg)
   - Data persistence mechanisms
   - IPC architecture justification and implementation
   - Dependency management strategy
   - Update mechanism specifications
3. Identified unclear descriptions:
   - Config profile UI presentation
   - Auto-update behavior controls
   - Quick-download timer implementation
   - URL validation scope
4. Identified conflicting information:
   - Localization file path inconsistencies
   - Icon file path split between /assets and /Resources
   - Project structure documentation gaps
5. Created comprehensive analysis report in `REPORT.md` with 40+ clarification questions for project owner.
6. Status: Awaiting clarification before proceeding with ARCHITECTURE.md, API.md, and TEST.md generation.

### v0.0.1

Initial commit: template window design

1. Project structure created.
2. Project documentation created, including:
   - `PROJECT.md`: Project overview, features (60%) and initial structure.
   - `UI_UX.md`: User interface and user experience design details:
     - Added detailed specifications for the main window, header, side bar.
     - Remaining UI elements to be defined in future updates.