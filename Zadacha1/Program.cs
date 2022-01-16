using System;
using System.Collections.Generic;
using System.Linq;

namespace Zadacha1
{
    class Computer
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string CPU { get; set; }
        public int GHz { get; set; }
        public int RAM { get; set; }
        public int SSD { get; set; }
        public string GPU { get; set; }
        public int Cost { get; set; }
        public int Instock { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>()
            {
                new Computer(){ Code=1, Name="Компьютер iRU Home 615", CPU="Intel Core i5" , GHz=2900, RAM=8, SSD= 240,GPU="1024ГБ",Cost=40990,Instock=8},
                new Computer(){ Code=2, Name="Компьютер Acer Aspire XC-830", CPU="Intel Celeron" , GHz=2000, RAM=4, SSD=128,GPU="нет",Cost=13990,Instock=2},
                new Computer(){ Code=3,Name="Компьютер Apple Mac mini Z12P000B0", CPU="Apple M1 8 core" , GHz=1278, RAM=16, SSD= 512,GPU="нет",Cost=109990,Instock=1},
                new Computer(){ Code=4,Name="Компьютер iRU Home 310H5SE", CPU="Intel Core i3" , GHz=3600, RAM=8, SSD= 240,GPU="нет",Cost=27190,Instock=3},
                new Computer(){ Code=5, Name="Компьютер iRU Home 120", CPU=" AMD E1 6010" , GHz=1350, RAM=4, SSD= 120,GPU="нет",Cost=14090,Instock=53},
                new Computer(){ Code=6,Name="Компьютер iRU Game 525", CPU=" AMD Ryzen 5", GHz=3600, RAM=16, SSD= 240,GPU="12288ГБ",Cost=139990,Instock=3},
                new Computer(){ Code=7, Name="Компьютер iRU Game 717", CPU="Intel Core i7" , GHz=2900, RAM=32, SSD= 500,GPU="24576ГБ",Cost=381090,Instock=3},
            };
            string cpu = "0";
            Console.WriteLine("Выберите производителя процессоров ");
            Console.WriteLine("Intel введите 1");
            Console.WriteLine("AMD введите 2");
            Console.WriteLine("Apple введите 3");
            switch (Convert.ToByte(Console.ReadLine()))
            {
                case 1:
                    cpu = "Intel";
                    break;
                case 2:
                    cpu = "AMD";
                    break;
                case 3:
                    cpu = "AMD";
                    break;
            }
            if (cpu != "0")
            {

                List<Computer> processors = listComputer
                    .Where(d => d.CPU.Contains(cpu))
                    .ToList();
                Console.WriteLine($"Все компьютеры с процессором производства {cpu} ");
                Console.WriteLine();

                foreach (Computer d in processors)
                    Console.WriteLine($"код{ d.Code} { d.Name } процессор { d.CPU} { d.GHz}МГц Оперативная память { d.RAM}ГБ SSD { d.SSD}ГБ память видеокарты { d.GPU} стоимость { d.Cost}руб наличие { d.Instock}шт");
            }
            else
            {
                Console.WriteLine("Нет производителя с указанным номером");
            }
            Console.WriteLine();
            Console.WriteLine("Введите минимальный объем ОЗУ ");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<Computer> memory = listComputer
                .Where(d => d.RAM >= ram)
                .ToList();
            Console.WriteLine();
            Console.WriteLine($"Все компьютеры с объемом ОЗУ не ниже {ram} ГБ");
            Console.WriteLine();
            foreach (Computer d in memory)
                Console.WriteLine($"код{ d.Code} { d.Name } процессор { d.CPU} { d.GHz}МГц Оперативная память { d.RAM}ГБ SSD { d.SSD}ГБ память видеокарты { d.GPU} стоимость { d.Cost}руб наличие { d.Instock}шт");
            List<Computer> cost = listComputer
                .OrderBy(d => d.Cost)
                .ToList();
            Console.WriteLine();
            Console.WriteLine($"Список компьютеров по увеличению стоимости");
            Console.WriteLine();
            foreach (Computer d in cost)
                Console.WriteLine($"код{ d.Code} { d.Name } процессор { d.CPU} { d.GHz}МГц Оперативная память { d.RAM}ГБ SSD { d.SSD}ГБ память видеокарты { d.GPU} стоимость { d.Cost}руб наличие { d.Instock}шт");
            Console.WriteLine();
            var processorGroups = listComputer
                      .GroupBy(p => p.CPU.Substring(0, 5));
            foreach (IGrouping<string, Computer> g in processorGroups)
            {
                Console.WriteLine($"С процессором {g.Key}");
                Console.WriteLine();
                foreach (var t in g)
                {
                    Console.WriteLine($"код{ t.Code} { t.Name } процессор { t.CPU} { t.GHz}МГц Оперативная память { t.RAM}ГБ SSD { t.SSD}ГБ память видеокарты { t.GPU} стоимость { t.Cost}руб наличие { t.Instock}шт");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Самый бюджетный компьютер");
            Console.WriteLine();
            Computer deshevo = cost.First();
            Console.WriteLine($"код{ deshevo.Code} { deshevo.Name } процессор { deshevo.CPU} { deshevo.GHz}МГц Оперативная память { deshevo.RAM}ГБ SSD { deshevo.SSD}ГБ память видеокарты { deshevo.GPU} стоимость { deshevo.Cost}руб наличие { deshevo.Instock}шт");
            Console.WriteLine();
            Console.WriteLine($"Самый дорогой компьютер");
            Console.WriteLine();
            Computer dorogo = cost.Last();
            Console.WriteLine($"код{ dorogo.Code} { dorogo.Name } процессор { dorogo.CPU} { dorogo.GHz}МГц Оперативная память { dorogo.RAM}ГБ SSD { dorogo.SSD}ГБ память видеокарты { dorogo.GPU} стоимость { dorogo.Cost}руб наличие { dorogo.Instock}шт");
            Console.WriteLine();
            switch (listComputer
                 .Any(d => d.Instock >= 30))
            {
                case true:
                    Console.WriteLine($"Есть хотя бы один компьютер в количестве не менее 30 штук");
                    break;
                case false:
                    Console.WriteLine($"Нет компьютеров в количестве не менее 30 штук");
                    break;
            }
            Console.ReadKey();
        }
    }
}
