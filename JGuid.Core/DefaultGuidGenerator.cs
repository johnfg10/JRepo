using System;
using System.Collections.Generic;
using System.Text;

namespace JGuid.Core
{
    public class DefaultGuidGenerator : IGuidGenerator
    {
        public Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }
    }
}
