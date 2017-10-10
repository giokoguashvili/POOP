using System.Collections.Generic;
using SWIFTFramework.Validation;

namespace Swift.AltaSoftware.Wrapper.Swift.MT
{
    public interface IValidationRules
    {
        IEnumerable<IValidate> Block1Rules();
        IEnumerable<IValidate> Block2Rules();
        IEnumerable<IValidate> Block3Rules();
        IEnumerable<IValidate> Block4Rules();
        IEnumerable<IValidate> Block5Rules();

    }
}