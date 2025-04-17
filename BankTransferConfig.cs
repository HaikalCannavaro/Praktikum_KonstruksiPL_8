using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300106
{   
    public class BankTransferConfig
    {
        public class Config {
            public string lang { get; set; }
            public class Transfer
            {
                public int threshold { get; set; }
                public int low_fee { get; set; }
                public int high_fee { get; set; }
                public Transfer(int threshold, int low_fee, int high_fee)
                {
                    this.threshold = threshold;
                    this.low_fee = low_fee;
                    this.high_fee = high_fee;
                }
            }
            public Transfer transfer { get; set; }
            
            public List<string> method { get; set; }
            public class Confirmation
            {
                public string en { get; set; }
                public string id { get; set; }
                public Confirmation(string en, string id)
                {
                    this.en = en;
                    this.id = id;
                }
            }
            public Confirmation confirmation { get; set; }
        }
        public Config config;

        public const string filePath = "bank_transfer_config.json";
        public Config ReadConfigFile()
        {
            if (File.Exists(filePath))
            {
                String configJsonData = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<Config>(configJsonData);
                Console.WriteLine("Config file run successfully");
            }
            else {
                Console.WriteLine("Config file not found");
                return config;
              
            }
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            String jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }
        public void SetDefault()
        {
            config = new Config();
            config.lang = "en";
            config.transfer.threshold = 25000000;
            config.transfer.low_fee = 6500;
            config.transfer.high_fee = 15000;
            config.method = ["RTO (real-time)", "SKN", "RTGS", "BI FAST"];
            config.confirmation.en = "yes";
            config.confirmation.id = "ya";

        }
        public BankTransferConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
    }
}
