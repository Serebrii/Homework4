using System.Globalization;
using System.Text;

class Converter
{
    public Converter(decimal dollar, decimal euro)
    {
        _dollarsForHryvnya = dollar;
        _eurosForHryvnya = euro;
    }

    private decimal _dollarsForHryvnya;
    private decimal _eurosForHryvnya;

    public decimal HryvnyaToDollar(decimal value)
    {
        return value / _dollarsForHryvnya;
    }
    public decimal HryvnyaToEuro(decimal value)
    {
        return value / _eurosForHryvnya;
    }
    public decimal DolllarToHryvnya(decimal value)
    {
        return value * _dollarsForHryvnya;
    }
    public decimal EuroToHryvnya(decimal value)
    {
        return value * _eurosForHryvnya;
    }
}

class Program
{
    private static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;
        NumberFormatInfo setPrecision = new NumberFormatInfo();
        setPrecision.NumberDecimalDigits = 2;

        decimal input1, input2, input3;
        while (true)
        {
            try
            {
                Console.Write("Введіть курс долара до гривні: ");
                input1 = Decimal.Parse(Console.ReadLine());
                Console.Write("Введіть курс євро до гривні: ");
                input2 = Decimal.Parse(Console.ReadLine());
                Console.Write("Введіть значення, яке бажаєте конвертувати: ");
                input3 = Decimal.Parse(Console.ReadLine());
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильно введені дані. Спробуйте ще раз.");
            }
        }

        Converter converter = new Converter(input1, input2);



        int choice;
        while (true)
        {
            Console.WriteLine("Виберіть, варіант конвертації: ");
            Console.WriteLine("1. Гривні у долари.");
            Console.WriteLine("2. Гривні у євро.");
            Console.WriteLine("3. Долари у гривні.");
            Console.WriteLine("4. Долари у євро.");
            Console.WriteLine("5. Вийти.");

            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильний вибір, спробуйте ще раз.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"{input3} гривень це {converter.HryvnyaToDollar(input3).ToString("N", setPrecision)} доларів.");
                    break;
                case 2:
                    Console.WriteLine($"{input3} гривень це {converter.HryvnyaToEuro(input3).ToString("N", setPrecision)} євро.");
                    break;
                case 3:
                    Console.WriteLine($"{input3} доларів це {converter.DolllarToHryvnya(input3).ToString("N", setPrecision)} гривень.");
                    break;
                case 4:
                    Console.WriteLine($"{input3} євро це {converter.EuroToHryvnya(input3).ToString("N", setPrecision)} гривень.");
                    break;
                case 5:
                    return;
                default:
                    Console.WriteLine("Неправильний вибір, спробуйте ще раз.");
                    break;
            }
        }


    }
}