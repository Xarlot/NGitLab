using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab
{
    public interface IIssueClient
    {

        IEnumerable<Issue> All();

        IEnumerable<Issue> AllInState(IssueState state);

        Issue Get(int id);

        /// <summary>
        ///     Get a list of all project issues
        /// </summary>
        IEnumerable<Issue> Owned();

        /// <summary>
        ///     Get a list of issues for the specified project.
        /// </summary>
        IEnumerable<Issue> ForProject(int projectId);

        Issue Create(IssueCreate issue);

        Issue Delete(int issueIid);


        Issue Update(int issueId, IssueUpdate issue);

        IssueTimeTrack TimeEstimateSet(int issueId, string duration);

        IssueTimeTrack TimeEstimateReset(int issueId);

        IssueTimeTrack TimeSpentAdd(int issueId, string duration);

        IssueTimeTrack TimeSpentReset(int issueId);
        IssueTimeTrack TimeStats(int issueId);
        Issue ReopenIssue(int issueIid);
        Issue CloseIssue(int issueIid);

    }
}