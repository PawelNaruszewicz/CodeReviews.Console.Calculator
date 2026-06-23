using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class CalculatorApp
    {
        JsonWriter writer;
        private int numberOfCalculations = 0;
        private List<string> latestCalculations = new List<string>();
        private List<double> latestResults = new List<double>();

        public CalculatorApp()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");
            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    writer.WriteValue("Add");
                    latestCalculations.Add($"{result} = {num1} + {num2}");
                    break;
                case "s":
                    result = num1 - num2;
                    writer.WriteValue("Subtract");
                    latestCalculations.Add($"{result} = {num1} - {num2}");
                    break;
                case "m":
                    result = num1 * num2;
                    writer.WriteValue("Multiply");
                    latestCalculations.Add($"{result} = {num1} * {num2}");
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        latestCalculations.Add($"{result} = {num1} / {num2}");
                    }
                    writer.WriteValue("Divide");
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            numberOfCalculations++;
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }
        public void DisplayLatestCalculation()
        {
            if (latestCalculations.Count == 0) return;

            foreach (var item in latestCalculations)
            {
                Console.WriteLine(item);
            }
        }
        public void DeleteLatestCalculationList()
        {
            latestCalculations.Clear();
        }
        public void Finish()
        {
            Console.WriteLine($"You've used the calculator {numberOfCalculations} amount of times");
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}
