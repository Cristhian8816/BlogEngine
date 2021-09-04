// Copyright (c) SoftwareOne. All Rights Reserved.

namespace BlogEngine.Utils
{
    using Microsoft.Extensions.Configuration;
    using System.IO;

    public class ConfigurationManager
    {
        private readonly IConfiguration _configuration;
        public ConfigurationManager()
        {
          DiscoverApplicationPath();
          _configuration = new ConfigurationBuilder()
                .SetBasePath(ApplicationPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables().Build();

              SetJwtValues();
        }
        public int jwtMinutesExpirationTime { get; set; }

        public string jwtDefaultUserName { get; set; }

        public string jwtDefaultUserPassword { get; set; }

        public string jwtEncryptionMethod { get; set; }

        public string jwtSecretKey { get; set; }

        public static string ApplicationPath { get; set; }

        private void SetJwtValues()
        {
            jwtMinutesExpirationTime = int.Parse(_configuration["AuthorizationJwt:jwtMinutesExpirationTime"]);
            jwtDefaultUserName = _configuration["AuthorizationJwt:LoginDefaultUser"];
            jwtDefaultUserPassword = _configuration["AuthorizationJwt:LoginDefaultPassword"];
            jwtEncryptionMethod = _configuration["AuthorizationJwt:ApplicationMethodEncrypt"];
            jwtSecretKey = _configuration["AuthorizationJwt:ApplicationKey"];
        }
        public void DiscoverApplicationPath()
        {
           ApplicationPath = (Directory.GetCurrentDirectory()).Replace(".Tests\\bin\\Debug\\netcoreapp2.0","");
        }
    }
}
