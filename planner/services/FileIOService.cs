using Newtonsoft.Json;
using planner.Tasks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planner.services
{
    class FileIOService
    {

        private readonly string PATH;
        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<TaskModel>  LoadData()
        {
            var fileExists = File.Exists(PATH);
            if(!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TaskModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TaskModel>>(fileText);
            }
        }

        public void SaveData(object taskData)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(taskData);
                writer.Write(output);
            }
        }
    }
}
