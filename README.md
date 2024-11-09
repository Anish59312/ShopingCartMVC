# .NET MVC Application - QuickKart

This README provides steps to set up and run the QuickKart .NET MVC application locally.

## Prerequisites

- **.NET Framework**: Ensure the .NET Framework (4.8 or later) is installed.
- **Visual Studio**: Visual Studio 2022 (or later) is recommended for this project.

## Setup Guide

1. **Clone the Repository**

   Clone or download the repository from your source control system.

2. **Download the QuickKart Data Access Layer**

   To run this application, you'll need the `QuickKartDataAccessLayer`, which provides database access for QuickKart.

   - [Download QuickKartDataAccessLayer](https://infyspringboard.onwingspan.com/content-store/infosysheadstart/infosysheadstart/Public/lex_auth_012717145449316352195/web-hosted/assets/QuickKartDataAccessLayer.zip).
   - Unzip the file, then add it to the solution:
     - In Visual Studio, right-click on your solution in **Solution Explorer**.
     - Select **Add** > **Existing Project**.
     - Navigate to the unzipped `QuickKartDataAccessLayer` folder and select the project file (`.csproj`).

3. **Configure Database Connection**

   - Open `web.config` in your .NET MVC project.
   - Update the `<connectionStrings>` section to point to your database. Ensure the database is accessible from your local environment.

4. **Build the Solution**

   - In Visual Studio, select **Build** > **Build Solution** or press `Ctrl+Shift+B`.
   - Ensure there are no build errors before proceeding.

5. **Run the Application**

   - Press `F5` to run the application in Debug mode, or select **Start Without Debugging** from the Debug menu.

6. **Test the Application**

   - Open a browser and go to the specified local URL (usually `http://localhost:port/`).

---

### Troubleshooting

- If you encounter issues with database connectivity, ensure the database server is running, and that the connection string in `web.config` is correctly configured.

Enjoy exploring the QuickKart .NET MVC Application!
