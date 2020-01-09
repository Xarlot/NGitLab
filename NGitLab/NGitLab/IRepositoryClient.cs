using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NGitLab.Models;

namespace NGitLab {
    public interface IRepositoryClient {
        IEnumerable<Tag> Tags { get; }
        IEnumerable<TreeOrBlob> Tree { get; }

        IEnumerable<TreeOrBlob> GetTree(string branch, string path, bool recursive, int perPage = 20, int page = 1);

        IEnumerable<TreeOrBlob> TreeRecursive { get; }
        IEnumerable<Commit> Commits { get; }
        IEnumerable<Commit> GetCommits(string branch, int perPage = 20, int page = 1);

        IFilesClient Files { get; }
        IBranchClient Branches { get; }
        IProtectedBranchClient ProtectedBranches { get; }
        IPipelinesClient Pipelines { get; }
        IJobsClient Jobs { get; }
        IProjectHooksClient ProjectHooks { get; }
        IProjectSnippetsClient ProjectSnippets { get; }
        void GetRawBlob(string sha, Action<Stream> parser);
        Task GetRawBlobAsync(string sha, Func<Stream, Task> parser);
        Task GetArchiveAsync(string sha, Func<Stream, Task> parser);
        SingleCommit GetCommit(Sha1 sha);
        IEnumerable<Diff> GetCommitDiff(Sha1 sha);
        CompareInfo Compare(Sha1 from, Sha1 to);
        CommitStatus GetCommitStatus(Sha1 sha);
        Tag CreateTag(TagCreate tag);
        bool DeleteTag(string tagName);
    }
}