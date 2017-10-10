using System.Collections.Generic;
using SWIFTFramework.Validation;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103
{
    public class MT103ValidationRules : IValidationRules
    {
        private readonly IEnumerable<IValidate> _block1ValidationRules = new List<IValidate>
        {
   
        };

        private readonly IEnumerable<IValidate> _block2ValidationRules = new List<IValidate>
        {
    
        };

        private readonly IEnumerable<IValidate> _block3ValidationRules = new List<IValidate>
        {
    
        };

        private readonly IEnumerable<IValidate> _block4ValidationRules = new List<IValidate>
        {
            new Tag20Validator()
        };

        private readonly IEnumerable<IValidate> _block5ValidationRules = new List<IValidate>
        {
      
        };

        public IEnumerable<IValidate> Block1Rules()
        {
            return _block1ValidationRules;
        }

        public IEnumerable<IValidate> Block2Rules()
        {
            return _block2ValidationRules;
        }

        public IEnumerable<IValidate> Block3Rules()
        {
            return _block3ValidationRules;
        }

        public IEnumerable<IValidate> Block4Rules()
        {
            return _block4ValidationRules;
        }

        public IEnumerable<IValidate> Block5Rules()
        {
            return _block5ValidationRules;
        }
    }
}