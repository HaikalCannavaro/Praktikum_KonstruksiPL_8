using System.Collections.Generic;
using System.Numerics;
using modul8_103022300106;
using static modul8_103022300106.BankTransferConfig.Config;

class Program
{
    static void Main(String[] args)
    {
        BankTransferConfig config = new BankTransferConfig();
        if (config.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
            int input = int.Parse(Console.ReadLine());
            if (input <= config.config.transfer.threshold)
            {
                Console.WriteLine("Biaya transfer: " + config.config.transfer.low_fee);
            }
            else
            {
                Console.WriteLine("Biaya transfer: " + config.config.transfer.high_fee);
            }

        }
        else if (config.config.lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan ditransfer:");
            int input = int.Parse(Console.ReadLine());
        }
    }
}