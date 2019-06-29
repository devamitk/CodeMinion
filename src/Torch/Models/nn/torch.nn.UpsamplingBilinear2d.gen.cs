// Code generated by CodeMinion: https://github.com/SciSharp/CodeMinion

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Python.Runtime;
using Numpy;
using Numpy.Models;

namespace Torch
{
    public static partial class torch {
        public static partial class nn {
            /// <summary>
            ///	Applies a 2D bilinear upsampling to an input signal composed of several input
            ///	channels.<br></br>
            ///	
            ///	To specify the scale, it takes either the size or the scale_factor
            ///	as it’s constructor argument.<br></br>
            ///	
            ///	When size is given, it is the output size of the image (h, w).
            /// </summary>
            public partial class UpsamplingBilinear2d : Module
            {
                // auto-generated class
                
                public UpsamplingBilinear2d(PyObject pyobj) : base(pyobj) { }
                
                public UpsamplingBilinear2d(Module other) : base(other.PyObject as PyObject) { }
                
                public UpsamplingBilinear2d(int[] size = null, double[] scale_factor = null)
                {
                    //auto-generated code, do not change
                    var nn = self.GetAttr("nn");
                    var __self__=nn;
                    var pyargs=ToTuple(new object[]
                    {
                    });
                    var kwargs=new PyDict();
                    if (size!=null) kwargs["size"]=ToPython(size);
                    if (scale_factor!=null) kwargs["scale_factor"]=ToPython(scale_factor);
                    dynamic py = __self__.InvokeMethod("UpsamplingBilinear2d", pyargs, kwargs);
                    self=py as PyObject;
                }
                
            }
        }
    }
    
}
