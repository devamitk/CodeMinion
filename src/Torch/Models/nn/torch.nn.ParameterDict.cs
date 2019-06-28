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
            /// Holds parameters in a dictionary.
            /// 
            /// ParameterDict can be indexed like a regular Python dictionary, but parameters it
            /// contains are properly registered, and will be visible by all Module methods.
            /// 
            /// ParameterDict is an ordered dictionary that respects
            /// 
            /// the order of insertion, and
            /// in update(), the order of the merged OrderedDict
            /// or another ParameterDict (the argument to
            /// update()).
            /// 
            /// Note that update() with other unordered mapping
            /// types (e.g., Python’s plain dict) does not preserve the order of the
            /// merged mapping.
            /// </summary>
            public partial class ParameterDict : Module
            {
                // auto-generated class
                
                public ParameterDict(PyObject pyobj) : base(pyobj) { }
                
                public ParameterDict(params (string,Parameter)[] parameters)
                {
                    var nn = self.GetAttr("nn");
                    var __self__=nn;
                    dynamic py = __self__.InvokeMethod("ParameterDict");
                    self=py as PyObject;
                    update(parameters);
                }
                
                /// <summary>
                /// Remove all items from the ParameterDict.
                /// </summary>
                public void clear()
                {
                    //auto-generated code, do not change
                    var __self__=self;
                    dynamic py = __self__.InvokeMethod("clear");
                }
                
                /// <summary>
                /// Return an iterable of the ParameterDict key/value pairs.
                /// </summary>
                public IEnumerable<(string, Parameter)> items()
                {
                    //auto-generated code, do not change
                    var __self__=self;
                    dynamic py = __self__.InvokeMethod("items");
                    foreach (PyObject pair in py)
                    {
                        yield return (pair[0].As<string>(), new Parameter(pair[1]));
                    }
                }
                
                /// <summary>
                /// Return an iterable of the ParameterDict keys.
                /// </summary>
                public IEnumerable<string> keys()
                {
                    //auto-generated code, do not change
                    var __self__=self;
                    dynamic py = __self__.InvokeMethod("keys");
                    foreach(PyObject key in py)
                    {
                        yield return key.As<string>();
                    }
                }
                
                /// <summary>
                /// Remove key from the ParameterDict and return its parameter.
                /// </summary>
                public Parameter pop(string key)
                {
                    //auto-generated code, do not change
                    var __self__=self;
                    var pyargs=ToTuple(new object[]
                    {
                        key,
                    });
                    var kwargs=new PyDict();
                    dynamic py = __self__.InvokeMethod("pop", pyargs, kwargs);
                    return new Parameter(py as PyObject);
                }
                
                /// <summary>
                /// Update the ParameterDict with the key-value pairs from a
                /// mapping or an iterable, overwriting existing keys.
                /// 
                /// Note
                /// If parameters is an OrderedDict, a ParameterDict, or
                /// an iterable of key-value pairs, the order of new elements in it is preserved.
                /// </summary>
                public void update(params (string, Parameter)[] parameters)
                {
                    //auto-generated code, do not change
                    var __self__=self;
                    var pyargs=ToTuple(parameters.Select(pair =>
                    {
                        return ToTuple(new[]
                        {
                            new PyString(pair.Item1), pair.Item2.PyObject as PyObject
                        });
                    }).ToArray());
                    var kwargs=new PyDict();
                    dynamic py = __self__.InvokeMethod("update", pyargs, kwargs);
                }
                
                /// <summary>
                /// Return an iterable of the ParameterDict values.
                /// </summary>
                public IEnumerable<Parameter> values()
                {
                    //auto-generated code, do not change
                    var __self__=self;
                    dynamic py = __self__.InvokeMethod("values");
                    foreach(var p in py)
                        yield return new Parameter(p);
                }
                
            }
        }
    }
    
}