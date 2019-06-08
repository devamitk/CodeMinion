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
using Python.Included;

namespace Torch
{
    public partial class PyTorch : IDisposable
    {
        
        private PyObject _pyobj = null;
        public static PyTorch Instance => _instance.Value;
        
        private static Lazy<PyTorch> _instance = new Lazy<PyTorch>(() => 
        {
            var instance=new PyTorch();
            try
            {
                instance._pyobj = InstallAndImport();
            }
            catch (Exception)
            {
                // retry to fix the installation by forcing a repair.
                instance._pyobj = InstallAndImport(force: true);
            }
            return instance;
        }
        );
        
        private static PyObject InstallAndImport(bool force = false)
        {
            //var installer = new Installer();
            //installer.SetupPython(force).Wait();
            PythonEngine.Initialize();
            var mod = Py.Import("torch");
            return mod;
        }
        
        public dynamic self => _pyobj;
        private bool IsInitialized => _pyobj != null;
        
        private PyTorch() { }
        
        public void Dispose()
        {
            self?.Dispose();
        }
        
        
        //auto-generated
        protected PyTuple ToTuple(Array input)
        {
            var array = new PyObject[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                array[i]=ToPython(input.GetValue(i));
            }
            return new PyTuple(array);
        }
        
        //auto-generated
        protected PyObject ToPython(object obj)
        {
            if (obj == null) return Runtime.GetPyNone();
            switch (obj)
            {
                // basic types
                case int o: return new PyInt(o);
                case float o: return new PyFloat(o);
                case double o: return new PyFloat(o);
                case string o: return new PyString(o);
                case PyObject o: return o;
                // sequence types
                case Array o: return ToTuple(o);
                // special types from 'ToPythonConversions'
                case Shape o: return ToTuple(o.Dimensions);
                case Tensor o: return o.PyObject;
                case Dtype o: return o.PyObject;
                case NDarray o: return o.PyObject;
                default: throw new NotImplementedException($"Type is not yet supported: { obj.GetType().Name}. Add it to 'ToPythonConversions'");
            }
        }
        
        //auto-generated
        protected T ToCsharp<T>(dynamic pyobj)
        {
            switch (typeof(T).Name)
            {
                // types from 'ToCsharpConversions'
                case "Tensor": return (T)(object)new Tensor(pyobj);
                default: return (T)pyobj;
            }
        }
        
        //auto-generated
        protected T SharpToSharp<T>(object obj)
        {
            if (obj == null) return default(T);
            switch (obj)
            {
                // from 'SharpToSharpConversions':
            }
            throw new NotImplementedException($"Type is not yet supported: { obj.GetType().Name}. Add it to 'SharpToSharpConversions'");
        }
    }
}
