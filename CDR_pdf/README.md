# CDR PDF Generator

A web application for generating PDF reports of Call Logs, SMS Logs, and Daily Data CDRs.

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Introduction

The CDR PDF Generator is a web application that allows users to generate PDF reports of Call Logs, SMS Logs, and Daily Data CDRs. The application utilizes the Entity Framework Core to connect to a DB2 database, fetches the required data, and generates PDF reports using the iTextSharp library.

## Features

- Generate PDF reports for Call Logs, SMS Logs, and Daily Data CDRs.
- Input user details and service preferences for the report.
- Display user-specific data in the PDF reports.
- Customize the appearance and layout of PDF reports.

## Technologies Used

- ASP.NET Core MVC
- Entity Framework Core
- IBM Entity Framework Core (for DB2 connectivity)
- iTextSharp (for PDF generation)

## Getting Started

1. Clone this repository to your local machine.

```
git clone https://github.com/your-username/CDR-PDF-Generator.git
```

2. Install the required dependencies using NuGet Package Manager or .NET CLI.

```
dotnet restore
```

3. Update the `appsettings.json` file with your DB2 connection string.

4. Run the application.

```
dotnet run
```

5. Access the application in your web browser at `http://localhost:5000`.

## Usage

1. Open the application in your web browser.

2. Select the desired service type (Call Logs, SMS Logs, or Daily Data CDRs).

3. Provide user details and service preferences for the report.

4. Click the "Generate PDF" button to generate the PDF report.

5. Download and view the generated PDF report.

## Contributing

Contributions are welcome! If you encounter any issues or have suggestions for improvements, please open an issue or create a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
