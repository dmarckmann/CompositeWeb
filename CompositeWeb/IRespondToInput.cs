using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CompositeWeb
{
	public interface IRespondToInput
	{
		void Init(HttpContextBase context);

	}
}
