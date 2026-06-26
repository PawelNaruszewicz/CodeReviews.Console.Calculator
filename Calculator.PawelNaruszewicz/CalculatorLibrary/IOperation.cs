namespace CalculatorLibrary
{
    public abstract class IOperation
    {
        public abstract string Name { get; }
        public abstract double Execute(double leftNumber, double rightNumber);
    }
    public class Add : IOperation
    {
        public override string Name => "Addition";
        public override double Execute(double leftNumber, double rightNumber)
        {
            return leftNumber + rightNumber;
        }
    }
    public class Subtract : IOperation
    {
        public override string Name => "Subtract";
        public override double Execute(double leftNumber, double rightNumber)
        {
            return leftNumber - rightNumber;
        }
    }
    public class Multiply : IOperation
    {
        public override string Name => "Multiply";
        public override double Execute(double leftNumber, double rightNumber)
        {
            return leftNumber * rightNumber;
        }
    }
    public class Divide : IOperation
    {
        public override string Name => "Divide";
        public override double Execute(double leftNumber, double rightNumber)
        {
            if (rightNumber != 0) return leftNumber / rightNumber;
            else
            {
                Console.WriteLine("Can't divide by 0, returning original number");
                return rightNumber;
            }
        }
    }
}
