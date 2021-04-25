﻿using DiscordDotNet.Abstractions.DataModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordDotNet
{
    /// <summary>
    /// Interface for Discord Web APIs (v8)
    /// </summary>
    public interface IDiscordWebV8Service
    {
        /// <summary>
        /// Get the commands for the application
        /// </summary>
        /// <param name="applicationId">application ID to request</param>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>application commands</returns>
        Task<ApplicationCommand[]> GetApplicationCommands(string applicationId, CancellationToken? cancellationToken = null);
        /// <summary>
        /// Get the gateway Uri
        /// </summary>
        /// <param name="cancellationToken">cancellation token</param>
        /// <returns>Uri to connect to</returns>
        Task<Gateway> GetGateway(CancellationToken? cancellationToken = null);
    }
}
