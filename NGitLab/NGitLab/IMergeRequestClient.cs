using System.Collections.Generic;
using NGitLab.Models;

namespace NGitLab {
    public interface IMergeRequestClient {
        IEnumerable<MergeRequest> All(bool withMergeStatusRecheck = false);
        IEnumerable<MergeRequest> AllInState(MergeRequestState state, bool withMergeStatusRecheck = false);
        MergeRequest Get(int id);

        MergeRequest Create(MergeRequestCreate mergeRequest);
        MergeRequest Update(int mergeRequestId, MergeRequestUpdate mergeRequest);
        MergeRequest Delete(int mergeRequestIid);
        MergeRequest Accept(int mergeRequestId, MergeCommitMessage message);

        IMergeRequestCommentClient Comments(int mergeRequestId);
        IMergeRequestCommitClient Commits(int mergeRequestId);
        IMergeRequestChangesClient Changes(int mergeRequestId);
    }
}
