﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Numpy.Models;
using NUnit.Framework;
using Python.Runtime;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Torch.nn
{
    [TestClass]
    public class NN_tests : BaseTestCase
    {
        [TestMethod]
        public void Parameter()
        {
            var Parameter = PyTorch.Instance.self.GetAttr("nn").GetAttr("Parameter");
            Console.WriteLine(Parameter.ToString());
            var x = torch.tensor(new double[] { 1, 2, 3 });
            var p = Parameter(x.PyObject, requires_grad: false);
            var p1 = (PyTorch.Instance.self.GetAttr("nn") as PyObject).InvokeMethod("Parameter", new PyTuple(new PyObject[] { x.PyObject }), Py.kw("requires_grad", new PyObject(Runtime.PyTrue)));
            Console.WriteLine(p.ToString());
            Console.WriteLine(p1.ToString());
            // 
            var p2 = new torch.nn.Parameter(x, true);
            Assert.AreEqual(p1.ToString(), p2.ToString());
        }

        [TestMethod]
        public void ModuleDict()
        {
            var a = new torch.nn.Conv1d(2, 2, new[] {5});
            var b = new torch.nn.Conv1d(1, 1, new[] {3});
            var dict = new torch.nn.ModuleDict(
                ("a", a),
                ("b", b)
            );
            var a1=dict.Get<torch.nn.Conv1d>("a");
            Assert.AreEqual(a, a1);
        }
    }
}
