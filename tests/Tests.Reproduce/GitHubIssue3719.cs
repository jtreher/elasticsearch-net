// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elastic.Transport;
using Elastic.Transport.Extensions;
using FluentAssertions;
using Nest;
using Tests.Core.Client;

namespace Tests.Reproduce
{
	public class GitHubIssue3719
	{
		[U]
		public void SerializeDateMathWithMinimumThreeDecimalPlacesWhenTens()
		{
			DateMath dateMath = new DateTime(2019, 5, 7, 12, 0, 0, 20);

			var json = TestClient.Default.RequestResponseSerializer.SerializeToString(dateMath, TransportConfiguration.DefaultMemoryStreamFactory);
			json.Should().Be("\"2019-05-07T12:00:00.020\"");
		}

		[U]
		public void SerializeDateMathWithMinimumThreeDecimalPlacesWhenHundreds()
		{
			DateMath dateMath = new DateTime(2019, 5, 7, 12, 0, 0, 200);

			var json = TestClient.Default.RequestResponseSerializer.SerializeToString(dateMath, TransportConfiguration.DefaultMemoryStreamFactory);
			json.Should().Be("\"2019-05-07T12:00:00.200\"");
		}
	}
}
