﻿using System;
using System.Collections.Generic;
using System.Text;

namespace События
{
    class Class3
    {
        static void Main(string[] args)
        {
            ClassCounter Counter = new ClassCounter();
            Handler_I Handler1 = new Handler_I();
            Handler_II Handler2 = new Handler_II();

            Counter.onCount += Handler1.Message;
            Counter.onCount += Handler2.Message;

            Counter.Count();
        }
    }
}
