using System.IO;
using Microsoft.Extensions.Configuration;

namespace Test_Framework
{
    internal static class Configuration
    {
        public static IConfiguration AppSetting { get; }
        public static string ApplicationUrl => AppSetting["applicationUrl"];
        public static string StandardUserName => AppSetting["users:standard_user:username"];
        public static string LockedUserName => AppSetting["users:locked_out_user:username"];

        public static string ProblemUserName => AppSetting["users:problem_user:username"];

        public static string PerformanceUserName => AppSetting["users:performance_glitch_user:username"];
        public static string ErrorUserName => AppSetting["users:error_user:username"];
        public static string VisualUserName => AppSetting["users:visual_user:username"];

        public static string Password => AppSetting["password"];

        static Configuration()
        {
            AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("specflow.json")
                .Build();
        }
        

    }
}
