using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunTimePolymorphism.ExceptionHandling
{
    public class Business
    {
        public void RegisterBusiness()
        {
            try
            {

            }
            catch (DivideByZeroException ds)
            {
                throw;
            }
            catch (InvalidCastException d)
            {

            }
            catch (Exception ex)
            {

            }
        }
    }

    public class TestException : NullReferenceException
    {

    }
}
