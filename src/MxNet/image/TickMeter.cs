using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.image
{
    /// <summary>
    /// [COMMENTS]
    /// </summary>
	public class TickMeter : Base
	{
		private static dynamic caller = Instance.mxnet.cv2.TickMeter;
		public TickMeter()
		{
			
			__self__ = caller;
		}

		
	}
}