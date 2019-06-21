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
            /// Randomly zero out entire channels (a channel is a 3D feature map,
            /// e.g., the \(j\)-th channel of the \(i\)-th sample in the
            /// batched input is a 3D tensor \(\text{input}[i, j]\)).
            /// Each channel will be zeroed out independently on every forward call with
            /// probability p using samples from a Bernoulli distribution.
            /// </summary>
            public partial class Dropout3d : PythonObject
            {
                // auto-generated class
                
                public Dropout3d(PyObject pyobj) : base(pyobj) { }
                
            }
        }
    }
    
}