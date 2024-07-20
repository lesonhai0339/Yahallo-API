using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace YAHALLO.Domain.Functions
{
    public interface IFiles<TDomain> where TDomain : class
    {
        bool CreateFolder(string fullPath);
        bool CreateFolder(string path, string folderName);
        bool DeleteFolder(string path);
        Task<bool> UpLoadimage(TDomain imageFile, string filePath);
        bool DeleteImage(string filePath);
        bool WriteToFile(string filePath, string fileName, TDomain Data);
     }
}