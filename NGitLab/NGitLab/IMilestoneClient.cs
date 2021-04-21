using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab {
    public interface IMilestoneClient {

        IEnumerable<Milestone> All();

        IEnumerable<Milestone> AllInState(MilestoneState state);

        Milestone Get(int id);

        /// <summary>
        ///     Get a list of all project milestones
        /// </summary>
        IEnumerable<Milestone> Owned();

        /// <summary>
        ///     Get a list of milestone for the specified project.
        /// </summary>
        IEnumerable<Milestone> ForProject(int projectId);

        Milestone Create(MilestoneCreate milestone);

    }
}