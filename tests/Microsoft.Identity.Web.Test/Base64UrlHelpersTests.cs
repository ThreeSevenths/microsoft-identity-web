﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using Microsoft.Identity.Web.Util;
using Xunit;

namespace Microsoft.Identity.Web.Test
{
    public class Base64UrlHelpersTests
    {
        [Fact]
        public void Encode_NullByteArray_ReturnsNull()
        {
            byte[]? byteArrayToEncode = null;
            Assert.Null(Base64UrlHelpers.Encode(byteArrayToEncode));
        }

        [Theory]
        [InlineData("123456", "MTIzNDU2")] // No padding
        [InlineData("12345678", "MTIzNDU2Nzg")] // 1 padding
        [InlineData("1234567", "MTIzNDU2Nw")] // 2 padding
        [InlineData("12>123", "MTI-MTIz")] // With Base64 plus
        [InlineData("12?123", "MTI_MTIz")] // With Base64 slash
        [InlineData("", "")] // Empty string
        public void Encode_UTF8ByteArrayOfDecodedString_ReturnsValidEncodedString(string stringToEncode, string expectedEncodedString)
        {
            var actualEncodedString = Base64UrlHelpers.Encode(Encoding.UTF8.GetBytes(stringToEncode));

            Assert.Equal(expectedEncodedString, actualEncodedString);
        }

        [Fact]
        public void Encode_NullString_ReturnsNull()
        {
            string? stringToEncode = null;
            Assert.Null(Base64UrlHelpers.Encode(stringToEncode));
        }

        [Theory]
        [InlineData("123456", "MTIzNDU2")] // No padding
        [InlineData("12345678", "MTIzNDU2Nzg")] // 1 padding
        [InlineData("1234567", "MTIzNDU2Nw")] // 2 padding
        [InlineData("12>123", "MTI-MTIz")] // With Base64 plus
        [InlineData("12?123", "MTI_MTIz")] // With Base64 slash
        [InlineData("", "")] // Empty string
        public void Encode_DecodedString_ReturnsEncodedString(string stringToEncode, string expectedEncodedString)
        {
            var actualEncodedString = Base64UrlHelpers.Encode(stringToEncode);

            Assert.Equal(expectedEncodedString, actualEncodedString);
        }

        [Theory]
        [InlineData("MTIzNDU2", "123456")] // No padding
        [InlineData("MTIzNDU2Nzg", "12345678")] // 1 padding
        [InlineData("MTIzNDU2Nw", "1234567")] // 2 padding
        [InlineData("MTI-MTIz", "12>123")] // With Base64 plus
        [InlineData("MTI_MTIz", "12?123")] // With Base64 slash
        [InlineData("", "")] // Empty string
        public void DecodeToString_ValidBase64UrlString_ReturnsDecodedString(string stringToDecode, string expectedDecodedString)
        {
            var actualDecodedString = Base64UrlHelpers.Decode(stringToDecode);

            Assert.Equal(expectedDecodedString, actualDecodedString);
        }

        [Theory]
        [InlineData("MTIzNDU2", "123456")] // No padding
        [InlineData("MTIzNDU2Nzg", "12345678")] // 1 padding
        [InlineData("MTIzNDU2Nw", "1234567")] // 2 padding
        [InlineData("MTI-MTIz", "12>123")] // With Base64 plus
        [InlineData("MTI_MTIz", "12?123")] // With Base64 slash
        [InlineData("", "")] // Empty string
        public void DecodeToBytes_ValidBase64UrlString_ReturnsByteArray(string stringToDecode, string expectedDecodedString)
        {
            var expectedDecodedByteArray = Encoding.UTF8.GetBytes(expectedDecodedString);

            var actualDecodedByteArray = Base64UrlHelpers.DecodeBytes(stringToDecode);

            Assert.Equal(expectedDecodedByteArray, actualDecodedByteArray);
        }

        [Fact]
        public void DecodeToBytes_InvalidBase64UrlStringLength_ThrowsException()
        {
            var stringToDecodeWithInvalidLength = "MTIzNDU21";

            Action decodeAction = () => Base64UrlHelpers.DecodeBytes(stringToDecodeWithInvalidLength);

            var exception = Assert.Throws<ArgumentException>(decodeAction);
            Assert.Equal(IDWebErrorMessage.InvalidBase64UrlString + " (Parameter 'str')", exception.Message);
        }
    }
}
