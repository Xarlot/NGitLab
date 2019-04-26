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
        Task GetAsync(string filePath, string branch, System.Func<System.IO.Stream, Task> parser);
        Task<FileData> GetAsync(string filePath, string branch = "");
    }
}