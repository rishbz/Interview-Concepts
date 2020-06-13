using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism.InterviewPrograms
{
    class ImmutableClass
    {
        private readonly int _immutableProperty=3;

        public ImmutableClass()
        {
            _immutableProperty = 1;
        }

        public int ImmutableProperty
        {
            get
            {
                return _immutableProperty;
            }
        }
    }
}
