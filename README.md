# Calculator App

Calculator App is a console-based calculator application designed to perform basic arithmetic operations (addition, subtraction, multiplication, and division) on user input. The application allows users to customize input delimiters, set upper bounds for valid numbers, and specify whether to deny negative numbers.

## Features

- **Basic Arithmetic Operations**: Supports addition. (subtraction, multiplication, and division will be added in next version)
- **Customizable Input**:
  - **Alternate Delimiters**: Define a custom delimiter to separate numbers.
  - **Upper Bound**: Specify an upper bound, treating numbers above this as invalid.
  - **Deny Negative Numbers**: Toggle whether to allow or deny negative numbers.
- **Error Handling**: Handles incorrect input gracefully, displaying error messages to guide the user.

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download) or later installed on your machine.

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/CalculatorApp.git
   cd CalculatorApp

2. Build the application:

    ```bash
    dotnet build
    
2. Run the application:

    ```bash
    dotnet run

### Usage

When you run the application, you’ll see a welcome message. You can then enter numbers and configure options to customize your calculation.

#### Example Commands

- **Basic Addition**:
  - Input: `1,2,3`
  - Result: `6`

- **With Custom Delimiter**:
  - Alternate Delimiter: `|`
  - Input: `1|2|3`
  - Result: `6`

- **Deny Negative Numbers**:
  - If you enter `yes` to deny negative numbers, and the input contains `-1`, the application will throw an error with the list of negative numbers.

### Code Structure

**CalculatorApp:** The main project directory.
- **CalculatorAppRunner.cs:** Entry point of the console application, manages user interaction and input configuration.
- **Calculator.cs:** Main calculator class, performs arithmetic operations.
- **Helpers:**
  - **Parser.cs:** Handles parsing input, extracting numbers and delimiters.

**CalculatorApp.Tests:**
- **CalculatorTests.cs:** This file contains all test cases and examples added in the coding challenge.

### Running Tests

The application includes unit tests for key features. To run the tests:

Navigate to the test project directory and run tests:

    ```bash
    cd CalculatorApp.Tests
    dotnet test


### Contributing

    a. Fork the repository.
    b. Create a feature branch (git checkout -b feature/YourFeature).
    c. Commit your changes (git commit -m 'Add YourFeature').
    d. Push to the branch (git push origin feature/YourFeature).
    e. Open a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.

This Markdown file provides all the information in a structured and formatted way, ready to be copied into a `README.md` file.

## Developed by: Ahmad Bilal Wardak
