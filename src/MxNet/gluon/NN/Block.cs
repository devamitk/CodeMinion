using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.Gluon.NN
{
    /// <summary>
    /// [COMMENTS]
    /// </summary>
	public class Block : Base
	{
		private static dynamic caller = Instance.mxnet.gluon.nn.Block;
		public Block()
		{
			
			__self__ = caller;
		}

		
	}
}