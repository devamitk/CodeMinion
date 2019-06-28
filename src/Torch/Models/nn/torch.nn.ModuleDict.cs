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
            /// Holds submodules in a dictionary.
            /// 
            /// ModuleDict can be indexed like a regular Python dictionary,
            /// but modules it contains are properly registered, and will be visible by all
            /// Module methods.
            /// 
            /// ModuleDict is an ordered dictionary that respects
            /// 
            /// the order of insertion, and
            /// in update(), the order of the merged OrderedDict
            /// or another ModuleDict (the argument to update()).
            /// 
            /// Note that update() with other unordered mapping
            /// types (e.g., Python’s plain dict) does not preserve the order of the
            /// merged mapping.
            /// </summary>
            public partial class ModuleDict : PythonObject, IEnumerable<(string, Module)>
            {
                public ModuleDict(PyObject pyobj) : base(pyobj) { }
                
                public ModuleDict(params (string, Module)[] modules)
                {
                    var nn = self.GetAttr("nn");
                    var __self__=nn;
                    dynamic py = __self__.InvokeMethod("ModuleDict");
                    self=py as PyObject;
                        update(modules);
                }
                
                /// <summary>
                /// Remove all items from the ModuleDict.
                /// </summary>
                public void clear()
                {
                    var __self__=self;
                    dynamic py = __self__.InvokeMethod("clear");
                }
                
                /// <summary>
                /// Return an iterable of the ModuleDict key/value pairs.
                /// </summary>
                public IEnumerable<(string, Module)> items()
                {
                    var __self__=self;
                    PyObject py = __self__.InvokeMethod("items");
                    PyObject keys=py.InvokeMethod("keys");
                    foreach (PyObject key in keys)
                        yield return (key.As<string>(), new Module(py.GetItem(key)));
                }
                
                /// <summary>
                /// Return an iterable of the ModuleDict keys.
                /// </summary>
                public IEnumerable<string> keys()
                {
                    var __self__=self;
                    dynamic py = __self__.InvokeMethod("keys");
                    return py.As<string[]>();
                }
                
                /// <summary>
                /// Remove key from the ModuleDict and return its module.
                /// </summary>
                public Module pop(string key)
                {
                    var __self__=self;
                    var pyargs=ToTuple(new object[]
                    {
                        key,
                    });
                    var kwargs=new PyDict();
                    dynamic py = __self__.InvokeMethod("pop", pyargs, kwargs);
                    return new Module(py as PyObject);
                }
                
                /// <summary>
                /// Update the ModuleDict with the key-value pairs from a
                /// mapping or an iterable, overwriting existing keys.
                /// 
                /// Note
                /// If modules is an OrderedDict, a ModuleDict, or
                /// an iterable of key-value pairs, the order of new elements in it is preserved.
                /// </summary>
                public void update(params (string, Module)[] modules)
                {
                    var __self__=self;
                    var pyargs=ToTuple(new object[]
                    {
                        modules.Select(pair=>new PyTuple(new []
                        {
                            new PyString(pair.Item1), 
                            pair.Item2.PyObject as PyObject, 
                        })),
                    });

                    dynamic py = __self__.InvokeMethod("update", pyargs);
                }
                
                /// <summary>
                /// Return an iterable of the ModuleDict values.
                /// </summary>
                public IEnumerable<Module> values()
                {
                    //auto-generated code, do not change
                    var __self__=self;
                    PyObject py = __self__.InvokeMethod("values");
                    var len = py.Length();
                    var modules = new Module[len];
                    for (int i = 0; i < len; i++)
                        modules[i] = new Module(py.GetItem(i));
                    return modules;
                }

                public IEnumerator<(string, Module)> GetEnumerator()
                {
                    return items().GetEnumerator();
                }

                IEnumerator IEnumerable.GetEnumerator()
                {
                    return GetEnumerator();
                }

                public T Get<T>(string key) where T : Module, new()
                {
                    return new T(self.GetItem(key) as PyObject);
                }
            }
        }
    }
    
}
