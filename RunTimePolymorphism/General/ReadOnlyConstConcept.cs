using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism.General
{
    /// <summary>
    /// https://stackoverflow.com/questions/55984/what-is-the-difference-between-const-and-readonly-in-c
    /// </summary>
    class ReadOnlyConstConcept
    {
        /// <summary>
        /// 'const's are implicitly static. You use a ClassName.ConstantName notation to access them.
        /// </summary>
        public const int IamaConst = 4;

        public readonly string IamReadOnly="k";

        public ReadOnlyConstConcept ()
	    {
            //IamaConst =5; Not allowed

            IamReadOnly = "Readme";
	    }

        public void IsReadOnlyVariableAssignableInMethod()
        {
            //IamReadOnly = "ReadmeAgain"; Not allowed

            // Readonly var should be defined before code leaves the constructor
        }
    }
}
