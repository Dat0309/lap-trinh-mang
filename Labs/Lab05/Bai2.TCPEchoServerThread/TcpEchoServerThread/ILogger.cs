﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcpEchoServerThread
{
    public interface ILogger
    {
        public void Write(ArrayList entry);
        public void Write(string entry);
    }
}
