using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab.Impl {
    public class MilestoneClient : IMilestoneClient {
        const string MilestoneUrl = "/milestones";
        const string ProjectMilestoneUrl = "/projects/{0}/milestones";
        readonly string projectPath;
        readonly Api api;

        public MilestoneClient(Api api, int projectId) {
            this.api = api;
            projectPath = Project.Url + "/" + projectId;
        }

        public IEnumerable<Milestone> All()
        {
            return api.Get().GetAll<Milestone>(projectPath + "/milestones");
        }

        public IEnumerable<Milestone> AllInState(MilestoneState state)
        {
            return api.Get().GetAll<Milestone>(projectPath + "/milestones?state=" + state);
        }

        public Milestone Get(int id)
        {
            return api.Get().To<Milestone>(projectPath + "/milestones/" + id);
        }

        public IEnumerable<Milestone> Owned() {
            return api.Get().GetAll<Milestone>(MilestoneUrl);
        }

        public IEnumerable<Milestone> ForProject(int projectId) {
            return api.Get().GetAll<Milestone>(string.Format(ProjectMilestoneUrl, projectId));
        }

        public Milestone Create(MilestoneCreate issue)
        {
            return api
                .Post().With(issue)
                .To<Milestone>(projectPath + "/milestones");
        }
    }
}