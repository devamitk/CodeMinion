using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.Gluon.NN
{
    /// <summary>
    /// [COMMENTS]
    /// </summary>
	public class Sequential : Base
	{
		private static dynamic caller = Instance.mxnet.gluon.nn.Sequential;
		public Sequential()
		{
			
			__self__ = caller;
		}

		
	}
}