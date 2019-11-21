using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeTable.Models;

namespace TradeTable.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<TradeFillModel> LoadData()
        {
            var fileExist = File.Exists(PATH);
            if (!fileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TradeFillModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileTest = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TradeFillModel>>(fileTest);
            }
        }

        public void SaveData(object tradeDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(tradeDataList);
                writer.Write(output);
            }
        }
    }
}
