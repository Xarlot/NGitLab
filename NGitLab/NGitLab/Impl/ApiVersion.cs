namespace NGitLab.Impl
{
    public enum ApiVersion
    {
        V3,
        V4,
        V3_Oauth,
        V4_Oauth,
        V3_1
    }

    static class ApiVersionMethods
    {
        public static bool IsV4(this ApiVersion apiVersion)
        {
            return apiVersion == ApiVersion.V4 || apiVersion == ApiVersion.V4_Oauth;
        }
        
        public static bool IsV3(this ApiVersion apiVersion)
        {
            return !apiVersion.IsV4();
        }

        public static bool UsesOauth(this ApiVersion apiVersion)
        {
            return apiVersion == ApiVersion.V3_Oauth || apiVersion == ApiVersion.V4_Oauth;
        }
    }
}