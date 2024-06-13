using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Себестойност
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Activity> activities = new List<Activity>();

            // Въвеждане на данни
            Console.Write("Въведете брой дейности: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Дейност {i + 1}:");
                Console.Write("Код: ");
                string code = Console.ReadLine();
                Console.Write("Вид дейност: ");
                string type = Console.ReadLine();
                Console.Write("Заплащане по тарифа за час: ");
                double hourlyRate = double.Parse(Console.ReadLine());
                Console.Write("Брой човекочасове: ");
                int manHours = int.Parse(Console.ReadLine());

                activities.Add(new SpecificActivity(code, type, hourlyRate, manHours));
            }

            // Извежда цялата информация за n на брой дейности
            Console.WriteLine("Информация за всички дейности:");
            activities.ForEach(a => a.DisplayInfo());

            // Извежда данните за дейност по зададен код на дейност
            Console.Write("Въведете код за търсене: ");
            string searchCode = Console.ReadLine();
            var activity = activities.FirstOrDefault(a => a.Code == searchCode);
            if (activity != null)
            {
                activity.DisplayInfo();
            }
            else
            {
                Console.WriteLine("Дейност с този код не съществува.");
            }

            // Изчислява средна сума за даден вид дейност
            Console.Write("Въведете вид дейност за изчисление на средна сума: ");
            string searchType = Console.ReadLine();
            var selectedActivities = activities.Where(a => a.Type == searchType);
            if (selectedActivities.Any())
            {
                double averagePayment = selectedActivities.Average(a => a.CalculatePayment());
                Console.WriteLine($"Средна сума за дейност {searchType}: {averagePayment}");
            }
            else
            {
                Console.WriteLine("Няма данни за този вид дейност.");
            }

            // Извежда данните за дейността от даден вид с най-високо заплащане
            var maxPaymentActivity = activities.OrderByDescending(a => a.CalculatePayment()).FirstOrDefault();
            if (maxPaymentActivity != null)
            {
                Console.WriteLine("Дейност с най-високо заплащане:");
                maxPaymentActivity.DisplayInfo();
            }

            // Сортира данните в системата по код
            var sortedActivities = activities.OrderBy(a => a.Code).ToList();
            Console.WriteLine("Сортирани данни по код:");
            sortedActivities.ForEach(a => a.DisplayInfo());

            // Запис на данните във файл
            string filePath = "activities.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var act in activities)
                {
                    writer.WriteLine($"{act.Code};{act.Type};{act.HourlyRate};{act.ManHours};{act.CalculatePayment()}");
                }
            }
            Console.WriteLine($"Данните са записани във файл {filePath}.");
        }
    }
}
