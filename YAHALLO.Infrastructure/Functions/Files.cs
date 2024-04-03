using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YAHALLO.Domain.Functions
{
    public class Files<TDomain>: IFiles<TDomain>
        where TDomain : class, IFormFile
    {
        public bool CreateFolder(string path, string folderName)
        {
            var srcpath = Path.Combine(path, folderName); 
            if(Directory.Exists(srcpath))
            {
                return false;
            }
            else
            {
                Directory.CreateDirectory(srcpath);
                return true;
            }
        }
        public bool DeleteFolder(string path)
        {
            if(Directory.Exists(path))
            {
                Directory.Delete(path, true);
                return true;
            }
            else
            { 
                return false;
            }
        }
        public async Task<bool> UpLoadimage(TDomain imageFile, string filePath)
        {
            var path= Path.Combine(filePath, imageFile.FileName);
            if (File.Exists(path))
            {
                return false;
            }
            else
            {
                using (var stream = new FileStream(filePath + "\\" + imageFile.FileName, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                    stream.Close();
                }
                return true;
            }            
        }
        public bool DeleteImage(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }
        public bool WriteToFile(string filePath, string fileName, TDomain Data)
        {
            var path= Path.Combine(filePath, fileName);
            if (File.Exists(path))
            {
                return false;
            }
            try
            {
                using(StreamWriter writer= new StreamWriter(path))
                {
                    //Type type = typeof(TDomain);
                    //int NumberOfRecords = type.GetProperties().Length;
                    //PropertyInfo[] properties = type.GetProperties();
                    //foreach (PropertyInfo property in properties)
                    //{
                    //    object value = property.GetValue(Data) ?? "";
                    //    Console.WriteLine($"{property.Name}: {value}");
                    //}
                    foreach (PropertyInfo property in typeof(TDomain).GetProperties())
                    {
                        object value = property.GetValue(Data) ?? "";
                        writer.Write($"{property.Name}: {value} - \t");
                    }
                    writer.WriteLine();
                }
                return true;
            }
            catch
            {
                return false;
            }    
        }
    }
}
