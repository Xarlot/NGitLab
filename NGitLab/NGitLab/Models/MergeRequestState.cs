namespace NGitLab.Models {
    public enum MergeRequestState
    {
        // ReSharper disable InconsistentNaming
        opened,
        closed,
        merged,
        reopened,
        // ReSharper restore InconsistentNaming
    }
    public enum MergeRequestPipelineStatus
    {
        // ReSharper disable InconsistentNaming
        running,
        pending,
        success,
        failed,
        canceled,
        skipped
        // ReSharper restore InconsistentNaming
    }
    public enum MergeRequestStatus
    {
        // ReSharper disable InconsistentNaming
        @unchecked,
        can_be_merged,
        cannot_be_merged,
        cannot_be_merged_recheck
        // ReSharper restore InconsistentNaming
    }
}