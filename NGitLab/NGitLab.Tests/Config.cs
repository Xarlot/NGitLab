namespace NGitLab.Tests {
    public static class Config {
        public const string ServiceUrl = "https://gitee.com/";
        public const string Secret = "y1ZcmHSidM4bqwYzjFPU";

        public static GitLabClient Connect() {
            return GitLabClient.Connect(ServiceUrl,"maikebing","kissme", Impl.Api.ApiVersion.V3_1);
        }
    }
}