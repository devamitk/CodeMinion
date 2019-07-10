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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace Torch.UnitTest
{
    [TestClass]
    public class PyTorch_nn_functionalTest : BaseTestCase
    {
        
        [TestMethod]
        public void conv1dTest()
        {
            // >>> filters = torch.randn(33, 16, 3)
            // >>> inputs = torch.randn(20, 16, 50)
            // >>> F.conv1d(inputs, filters)
            // 
            
            #if TODO
            var given=  filters = torch.randn(33, 16, 3);
             given=  inputs = torch.randn(20, 16, 50);
             given=  F.conv1d(inputs, filters);
            #endif
        }
        
        
        [TestMethod]
        public void conv2dTest()
        {
            // >>> # With square kernels and equal stride
            // >>> filters = torch.randn(8,4,3,3)
            // >>> inputs = torch.randn(1,4,5,5)
            // >>> F.conv2d(inputs, filters, padding=1)
            // 
            
            #if TODO
            var given=  # With square kernels and equal stride;
             given=  filters = torch.randn(8,4,3,3);
             given=  inputs = torch.randn(1,4,5,5);
             given=  F.conv2d(inputs, filters, padding=1);
            #endif
        }
        
        
        [TestMethod]
        public void conv3dTest()
        {
            // >>> filters = torch.randn(33, 16, 3, 3, 3)
            // >>> inputs = torch.randn(20, 16, 50, 10, 20)
            // >>> F.conv3d(inputs, filters)
            // 
            
            #if TODO
            var given=  filters = torch.randn(33, 16, 3, 3, 3);
             given=  inputs = torch.randn(20, 16, 50, 10, 20);
             given=  F.conv3d(inputs, filters);
            #endif
        }
        
        
        [TestMethod]
        public void conv_transpose1dTest()
        {
            // >>> inputs = torch.randn(20, 16, 50)
            // >>> weights = torch.randn(16, 33, 5)
            // >>> F.conv_transpose1d(inputs, weights)
            // 
            
            #if TODO
            var given=  inputs = torch.randn(20, 16, 50);
             given=  weights = torch.randn(16, 33, 5);
             given=  F.conv_transpose1d(inputs, weights);
            #endif
        }
        
        
        [TestMethod]
        public void conv_transpose2dTest()
        {
            // >>> # With square kernels and equal stride
            // >>> inputs = torch.randn(1, 4, 5, 5)
            // >>> weights = torch.randn(4, 8, 3, 3)
            // >>> F.conv_transpose2d(inputs, weights, padding=1)
            // 
            
            #if TODO
            var given=  # With square kernels and equal stride;
             given=  inputs = torch.randn(1, 4, 5, 5);
             given=  weights = torch.randn(4, 8, 3, 3);
             given=  F.conv_transpose2d(inputs, weights, padding=1);
            #endif
        }
        
        
        [TestMethod]
        public void conv_transpose3dTest()
        {
            // >>> inputs = torch.randn(20, 16, 50, 10, 20)
            // >>> weights = torch.randn(16, 33, 3, 3, 3)
            // >>> F.conv_transpose3d(inputs, weights)
            // 
            
            #if TODO
            var given=  inputs = torch.randn(20, 16, 50, 10, 20);
             given=  weights = torch.randn(16, 33, 3, 3, 3);
             given=  F.conv_transpose3d(inputs, weights);
            #endif
        }
        
        
        [TestMethod]
        public void avg_pool1dTest()
        {
            // >>> # pool of square window of size=3, stride=2
            // >>> input = torch.tensor([[[1, 2, 3, 4, 5, 6, 7]]], dtype=torch.float32)
            // >>> F.avg_pool1d(input, kernel_size=3, stride=2)
            // tensor([[[ 2.,  4.,  6.]]])
            // 
            
            #if TODO
            var given=  # pool of square window of size=3, stride=2;
             given=  input = torch.tensor({{{1, 2, 3, 4, 5, 6, 7}}}, dtype=torch.float32);
             given=  F.avg_pool1d(input, kernel_size=3, stride=2);
            var expected=
                "tensor([[[ 2.,  4.,  6.]]])";
            Assert.AreEqual(expected, given.repr);
            #endif
        }
        
        
        [TestMethod]
        public void gumbel_softmaxTest()
        {
            // >>> logits = torch.randn(20, 32)
            // >>> # Sample soft categorical using reparametrization trick:
            // >>> F.gumbel_softmax(logits, tau=1, hard=False)
            // >>> # Sample hard categorical using "Straight-through" trick:
            // >>> F.gumbel_softmax(logits, tau=1, hard=True)
            // 
            
            #if TODO
            var given=  logits = torch.randn(20, 32);
             given=  # Sample soft categorical using reparametrization trick:;
             given=  F.gumbel_softmax(logits, tau=1, hard=False);
             given=  # Sample hard categorical using "Straight-through" trick:;
             given=  F.gumbel_softmax(logits, tau=1, hard=True);
            #endif
        }
        
        
        [TestMethod]
        public void embeddingTest()
        {
            // >>> # a batch of 2 samples of 4 indices each
            // >>> input = torch.tensor([[1,2,4,5],[4,3,2,9]])
            // >>> # an embedding matrix containing 10 tensors of size 3
            // >>> embedding_matrix = torch.rand(10, 3)
            // >>> F.embedding(input, embedding_matrix)
            // tensor([[[ 0.8490,  0.9625,  0.6753],
            //          [ 0.9666,  0.7761,  0.6108],
            //          [ 0.6246,  0.9751,  0.3618],
            //          [ 0.4161,  0.2419,  0.7383]],
            // 
            //         [[ 0.6246,  0.9751,  0.3618],
            //          [ 0.0237,  0.7794,  0.0528],
            //          [ 0.9666,  0.7761,  0.6108],
            //          [ 0.3385,  0.8612,  0.1867]]])
            // 
            // >>> # example with padding_idx
            // >>> weights = torch.rand(10, 3)
            // >>> weights[0, :].zero_()
            // >>> embedding_matrix = weights
            // >>> input = torch.tensor([[0,2,0,5]])
            // >>> F.embedding(input, embedding_matrix, padding_idx=0)
            // tensor([[[ 0.0000,  0.0000,  0.0000],
            //          [ 0.5609,  0.5384,  0.8720],
            //          [ 0.0000,  0.0000,  0.0000],
            //          [ 0.6262,  0.2438,  0.7471]]])
            // 
            
            #if TODO
            var given=  # a batch of 2 samples of 4 indices each;
             given=  input = torch.tensor({{1,2,4,5},{4,3,2,9}});
             given=  # an embedding matrix containing 10 tensors of size 3;
             given=  embedding_matrix = torch.rand(10, 3);
             given=  F.embedding(input, embedding_matrix);
            var expected=
                "tensor([[[ 0.8490,  0.9625,  0.6753],\n" +
                "         [ 0.9666,  0.7761,  0.6108],\n" +
                "         [ 0.6246,  0.9751,  0.3618],\n" +
                "         [ 0.4161,  0.2419,  0.7383]],\n" +
                "\n" +
                "        [[ 0.6246,  0.9751,  0.3618],\n" +
                "         [ 0.0237,  0.7794,  0.0528],\n" +
                "         [ 0.9666,  0.7761,  0.6108],\n" +
                "         [ 0.3385,  0.8612,  0.1867]]])\n" +
                "";
            Assert.AreEqual(expected, given.repr);
             given=  # example with padding_idx;
             given=  weights = torch.rand(10, 3);
             given=  weights[0, :].zero_();
             given=  embedding_matrix = weights;
             given=  input = torch.tensor({{0,2,0,5}});
             given=  F.embedding(input, embedding_matrix, padding_idx=0);
             expected=
                "tensor([[[ 0.0000,  0.0000,  0.0000],\n" +
                "         [ 0.5609,  0.5384,  0.8720],\n" +
                "         [ 0.0000,  0.0000,  0.0000],\n" +
                "         [ 0.6262,  0.2438,  0.7471]]])";
            Assert.AreEqual(expected, given.repr);
            #endif
        }
        
        
        [TestMethod]
        public void embedding_bagTest()
        {
            // >>> # an Embedding module containing 10 tensors of size 3
            // >>> embedding_matrix = torch.rand(10, 3)
            // >>> # a batch of 2 samples of 4 indices each
            // >>> input = torch.tensor([1,2,4,5,4,3,2,9])
            // >>> offsets = torch.tensor([0,4])
            // >>> F.embedding_bag(embedding_matrix, input, offsets)
            // tensor([[ 0.3397,  0.3552,  0.5545],
            //         [ 0.5893,  0.4386,  0.5882]])
            // 
            
            #if TODO
            var given=  # an Embedding module containing 10 tensors of size 3;
             given=  embedding_matrix = torch.rand(10, 3);
             given=  # a batch of 2 samples of 4 indices each;
             given=  input = torch.tensor({1,2,4,5,4,3,2,9});
             given=  offsets = torch.tensor({0,4});
             given=  F.embedding_bag(embedding_matrix, input, offsets);
            var expected=
                "tensor([[ 0.3397,  0.3552,  0.5545],\n" +
                "        [ 0.5893,  0.4386,  0.5882]])";
            Assert.AreEqual(expected, given.repr);
            #endif
        }
        
        
        [TestMethod]
        public void one_hotTest()
        {
            // >>> F.one_hot(torch.arange(0, 5) % 3)
            // tensor([[1, 0, 0],
            //         [0, 1, 0],
            //         [0, 0, 1],
            //         [1, 0, 0],
            //         [0, 1, 0]])
            // >>> F.one_hot(torch.arange(0, 5) % 3, num_classes=5)
            // tensor([[1, 0, 0, 0, 0],
            //         [0, 1, 0, 0, 0],
            //         [0, 0, 1, 0, 0],
            //         [1, 0, 0, 0, 0],
            //         [0, 1, 0, 0, 0]])
            // >>> F.one_hot(torch.arange(0, 6).view(3,2) % 3)
            // tensor([[[1, 0, 0],
            //          [0, 1, 0]],
            //         [[0, 0, 1],
            //          [1, 0, 0]],
            //         [[0, 1, 0],
            //          [0, 0, 1]]])
            // 
            
            #if TODO
            var given=  F.one_hot(torch.arange(0, 5) % 3);
            var expected=
                "tensor([[1, 0, 0],\n" +
                "        [0, 1, 0],\n" +
                "        [0, 0, 1],\n" +
                "        [1, 0, 0],\n" +
                "        [0, 1, 0]])";
            Assert.AreEqual(expected, given.repr);
             given=  F.one_hot(torch.arange(0, 5) % 3, num_classes=5);
             expected=
                "tensor([[1, 0, 0, 0, 0],\n" +
                "        [0, 1, 0, 0, 0],\n" +
                "        [0, 0, 1, 0, 0],\n" +
                "        [1, 0, 0, 0, 0],\n" +
                "        [0, 1, 0, 0, 0]])";
            Assert.AreEqual(expected, given.repr);
             given=  F.one_hot(torch.arange(0, 6).view(3,2) % 3);
             expected=
                "tensor([[[1, 0, 0],\n" +
                "         [0, 1, 0]],\n" +
                "        [[0, 0, 1],\n" +
                "         [1, 0, 0]],\n" +
                "        [[0, 1, 0],\n" +
                "         [0, 0, 1]]])";
            Assert.AreEqual(expected, given.repr);
            #endif
        }
        
        
        [TestMethod]
        public void cosine_similarityTest()
        {
            // >>> input1 = torch.randn(100, 128)
            // >>> input2 = torch.randn(100, 128)
            // >>> output = F.cosine_similarity(input1, input2)
            // >>> print(output)
            // 
            
            #if TODO
            var given=  input1 = torch.randn(100, 128);
             given=  input2 = torch.randn(100, 128);
             given=  output = F.cosine_similarity(input1, input2);
             given=  print(output);
            #endif
        }
        
        
        [TestMethod]
        public void binary_cross_entropyTest()
        {
            // >>> input = torch.randn((3, 2), requires_grad=True)
            // >>> target = torch.rand((3, 2), requires_grad=False)
            // >>> loss = F.binary_cross_entropy(F.sigmoid(input), target)
            // >>> loss.backward()
            // 
            
            #if TODO
            var given=  input = torch.randn((3, 2), requires_grad=True);
             given=  target = torch.rand((3, 2), requires_grad=False);
             given=  loss = F.binary_cross_entropy(F.sigmoid(input), target);
             given=  loss.backward();
            #endif
        }
        
        
        [TestMethod]
        public void binary_cross_entropy_with_logitsTest()
        {
            // >>> input = torch.randn(3, requires_grad=True)
            // >>> target = torch.empty(3).random_(2)
            // >>> loss = F.binary_cross_entropy_with_logits(input, target)
            // >>> loss.backward()
            // 
            
            #if TODO
            var given=  input = torch.randn(3, requires_grad=True);
             given=  target = torch.empty(3).random_(2);
             given=  loss = F.binary_cross_entropy_with_logits(input, target);
             given=  loss.backward();
            #endif
        }
        
        
        [TestMethod]
        public void cross_entropyTest()
        {
            // >>> input = torch.randn(3, 5, requires_grad=True)
            // >>> target = torch.randint(5, (3,), dtype=torch.int64)
            // >>> loss = F.cross_entropy(input, target)
            // >>> loss.backward()
            // 
            
            #if TODO
            var given=  input = torch.randn(3, 5, requires_grad=True);
             given=  target = torch.randint(5, (3,), dtype=torch.int64);
             given=  loss = F.cross_entropy(input, target);
             given=  loss.backward();
            #endif
        }
        
        
        [TestMethod]
        public void ctc_lossTest()
        {
            // >>> log_probs = torch.randn(50, 16, 20).log_softmax(2).detach().requires_grad_()
            // >>> targets = torch.randint(1, 20, (16, 30), dtype=torch.long)
            // >>> input_lengths = torch.full((16,), 50, dtype=torch.long)
            // >>> target_lengths = torch.randint(10,30,(16,), dtype=torch.long)
            // >>> loss = F.ctc_loss(log_probs, targets, input_lengths, target_lengths)
            // >>> loss.backward()
            // 
            
            #if TODO
            var given=  log_probs = torch.randn(50, 16, 20).log_softmax(2).detach().requires_grad_();
             given=  targets = torch.randint(1, 20, (16, 30), dtype=torch.long);
             given=  input_lengths = torch.full((16,), 50, dtype=torch.long);
             given=  target_lengths = torch.randint(10,30,(16,), dtype=torch.long);
             given=  loss = F.ctc_loss(log_probs, targets, input_lengths, target_lengths);
             given=  loss.backward();
            #endif
        }
        
        
        [TestMethod]
        public void nll_lossTest()
        {
            // >>> # input is of size N x C = 3 x 5
            // >>> input = torch.randn(3, 5, requires_grad=True)
            // >>> # each element in target has to have 0 <= value < C
            // >>> target = torch.tensor([1, 0, 4])
            // >>> output = F.nll_loss(F.log_softmax(input), target)
            // >>> output.backward()
            // 
            
            #if TODO
            var given=  # input is of size N x C = 3 x 5;
             given=  input = torch.randn(3, 5, requires_grad=True);
             given=  # each element in target has to have 0 <= value < C;
             given=  target = torch.tensor({1, 0, 4});
             given=  output = F.nll_loss(F.log_softmax(input), target);
             given=  output.backward();
            #endif
        }
        
        
        [TestMethod]
        public void pixel_shuffleTest()
        {
            // >>> input = torch.randn(1, 9, 4, 4)
            // >>> output = torch.nn.functional.pixel_shuffle(input, 3)
            // >>> print(output.size())
            // torch.Size([1, 1, 12, 12])
            // 
            
            #if TODO
            var given=  input = torch.randn(1, 9, 4, 4);
             given=  output = torch.nn.functional.pixel_shuffle(input, 3);
             given=  print(output.size());
            var expected=
                "torch.Size([1, 1, 12, 12])";
            Assert.AreEqual(expected, given.repr);
            #endif
        }
        
        
        [TestMethod]
        public void padTest()
        {
            // >>> t4d = torch.empty(3, 3, 4, 2)
            // >>> p1d = (1, 1) # pad last dim by 1 on each side
            // >>> out = F.pad(t4d, p1d, "constant", 0)  # effectively zero padding
            // >>> print(out.data.size())
            // torch.Size([3, 3, 4, 4])
            // >>> p2d = (1, 1, 2, 2) # pad last dim by (1, 1) and 2nd to last by (2, 2)
            // >>> out = F.pad(t4d, p2d, "constant", 0)
            // >>> print(out.data.size())
            // torch.Size([3, 3, 8, 4])
            // >>> t4d = torch.empty(3, 3, 4, 2)
            // >>> p3d = (0, 1, 2, 1, 3, 3) # pad by (0, 1), (2, 1), and (3, 3)
            // >>> out = F.pad(t4d, p3d, "constant", 0)
            // >>> print(out.data.size())
            // torch.Size([3, 9, 7, 3])
            // 
            
            #if TODO
            var given=  t4d = torch.empty(3, 3, 4, 2);
             given=  p1d = (1, 1) # pad last dim by 1 on each side;
             given=  out = F.pad(t4d, p1d, "constant", 0)  # effectively zero padding;
             given=  print(out.data.size());
            var expected=
                "torch.Size([3, 3, 4, 4])";
            Assert.AreEqual(expected, given.repr);
             given=  p2d = (1, 1, 2, 2) # pad last dim by (1, 1) and 2nd to last by (2, 2);
             given=  out = F.pad(t4d, p2d, "constant", 0);
             given=  print(out.data.size());
             expected=
                "torch.Size([3, 3, 8, 4])";
            Assert.AreEqual(expected, given.repr);
             given=  t4d = torch.empty(3, 3, 4, 2);
             given=  p3d = (0, 1, 2, 1, 3, 3) # pad by (0, 1), (2, 1), and (3, 3);
             given=  out = F.pad(t4d, p3d, "constant", 0);
             given=  print(out.data.size());
             expected=
                "torch.Size([3, 9, 7, 3])";
            Assert.AreEqual(expected, given.repr);
            #endif
        }
        
    }
}