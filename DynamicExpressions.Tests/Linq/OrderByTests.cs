﻿using DynamicExpressions.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicExpressions.Tests.Linq
{
    [TestClass]
    public class OrderByTests : LinqTestBase
    {
        [TestMethod]
        public void WithDescriptors()
        {
            var sorted = mockData.OrderBy("SubProperty.IsOdd").ToList();
            Assert.AreEqual(false, sorted[0].SubProperty.IsOdd);

            sorted = mockData.OrderBy("SubProperty.IsOdd asc").ToList();
            Assert.AreEqual(false, sorted[0].SubProperty.IsOdd);

            sorted = mockData.OrderBy("SubProperty.IsOdd desc").ToList();
            Assert.AreEqual(true, sorted[0].SubProperty.IsOdd);
        }

        [TestMethod]
        public void ThenByInline()
        {
            var sorted = mockData.OrderBy("SubProperty.IsOdd, Counter desc").ToList();

            Assert.AreEqual(8, sorted[0].Counter);
        }
        
        [TestMethod]
        public void Expression()
        {
            var sorted = mockData.OrderBy("ComplexProperty.Where(Index % 10 == 3).OrderBy(Level).ThenBy(Index).Select(Index).FirstOrDefault()").ToList();
            Assert.AreEqual('J', sorted[0].Letter);

            sorted = mockData.OrderBy("ComplexProperty.Where(Index % 10 == 3).OrderByDescending(Level).ThenByDescending(Index).Select(Index).FirstOrDefault()").ToList();
            Assert.AreEqual('J', sorted[0].Letter);
        }
    }
}
