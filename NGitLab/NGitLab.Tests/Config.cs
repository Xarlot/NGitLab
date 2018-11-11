namespace NGitLab.Tests {
    public static class Config {
        public const string ServiceUrl = "https://gitclub.cn/";
        public const string Secret = "";

        public static GitLabClient Connect() {
            return GitLabClient.Connect(ServiceUrl,"","", Impl.Api.ApiVersion.V3_1);
        }
    }
}