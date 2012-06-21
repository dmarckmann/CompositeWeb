using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositeWeb
{
	public interface INeedInlineId : IOutputModifier
	{
		string Id { set; }
	}
}
