using System.Text;

namespace Task_22
{
    abstract class Worker
    {
        protected Worker(string name)
        {
            Name = name;
            WorkDay = 0;
        }

        public string Name { get; private set; }
        public string Position { get; protected set; }
        public int WorkDay { get; protected set; }

        protected void Call()
        {
            WorkDay++;
        }
        protected void WriteCode()
        {
            WorkDay++;
        }
        protected void Relax() { }
        public abstract void FillWorkDay();
    }

    class Developer : Worker
    {
        public Developer(string name) : base(name)
        {
            Position = "Розробник";
        }

        public override void FillWorkDay()
        {
            WriteCode();
            Call();
            Relax();
            WriteCode();
        }
    }

    class Manager : Worker
    {
        public Manager(string name) : base(name)
        {
            Position = "Менеджер";
        }
        private Random _random = new Random();
        public override void FillWorkDay()
        {
            for (int i = 0; i < _random.Next(1, 11); i++)
            {
                Call();
            }

            Relax();

            for (int i = 0; i < _random.Next(1, 6); i++)
            {
                Call();
            }
        }
    }

    class Team
    {
        public Team(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        private List<Worker> _workerList = new List<Worker>();

        public void AddWorker(Worker worker)
        {
            _workerList.Add(worker);
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Назва команди: {Name}. Список працівників:");
            foreach (var worker in _workerList)
            {
                Console.WriteLine(worker.Name);
            }
            Console.WriteLine();
        }
        public void ShowDetailedInfo()
        {
            Console.WriteLine($"Назва команди: {Name}. Список працівників:");
            foreach (var worker in _workerList)
            {
                Console.WriteLine($"Ім'я: {worker.Name} - Посада: {worker.Position} - Завдань: {worker.WorkDay}");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            List<Team> teams = new List<Team>();


            while (true)
            {
                Console.WriteLine("Оберіть дію:");
                Console.WriteLine("1. Додати нову команду");
                Console.WriteLine("2. Додати працівника до команди");
                Console.WriteLine("3. Показати інформацію про команду");
                Console.WriteLine("4. Показати детальну інформацію про команду");
                Console.WriteLine("5. Вихід");

                int choice;

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неправильний варіант, спробуйте ще раз.\n");
                    continue;
                }

                int teamIndex;

                switch (choice)
                {
                    case 1:
                        Console.Write("Введіть ім'я команди: ");
                        string teamName = Console.ReadLine();
                        teams.Add(new Team(teamName));
                        Console.WriteLine("Нова команда успішно додана.\n");
                        break;

                    case 2:
                        if (teams.Count == 0)
                        {
                            Console.WriteLine("Наразі немає ні однієї доступної команди. Спробуйте додати одну.\n");
                            break;
                        }

                        Console.WriteLine("Оберіть команду:");
                        for (int i = 0; i < teams.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {teams[i].Name}");
                        }

                        teamIndex = int.Parse(Console.ReadLine()) - 1;
                        Console.Write("Введіть ім'я працівника ");
                        string workerName = Console.ReadLine();

                        Console.WriteLine("Оберіть посаду працівника: ");
                        Console.WriteLine("1. Розробник");
                        Console.WriteLine("2. Менеджер");

                        int positionChoice = int.Parse(Console.ReadLine());

                        Worker worker;
                        if (positionChoice == 1)
                        {
                            worker = new Developer(workerName);
                        }
                        else if (positionChoice == 2)
                        {
                            worker = new Manager(workerName);
                        }
                        else
                        {
                            Console.WriteLine("Неправильний варіант. Спробуйте ще раз.\n");
                            break;
                        }

                        worker.FillWorkDay();
                        teams[teamIndex].AddWorker(worker);
                        Console.WriteLine("Працівника успішно додано.\n");
                        break;

                    case 3:
                        if (teams.Count == 0)
                        {
                            Console.WriteLine("Наразі немає ні однієї доступної команди. Спробуйте додати одну.\n");
                            break;
                        }

                        Console.WriteLine("Оберіть команду: ");
                        for (int i = 0; i < teams.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {teams[i].Name}");
                        }

                        teamIndex = int.Parse(Console.ReadLine()) - 1;
                        teams[teamIndex].ShowInfo();
                        break;

                    case 4:
                        if (teams.Count == 0)
                        {
                            Console.WriteLine("Наразі немає ні однієї доступної команди. Спробуйте додати одну.\n");
                            break;
                        }

                        Console.WriteLine("Оберіть команду: ");
                        for (int i = 0; i < teams.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {teams[i].Name}");
                        }

                        teamIndex = int.Parse(Console.ReadLine()) - 1;
                        teams[teamIndex].ShowDetailedInfo();
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Неправильний варіант. Оберіть один з пунктів меню (1-5).\n");
                        break;
                }
            }
        }
    }
}