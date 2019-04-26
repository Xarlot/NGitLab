using Newtonsoft.Json;
using NGitLab.Models;
using System.IO;
using System.Threading.Tasks;

namespace NGitLab.Impl {
    public class FileClient : IFilesClient {
        readonly Api api;
        readonly string repoPath;

        public FileClient(Api api, string repoPath) {
            this.api = api;
            this.repoPath = repoPath;
        }

        private string GetFilePath(string filePath, string branch, bool raw = false)
        {
            filePath = System.Web.HttpUtility.UrlEncode(filePath);
            branch = System.Web.HttpUtility.UrlEncode(branch);

            return api._ApiVersion.IsV4()
                ? $"/files/{filePath}{(raw ? "/raw" : null)}?ref={branch}"
                : $"/files{(raw ? "/raw" : null)}?file_path={filePath}&ref={branch}";
        }

        public void Create(FileUpsert file) {
            api.Post().With(file).Stream(repoPath + GetFilePath(file.Path, file.Branch), s => { });
        }

        public Task CreateAsync(FileUpsert file)
        {
            return api.Post().With(file).StreamAsync(repoPath + GetFilePath(file.Path, file.Branch), s => Task.FromResult(0));
        }

        public void Update(FileUpsert file) {
            api.Put().With(file).Stream(repoPath + GetFilePath(file.Path, file.Branch), s => { });
        }

        public Task UpdateAsync(FileUpsert file)
        {
            return api.Put().With(file).StreamAsync(repoPath + GetFilePath(file.Path, file.Branch), s => Task.FromResult(0));
        }

        public void Delete(FileDelete file) {
            api.Delete().With(file).Stream(repoPath + GetFilePath(file.Path, file.Branch), s => { });
        }

        public Task DeleteAsync(FileDelete file)
        {
            return api.Delete().With(file).StreamAsync(repoPath + GetFilePath(file.Path, file.Branch), s => Task.FromResult(0));
        }

        public Task GetAsync(string filePath, string branch, System.Func<Stream, Task> parser)
        {
            return api.Get().StreamAsync(repoPath + GetFilePath(filePath, branch, true), parser);
        }

        public async Task<FileData> GetAsync(string filePath, string branch = "")
        {
            FileData fileData = null;

            if (branch == "")
                branch = "master";

            await api.Get().StreamAsync(repoPath + GetFilePath(filePath, branch), async s =>
            {
                string content;
                using (var sr = new StreamReader(s))
                    content = await sr.ReadToEndAsync();
                fileData = JsonConvert.DeserializeObject<FileData>(content);
            });

            return fileData;
        }
    }
}