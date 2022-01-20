using System.Diagnostics;



namespace Lesson1
{
    class ProcessesTask
    {
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("1 - Show all sorted processes by ascending Id");
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("2 - Show all sorted processes by descending Id");
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("3 - Show all sorted processes by name");
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("4 - Find process by id");
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("5 - Threads info");
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("6 - Modules info");
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("7 - Start process");
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("8 - Kill process");
                Console.WriteLine("_______________________________________________");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("_______________________________________________");
                Console.Write(">>>");
                string? input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ShowallSortedProcessByAscId();
                        break;
                    case "2":
                        ShowallSortedProcessByDescId();
                        break;
                    case "3":
                        ShowallSortedProcessByName();
                        break;
                    case "4":
                        FindByID();
                        break;
                    case "5":
                        ShowThreads();
                        break;
                    case "6":
                        ShowModules();
                        break;
                    case "7":
                        StartProcess();
                        break;
                    case "8":
                        Kill();
                        break;
                    case "0":
                        Exit();
                        break;
                }

            }
        }
        void ShowallSortedProcessByAscId()
        {
            var processes = from p in Process.GetProcesses() orderby p.Id select p;
            foreach (var process in processes)
            {
                Console.WriteLine($"ProcessID: {process.Id},\tProcessName:{process.ProcessName}");
            }
        }
        void ShowallSortedProcessByName()
        {
            var processes = from p in Process.GetProcesses() orderby p.ProcessName select p;
            foreach (var process in processes)
            {
                Console.WriteLine($"ProcessID: {process.Id},\tProcessName:{process.ProcessName}");
            }
        }
        void ShowallSortedProcessByDescId()
        {
            try
            {
                var processes = from p in Process.GetProcesses() orderby p.Id descending select p;
                foreach (var process in processes)
                {
                    Console.WriteLine($"ProcessID: {process.Id},\tProcessName:{process.ProcessName}");
                }
            }catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        void FindByID()
        {
            Console.Write("Enter Id: ");
            string? input = Console.ReadLine();
            try
            {
                int pid = int.Parse(input);
                var p = Process.GetProcessById(pid);
                Console.WriteLine($"ProcessID: {p.Id}\nProcessName:{p.ProcessName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void ShowThreads()
        {
            Console.Write("Enter Id: ");
            string? input = Console.ReadLine();
            try
            {
                int pid = int.Parse(input);
                var p = Process.GetProcessById(pid);
                ProcessThreadCollection threads = p.Threads;
                Console.WriteLine($"Threads");
                foreach (ProcessThread t in threads)
                {
                    Console.WriteLine($"\tId: {t.Id},\tStart: {t.StartTime},\tPriority: {t.PriorityLevel}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void ShowModules()
        {
            Console.Write("Enter Id: ");
            string? input = Console.ReadLine();
            try
            {
                int pid = int.Parse(input);
                var p = Process.GetProcessById(pid);
                Console.WriteLine("Threads");
                foreach (ProcessModule module in p.Modules)
                {
                    Console.WriteLine($"Name: {module.ModuleName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        void StartProcess()
        {
            var p = Process.Start("C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe", "https://wikipedia.org");
            Console.WriteLine($"Id: {p.Id}");
        }
        void Exit()
        {
            Environment.Exit(1);
        }
        void Kill()
        {
            Console.Write("Enter Id: ");
            string? input = Console.ReadLine();
            try
            {
                int pid = int.Parse(input);
                var p = Process.GetProcessById(pid);
                p.Kill();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ProcessesTask pr = new ProcessesTask();
            pr.Start();
        }
    }

        }