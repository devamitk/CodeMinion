﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Regen.Compiler;

namespace Regen.Core.Tests {
    [TestClass]
    public class CommentTests : UnitTestBase {
        [TestMethod]
        public void comment_at_foreach() {
            var @input = @"

                %foreach range(3,3)% #//this should be gone
                    Console.WriteLine(""Printed #1!"");
                %
                ";

            Interpert(input)
                .Should()
                .NotContain("#//this should be gone");
        }        
        [TestMethod]
        public void comment_after_foreach() {
            var @input = @"
                %foreach range(3,3)% 
                    Console.WriteLine(""Printed #1!"");
                % #//this should be gone
                ";

            Interpert(input)
                .Should()
                .NotContain("#//this should be gone");
        }            [TestMethod]
        public void comment_swallows_entire_line() {
            var @input = @"
                #//%foreach range(3,3)% 
                    Console.WriteLine(""Printed #1!"");
                #//this should be gone % #//this should be gone
                ";

            Interpert(input)
                .Should()
                .NotContain("#//this should be gone").And
                .NotContain("foreach");
        }        
        
        [TestMethod]
        public void comment_alone() {
            var @input = @"
                #//this should be gone
                ";

            Interpert(input)
                .Should()
                .NotContain("#//this should be gone");
        }
    }
}