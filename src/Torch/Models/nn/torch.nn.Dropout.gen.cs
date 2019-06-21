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
            /// During training, randomly zeroes some of the elements of the input
            /// tensor with probability p using samples from a Bernoulli
            /// distribution. Each channel will be zeroed out independently on every forward
            /// call.
            /// </summary>
            public partial class Dropout : PythonObject
            {
                // auto-generated class
                
                public Dropout(PyObject pyobj) : base(pyobj) { }
                
            }
        }
    }
    
}