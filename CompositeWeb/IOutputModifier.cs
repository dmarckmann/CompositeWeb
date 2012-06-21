using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositeWeb
{
	public interface IOutputModifier
	{
		string Contents { get; }
		string Name { get; }
	}
}
