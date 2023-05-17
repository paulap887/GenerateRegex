using System;
using System.Text.RegularExpressions;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Regex Expression Generator and Validator");

        // Gather information for generating the regular expression
        string inputString = GetUserInput("Enter a string to validate: ");

        // Define the options for the different formats
        string[] formatOptions =
        {
            "Email",
            "Date",
            "Time",
            "IP address",
            "Hexadecimal color code",
            "Credit card number",
            "Social security number",
            "Postal code",
            "URL",
            "Currency",
            "HTML tag",
            "Other"
        };

        // Ask the user to choose the format
        int formatChoice = GetOptionChoice("Choose a format:", formatOptions);

        // Generate the regular expression based on the chosen format
        string regexPattern = "^";

        switch (formatChoice)
        {
            case 0: // Email
                regexPattern += @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                break;
            case 1: // Date
                string dateFormat = GetUserInput("Enter the date format: ");
                regexPattern += Regex.Escape(dateFormat);
                break;
            case 2: // Time
                string timeFormat = GetUserInput("Enter the time format: ");
                regexPattern += Regex.Escape(timeFormat);
                break;
            case 3: // IP address
                string ipAddressFormat = GetUserInput("Enter the IP address format (IPv4 or IPv6): ");
                regexPattern += ipAddressFormat == "IPv6"
                    ? @"^([0-9a-fA-F]{1,4}:){7}[0-9a-fA-F]{1,4}$"
                    : @"^(\d{1,3}\.){3}\d{1,3}$";
                break;
            case 4: // Hexadecimal color code
                string colorCodeFormat = GetUserInput("Enter the hexadecimal color code format: ");
                regexPattern += Regex.Escape(colorCodeFormat);
                break;
            case 5: // Credit card number
                string creditCardFormat = GetUserInput("Enter the credit card number format: ");
                regexPattern += GetCreditCardRegex(creditCardFormat);
                break;
            case 6: // Social security number
                string ssnFormat = GetUserInput("Enter the social security number format: ");
                regexPattern += Regex.Escape(ssnFormat);
                break;
            case 7: // Postal code
                string postalCodeFormat = GetUserInput("Enter the postal code format: ");
                regexPattern += Regex.Escape(postalCodeFormat);
                break;
            case 8: // URL
                string urlFormat = GetUserInput("Enter the URL format: ");
                regexPattern += Regex.Escape(urlFormat);
                break;
            case 9: // Currency
                string currencyFormat = GetUserInput("Enter the currency format: ");
                regexPattern += Regex.Escape(currencyFormat);
                break;
            case 10: // HTML tag
                string htmlTagFormat = GetUserInput("Enter the HTML tag format: ");
                regexPattern += Regex.Escape(htmlTagFormat);
                break;
            case 11: // Other
                bool startsWith = GetYesNoAnswer("Does the string need to start with a specific pattern? (y/n): ");
                string startPattern = startsWith ? GetUserInput("Enter the starting pattern: ") : null;
                bool endsWith = GetYesNoAnswer("Does the string need to end with a specific pattern? (y/n): ");

                string endPattern = endsWith ? GetUserInput("Enter the ending pattern: ") : null;

                bool containsPattern = GetYesNoAnswer("Does the string need to contain a specific pattern or set of characters? (y/n): ");
                string pattern = containsPattern ? GetUserInput("Enter the pattern or set of characters: ") : null;

                bool hasMinLength = GetYesNoAnswer("Does the string need to have a minimum length? (y/n): ");
                int minLength = hasMinLength ? GetNumericInput("Enter the minimum length: ") : 0;

                bool hasMaxLength = GetYesNoAnswer("Does the string need to have a maximum length? (y/n): ");
                int maxLength = hasMaxLength ? GetNumericInput("Enter the maximum length: ") : int.MaxValue;

                bool hasDigitCount = GetYesNoAnswer("Does the string need to contain a specific number of digits? (y/n): ");
                int digitCount = hasDigitCount ? GetNumericInput("Enter the number of digits: ") : 0;

                // Generate the regular expression based on the gathered information
                if (startsWith)
                    regexPattern += Regex.Escape(startPattern);

                if (containsPattern)
                    regexPattern += Regex.Escape(pattern);

                if (hasDigitCount)
                    regexPattern += @"\d{" + digitCount + "}";

                regexPattern += ".{" + minLength + "," + maxLength + "}";

                if (endsWith)
                    regexPattern += Regex.Escape(endPattern);

                regexPattern += "$";
                break;

        }
        Console.WriteLine("Generated Regular Expression: " + regexPattern);

        // Validate the input string using the generated regular expression
        bool isValid = Regex.IsMatch(inputString, regexPattern);

        Console.WriteLine("Validation Result: " + (isValid ? "Valid" : "Invalid"));
    }


    static string GetCreditCardRegex(string creditCardFormat)
    {
        switch (creditCardFormat)
        {
            case "Visa":
                return @"^4[0-9]{12}(?:[0-9]{3})?$";
            case "Mastercard":
                return @"^5[1-5][0-9]{14}$";
            case "American Express":
                return @"^3[47][0-9]{13}$";
            case "Discover":
                return @"^6(?:011|5[0-9]{2})[0-9]{12}$";
            case "Diners Club":
                return @"^3(?:0[0-5]|[68][0-9])[0-9]{11}$";
            case "JCB":
                return @"^(?:2131|1800|35\d{3})\d{11}$";
            default:
                return Regex.Escape(creditCardFormat);
        }
    }

    static string GetUserInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine();
    }

    static bool GetYesNoAnswer(string prompt)
    {
        Console.Write(prompt);
        string answer = Console.ReadLine().ToLower();
        return answer == "y" || answer == "yes";
    }

    static int GetNumericInput(string prompt)
    {
        Console.Write(prompt);
        int value;
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.WriteLine("Invalid input. Please enter a valid numeric value.");
            Console.Write(prompt);
        }
        return value;
    }

    static int GetOptionChoice(string prompt, string[] options)
    {
        Console.WriteLine(prompt);
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > options.Length)
        {
            Console.WriteLine("Invalid input. Please enter a valid option number.");
            Console.WriteLine(prompt);
        }

        return choice - 1;
    }

}