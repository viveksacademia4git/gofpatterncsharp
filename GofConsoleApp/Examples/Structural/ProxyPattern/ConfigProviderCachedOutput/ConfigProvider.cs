﻿using Core.Console.Interfaces;
using GofPatterns.Structural.ProxyPattern.Interfaces;

namespace GofConsoleApp.Examples.Structural.ProxyPattern.ConfigProviderCachedOutput;

internal class ConfigProvider : IProxyComponent<EnumConfigEnv, Config>
{
    private readonly IConsoleLogger logger;

    public ConfigProvider(IConsoleLogger logger)
    {
        this.logger = logger;
    }

    public Config Process(EnumConfigEnv input)
    {
        logger.Log($"Loading '{input}'.");

        return new Config
        {
            EnvType = input,
            DatabaseConnection = input + "-DatabaseConnection",
            SftpConnection = input + "-SftpConnection"
        };
    }
}