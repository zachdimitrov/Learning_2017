namespace Computers.UI
{
    using System;
    using Logic;
    using Logic.ComputerTypes;
    using Logic.Manifacturers;

    public static class Program
    {
        private static PersonalComputer pc;
        private static Laptop laptop;
        private static Server server;

        public static void Main()
        {
            CreateComputers();
            ProcessCommands();
        }

        private static void CreateComputers()
        {
            var manufacturer = Console.ReadLine();
            IComputersFactory computerFactory;

            if (manufacturer == "HP")
            {
                computerFactory = new HpComputersFactory();
            }
            else if (manufacturer == "Dell")
            {
                computerFactory = new DellComputersFactory();
            }
            else if (manufacturer == "Lenovo")
            {
                computerFactory = new LenovoComputersFactory();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }

            pc = computerFactory.CreatePersonalComputer();
            laptop = computerFactory.CreateLaptop();
            server = computerFactory.CreateServer();
        }

        private static void ProcessCommands()
        {
            while (true)
            {
                var command = Console.ReadLine();
                if (command == null || command.StartsWith("Exit"))
                {
                    break;
                }

                var commandParsed = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParsed.Length != 2)
                {
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                }

                var commandName = commandParsed[0];
                var commandArgument = int.Parse(commandParsed[1]);
                if (commandName == "Charge")
                {
                    laptop.ChargeBattery(commandArgument);
                }
                else if (commandName == "Process")
                {
                    server.Process(commandArgument);
                }
                else if (commandName == "Play")
                {
                    pc.Play(commandArgument);
                }
                else
                {
                    Console.WriteLine("Invalid command!");
                }
            }
        }
    }
}

// https://telerikacademy.com/Courses/LectureResources/Video/6883/%D0%92%D0%B8%D0%B4%D0%B5%D0%BE-8-%D0%BE%D0%BA%D1%82%D0%BE%D0%BC%D0%B2%D1%80%D0%B8-2015-%D0%9D%D0%B8%D0%BA%D0%B8

// Automatic test in console - write output in file
// Computers.UI.Console.exe < test1.txt > test1out.txt