using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MxNet.image
{
    /// <summary>
    /// [COMMENTS]
    /// </summary>
	public class StereoSGBM : Base
	{
		private static dynamic caller = Instance.mxnet.cv2.StereoSGBM;
		public StereoSGBM()
		{
			
			__self__ = caller;
		}

		
	}
}