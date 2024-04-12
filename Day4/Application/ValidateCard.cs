using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ValidateCardClass
    {
        /// <summary>
        /// Validate number,Checks for numeric value
        /// </summary>
        /// <param name="value"></param>
        /// <returns>bool</returns>
        static bool ValidateNumber(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }
        /// <summary>
        /// Validate Digits
        /// </summary>
        /// <param name="input"></param>
        /// <returns>bool</returns>
        static bool ValidateDigit(string input)
        {
            return input.Length == 16;
        }
        /// <summary>
        /// Get card number from user and validated
        /// </summary>
        /// <returns>
        /// return card number</returns>
        public static string GetValidCardNumber()
        {
            string cardNumber;
            bool isValid = false;
            do
            {
                Console.WriteLine("Enter 16-digit card number:");
                cardNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(cardNumber))
                {
                    Console.WriteLine("Invalid Card number cannot be empty or whitespace.");
                    continue;
                }
                if (ValidateNumber(cardNumber) && ValidateDigit(cardNumber))
                {
                    isValid = true;
                }
               
                else if (!ValidateDigit(cardNumber))
                {
                    Console.WriteLine("Invalid Card number should be exactly 16 digits.");
                }
                else if (!ValidateNumber(cardNumber))
                {
                    Console.WriteLine("Invalid Card number should contain only numeric characters.");
                }

            } while (!isValid);

            return cardNumber;
        }
        /// <summary>
        /// Validating Card Number
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns>
        /// boolean value returned
        /// </returns>
        public static bool ValidateCard(string cardNumber)
        {
            char[] cardDigits = cardNumber.ToCharArray();
            Array.Reverse(cardDigits);

            int sum = 0;
            for (int i = 0; i < cardDigits.Length; i++)
            {
                int digit = cardDigits[i] - '0'; // Convert char to int
                //Console.WriteLine(digit);
                if (i % 2 == 1)
                {
                    digit *= 2;
                    digit = (digit < 10) ? digit : digit - 9; // If double digit, sum the digits
                }
                sum += digit;
            }
            //Console.WriteLine(sum);
            return sum % 10 == 0;
        }
    }
}
