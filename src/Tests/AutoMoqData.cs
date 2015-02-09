﻿using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.AutoFixture.Xunit;

namespace Tests
{
	public class AutoMoqDataAttribute : AutoDataAttribute
	{
		public AutoMoqDataAttribute()
			: base(new Fixture()
				.Customize(new AutoMoqCustomization()))
		{ }
	}
}
