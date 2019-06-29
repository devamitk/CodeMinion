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
            ///	A simple lookup table that stores embeddings of a fixed dictionary and size.<br></br>
            ///	
            ///	This module is often used to store word embeddings and retrieve them using indices.<br></br>
            ///	
            ///	The input to the module is a list of indices, and the output is the corresponding
            ///	word embeddings.
            /// </summary>
            public partial class Embedding : Module
            {
                // auto-generated class
                
                public Embedding(PyObject pyobj) : base(pyobj) { }
                
                public Embedding(Module other) : base(other.PyObject as PyObject) { }
                
                public Embedding(int num_embeddings, int embedding_dim, int? padding_idx = null, float? max_norm = null, float? norm_type = 2.0f, bool? scale_grad_by_freq = false, bool? sparse = false)
                {
                    //auto-generated code, do not change
                    var nn = self.GetAttr("nn");
                    var __self__=nn;
                    var pyargs=ToTuple(new object[]
                    {
                        num_embeddings,
                        embedding_dim,
                    });
                    var kwargs=new PyDict();
                    if (padding_idx!=null) kwargs["padding_idx"]=ToPython(padding_idx);
                    if (max_norm!=null) kwargs["max_norm"]=ToPython(max_norm);
                    if (norm_type!=2.0f) kwargs["norm_type"]=ToPython(norm_type);
                    if (scale_grad_by_freq!=false) kwargs["scale_grad_by_freq"]=ToPython(scale_grad_by_freq);
                    if (sparse!=false) kwargs["sparse"]=ToPython(sparse);
                    dynamic py = __self__.InvokeMethod("Embedding", pyargs, kwargs);
                    self=py as PyObject;
                }
                
            }
        }
    }
    
}
