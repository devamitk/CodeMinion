using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.image
{
    /// <summary>
    /// [COMMENTS]
    /// </summary>
	public class BOWKMeansTrainer : Base
	{
		private static dynamic caller = Instance.mxnet.cv2.BOWKMeansTrainer;
		public BOWKMeansTrainer()
		{
			
			__self__ = caller;
		}

		
	}
}