using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab.Impl {
    public class IssueClient : IIssueClient {
        const string IssuesUrl = "/issues";
        const string ProjectIssuesUrl = "/projects/{0}/issues";
        readonly string projectPath;
        readonly Api api;

        public IssueClient(Api api, int projectId) {
            this.api = api;
            projectPath = Project.Url + "/" + projectId;
        }

        public IEnumerable<Issue> All()
        {
            return api.Get().GetAll<Issue>(projectPath + "/issues");
        }

        public IEnumerable<Issue> AllInState(IssueState state)
        {
            return api.Get().GetAll<Issue>(projectPath + "/issues?state=" + state);
        }

        public Issue Get(int id)
        {
            return api.Get().To<Issue>(projectPath + "/issues/" + id);
        }


        public IEnumerable<Issue> Owned() {
            return api.Get().GetAll<Issue>(IssuesUrl);
        }

        public IEnumerable<Issue> ForProject(int projectId) {
            return api.Get().GetAll<Issue>(string.Format(ProjectIssuesUrl, projectId));
        }

        public Issue Create(IssueCreate issue)
        {
            return api
                .Post().With(issue)
                .To<Issue>(projectPath + "/issues");
        }
        public Issue Delete(int issueIid)
        {
            return api.Delete().To<Issue>(projectPath + "/issues/" + issueIid);
        }
        public Issue Update(int issueId, IssueUpdate issue)
        {
            return api
                .Put().With(issue)
                .To<Issue>(projectPath + "/issues/" + issueId);
        }

        public IssueTimeTrack TimeEstimateSet(int issueIid, string duration)
        {
            return api.Post().To<IssueTimeTrack>(projectPath + "/issues/" + issueIid + "/time_estimate?duration=" + duration);
            // return api.Get().GetAll<Issue>(projectPath + "/issues?state=" + state);
        }

        public Issue ReopenIssue(int issueIid)
        {
            return api.Put().To<Issue>(projectPath + "/issues/" + issueIid + "?state_event=reopen");
        }

        public Issue CloseIssue(int issueIid)
        {
            return api.Put().To<Issue>(projectPath + "/issues/" + issueIid + "?state_event=close");
        }

        public IssueTimeTrack TimeEstimateReset(int issueIid)
        {
            return api.Post().To<IssueTimeTrack>(projectPath + "/issues/" + issueIid + "/reset_time_estimate");
        }

        public IssueTimeTrack TimeSpentAdd(int issueIid, string duration)
        {
            return api.Post().To<IssueTimeTrack>(projectPath + "/issues/" + issueIid + "/add_spent_time?duration=" + duration);
        }

        public IssueTimeTrack TimeSpentReset(int issueIid)
        {
            return api.Post().To<IssueTimeTrack>(projectPath + "/issues/" + issueIid + "/reset_spent_time");
        }
        public IssueTimeTrack TimeStats(int issueIid)
        {
            return api.Get().To<IssueTimeTrack>(projectPath + "/issues/" + issueIid + "/time_stats");
        }
    }
}