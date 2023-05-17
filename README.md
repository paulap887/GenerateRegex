# Regex Expression Generator and Validator

It generates and validates regular expressions for string matching. It provides a user-friendly interface for gathering input and customizing the regular expression pattern based on specific requirements.

## Getting Started

To run the program locally, make sure you have [.NET Core](https://dotnet.microsoft.com/download) installed on your machine. Then, follow these steps:

1. Clone the repository:
```shell
git clone https://github.com/paulap887/GenerateRegex
```

2. Navigate to the project directory:
```shell
cd GenerateRegex
```
3. Build the project:
```shell
dotnet build
```
4. Run the program:
```
dotnet run
```
## Usage

1. Upon running the program, you will be prompted to enter a string for validation.

2. Next, you will be presented with a series of questions to determine the desired format and customization options for the regular expression pattern. Answer each question by typing 'y' for yes or 'n' for no.

3. Based on your responses, the program will generate the regular expression pattern and display it on the console.

4. The input string will then be validated against the generated regular expression pattern, and the validation result (either "Valid" or "Invalid") will be displayed.

## Customization Options

The program provides various customization options for generating the regular expression pattern. These include:

- Matching an email format
- Matching a specific date format
- Matching a specific time format
- Matching a specific IP address format
- Matching a specific hexadecimal color code format
- Matching a specific credit card number format
- Matching a specific social security number format
- Matching a specific postal code format
- Matching a specific URL format
- Matching a specific currency format
- Matching a specific HTML tag format
- Starting and ending patterns
- Containing specific patterns or characters
- Setting minimum and maximum length
- Specifying the number of digits

Feel free to customize the program to fit your specific needs or extend its functionality based on your requirements.




