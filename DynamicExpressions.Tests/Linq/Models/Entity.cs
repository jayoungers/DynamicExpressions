﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicExpressions.Tests.Linq.Models
{
    public class Entity
    {
        public static List<Entity> GetList()
        {
            var list = new List<Entity>();

            for (var i = 0; i < 10; i++)
            {
                list.Add(new Entity
                {
                    Counter = i,
                    Letter = (char)(i + 'A'),
                    SubProperty = new ChildEntity { IsOdd = (i % 2 == 1) },
                    ComplexProperty = new List<ComplexChildEntity>()
                    {
                        new ComplexChildEntity { Index = ((10 - i) * 10) + 1, Level = 1, Value = "Z", SubChildren = new List<int> { i } },
                        new ComplexChildEntity { Index = ((10 - i) * 10) + 2, Level = 1, Value = "Y", SubChildren = new List<int> { i } },
                        new ComplexChildEntity { Index = ((10 - i) * 10) + 3, Level = 1, Value = "X", SubChildren = new List<int> { i } }
                    }
                });
            }

            return list;
        }

        public int Counter { get; set; }
        public char Letter { get; set; }
        public char? NullableLetter { get; set; }
        public ChildEntity SubProperty { get; set; }
        public List<ComplexChildEntity> ComplexProperty { get; set; }
    }
}
