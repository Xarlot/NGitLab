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
    public enum MergeRequestStatus
    {
        // ReSharper disable InconsistentNaming
        can_be_merged,
        cannot_be_merged
        // ReSharper restore InconsistentNaming
    }
}