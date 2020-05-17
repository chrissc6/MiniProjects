using System;

namespace ExtensionMethods
{
    public static class ConsoleHelper
    {
        public static string RequestString(this string message)
        {
            string output = "";

            while (string.IsNullOrWhiteSpace(output))
            {
                Console.WriteLine(message);
                output = Console.ReadLine();
            }

            return output;
        }

        public static int RequestInt(this string message)
        {
            return message.RequestInt(false);
        }

        public static int RequestInt(this string message, int minValue, int maxValue)
        {
            return message.RequestInt(true, minValue, maxValue);
        }

        private static int RequestInt(this string message, bool useMM, int minValue = 0, int maxValue = 0)
        {
            int output = 0;
            bool isValidInt = false;
            bool isInValidRange = true;

            while (!isValidInt || !isInValidRange)
            {
                Console.WriteLine(message);
                isValidInt = int.TryParse(Console.ReadLine(), out output);

                if (useMM)
                {
                    //better if else
                    isInValidRange = (output >= minValue && output <= maxValue);

                    //if (output >= minValue && output <= maxValue)
                    //{
                    //    isInValidRange = true;
                    //}
                    //else
                    //{
                    //    isInValidRange = false;
                    //}
                }
            }

            return output;
        }
    }
}
