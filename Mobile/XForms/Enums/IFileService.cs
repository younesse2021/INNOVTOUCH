using System;
using System.Threading.Tasks;

namespace XForms.Enums
{
    public interface IFileService
    {
        Task<string> GetLocalFile(string filePath);

        bool CheckStoragePer();
    }
}