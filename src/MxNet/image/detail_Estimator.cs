using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.image
{
    /// <summary>
    /// [COMMENTS]
    /// </summary>
	public class detail_Estimator : Base
	{
		private static dynamic caller = Instance.mxnet.cv2.detail_Estimator;
		public detail_Estimator()
		{
			
			__self__ = caller;
		}

		
	}
}