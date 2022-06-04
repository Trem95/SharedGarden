﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Application.Common.Exceptions
{
    public class NotFoundException : System.Exception
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message) { }
        public NotFoundException(string message, System.Exception innerException) { }
        public NotFoundException(string name, object key):base($"Entity\"{name}\" ({key} was not found)") {}
    }
}
