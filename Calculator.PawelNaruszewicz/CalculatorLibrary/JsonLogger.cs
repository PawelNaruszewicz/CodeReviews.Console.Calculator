using CalculatorLibrary;
using Newtonsoft.Json;

namespace Calculator.PawelNaruszewicz
{
    public class JsonLogger
    {
        JsonWriter writer;
        public JsonLogger()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }
        public void LogOperation(double leftNumber, double rightNumber, double result, IOperation operation)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(leftNumber);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(rightNumber);
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WritePropertyName("Operation");
            writer.WriteValue(operation.Name);
            writer.WriteEndObject();
        }
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}
