﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Identity.Web.Test
{
    public class TestClientAssertion : ClientAssertionProviderBase
    {
        private int _n = 0;

        internal override Task<ClientAssertion> GetClientAssertion(CancellationToken cancellationToken)
        {
            _n++;
            return Task.FromResult(new ClientAssertion(
                _n.ToString(CultureInfo.InvariantCulture),
                DateTimeOffset.Now + TimeSpan.FromSeconds(1)));
        }
    }

    public class ClientAssertionTests
    {
        [Fact]
        public async Task TestClientAssertion()
        {
            TestClientAssertion clientAssertionDescription = new TestClientAssertion();

            string assertion = await clientAssertionDescription.GetSignedAssertion(CancellationToken.None).ConfigureAwait(false);

            Assert.Equal("1", assertion);
            assertion = await clientAssertionDescription.GetSignedAssertion(CancellationToken.None).ConfigureAwait(false);
            Assert.Equal("1", assertion);

            Assert.NotNull(clientAssertionDescription.Expiry);
            await Task.Delay(clientAssertionDescription.Expiry.Value - DateTimeOffset.Now + TimeSpan.FromMilliseconds(100)).ConfigureAwait(false);
            assertion = await clientAssertionDescription.GetSignedAssertion(CancellationToken.None).ConfigureAwait(false);
            Assert.Equal("2", assertion);
        }
    }
}
