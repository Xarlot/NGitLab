using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab {
    public interface IFilesClient {
        void Create(FileUpsert file);
        Task CreateAsync(FileUpsert file);
        void Update(FileUpsert file);
        Task UpdateAsync(FileUpsert file);
        void Delete(FileDelete file);
        Task DeleteAsync(FileDelete file);
        FileData Get(string filePath, string branch = "", System.Action<System.IO.Stream> parser = null);
        Task<FileData> GetAsync(string filePath, string branch = "", System.Func<System.IO.Stream, Task> parser = null);
    }
}