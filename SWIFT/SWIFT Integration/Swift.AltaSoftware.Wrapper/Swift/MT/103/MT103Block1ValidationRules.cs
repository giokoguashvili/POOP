using System.Collections;
using System.Collections.Generic;
using SWIFTFramework.Validation;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103
{
    public class MT103Block1ValidationRules : IEnumerable<IValidate>
    {
        public IEnumerator<IValidate> GetEnumerator()
        {
           return new List<IValidate>
           {
               new Tag20Validator()
           }.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}