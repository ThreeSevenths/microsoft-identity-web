﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Identity.Abstractions;

namespace Microsoft.Identity.Web
{
    /// <inheritdoc/>
    internal partial class DownstreamApi : IDownstreamApi
    {
        /// <inheritdoc/>
        public async Task<TOutput?> GetForUserAsync<TOutput>(
            string? serviceName,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            ClaimsPrincipal? user = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Get);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, false, null, user, cancellationToken).ConfigureAwait(false);

            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<TOutput?> GetForUserAsync<TInput, TOutput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            ClaimsPrincipal? user = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Get);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, false, effectiveInput, user, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<TOutput?> GetForAppAsync<TOutput>(
            string? serviceName,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Get);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, true, null, null, cancellationToken).ConfigureAwait(false);

            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<TOutput?> GetForAppAsync<TInput, TOutput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Get);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, true, effectiveInput, null, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task PostForUserAsync<TInput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            ClaimsPrincipal? user = null,
            CancellationToken cancellationToken = default)
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Post);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, false, effectiveInput, user, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
        }

        /// <inheritdoc/>
        public async Task<TOutput?> PostForUserAsync<TInput, TOutput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            ClaimsPrincipal? user = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Post);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, false, effectiveInput, user, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task PostForAppAsync<TInput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            CancellationToken cancellationToken = default)
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Post);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, true, effectiveInput, null, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
        }

        /// <inheritdoc/>
        public async Task<TOutput?> PostForAppAsync<TInput, TOutput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Post);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, true, effectiveInput, null, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task PutForUserAsync<TInput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            ClaimsPrincipal? user = null,
            CancellationToken cancellationToken = default)
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Put);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, false, effectiveInput, user, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
        }

        /// <inheritdoc/>
        public async Task<TOutput?> PutForUserAsync<TInput, TOutput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            ClaimsPrincipal? user = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Put);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, false, effectiveInput, user, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task PutForAppAsync<TInput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            CancellationToken cancellationToken = default)
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Put);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, true, effectiveInput, null, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
        }

        /// <inheritdoc/>
        public async Task<TOutput?> PutForAppAsync<TInput, TOutput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Put);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, true, effectiveInput, null, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }

#if !NETFRAMEWORK && !NETSTANDARD2_0

        /// <inheritdoc/>
        public async Task PatchForUserAsync<TInput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            ClaimsPrincipal? user = null,
            CancellationToken cancellationToken = default)
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Patch);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, false, effectiveInput, user, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
        }

        /// <inheritdoc/>
        public async Task<TOutput?> PatchForUserAsync<TInput, TOutput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            ClaimsPrincipal? user = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Patch);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, false, effectiveInput, user, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task PatchForAppAsync<TInput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            CancellationToken cancellationToken = default)
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Patch);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, true, effectiveInput, null, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
        }

        /// <inheritdoc/>
        public async Task<TOutput?> PatchForAppAsync<TInput, TOutput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Patch);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, true, effectiveInput, null, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }

#endif // !NETFRAMEWORK && !NETSTANDARD2_0

        /// <inheritdoc/>
        public async Task DeleteForUserAsync<TInput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            ClaimsPrincipal? user = null,
            CancellationToken cancellationToken = default)
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Delete);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, false, effectiveInput, user, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
        }

        /// <inheritdoc/>
        public async Task<TOutput?> DeleteForUserAsync<TInput, TOutput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            ClaimsPrincipal? user = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Delete);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, false, effectiveInput, user, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task DeleteForAppAsync<TInput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            CancellationToken cancellationToken = default)
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Delete);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, true, effectiveInput, null, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
        }

        /// <inheritdoc/>
        public async Task<TOutput?> DeleteForAppAsync<TInput, TOutput>(
            string? serviceName,
            TInput input,
            Action<DownstreamApiOptionsReadOnlyHttpMethod>? downstreamApiOptionsOverride = null,
            CancellationToken cancellationToken = default)
            where TOutput : class
        {
            DownstreamApiOptions effectiveOptions = MergeOptions(serviceName, downstreamApiOptionsOverride, HttpMethod.Delete);
            HttpContent? effectiveInput = SerializeInput(input, effectiveOptions);
            HttpResponseMessage response = await CallApiInternalAsync(serviceName, effectiveOptions, true, effectiveInput, null, cancellationToken).ConfigureAwait(false);

            // Only dispose the HttpContent if was created here, not provided by the caller.
            if (input is not HttpContent)
            {
                effectiveInput?.Dispose();
            }
            return await DeserializeOutput<TOutput>(response, effectiveOptions).ConfigureAwait(false);
        }
    }
}
