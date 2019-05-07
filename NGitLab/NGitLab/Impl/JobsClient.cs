using System;
using System.Collections.Generic;
using System.IO;
using NGitLab.Models;

namespace NGitLab.Impl {
    public class JobsClient : IJobsClient {
        readonly Api api;
        readonly string jobsPath;
        readonly string repoPath;

        public JobsClient(Api api, string repoPath) {
            this.api = api;
            this.repoPath = repoPath;
            this.jobsPath = repoPath + "/jobs";
        }
        public IEnumerable<Job> All() {
            return api.Get().GetAll<Job>(jobsPath);
        }
        public void DownloadArtifact(Job job, Action<Stream> parser) {
            api.Get().Stream(jobsPath + $@"/{job.Id}/artifacts", parser);
        }
        public void DownloadTrace(Job job, Action<Stream> parser) {
            api.Get().Stream(jobsPath + $@"/{job.Id}/trace", parser);
        }
        public IEnumerable<Job> Get(Pipeline pipeline) {
            return this.api.Get().GetAll<Job>($"{this.repoPath}/pipelines/{pipeline.Id}/jobs");
        }
    }
}
