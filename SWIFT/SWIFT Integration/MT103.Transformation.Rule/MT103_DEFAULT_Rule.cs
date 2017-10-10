using System;
using System.ComponentModel.Composition;
using Swift.AltaSoftware.Wrapper.Swift;
using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_DEFAULT;
using Swift.Transformation.Common;
using Swift.Transformation.Rules.Contracts.MT103;

namespace MT103.Transformation.Rule
{
    [Export(typeof(ITransformationRule))]
    [RuleInfo(ImplementationKey: "key-1", Name: "TBCBGE22AXXX")]
    public class MT103_DEFAULT_RuleImpl : MT103_DEFAULT_Rule
    {
        public MT103_DEFAULT_RuleImpl() : base((asSwiftMessage) =>
        {

            return new B6MT103
            {
                AMOUNT = 100.00m,
                DOC_DATE_IN_DOC = DateTime.Now,
                EXTRA_INFO_DESCRIP = false,
                FLAGS = 127,
                ISO = String.Empty,
                IS_AUTHORIZED = false,
                IS_FINALYZED = false,
                IS_MODIFIED = false,
                IS_READY = false,
                PORTION = 127,
                PORTION_DATE = DateTime.Now,
                RECEIVER_ACC = String.Empty,
                RECEIVER_BANK_CODE = String.Empty,
                REF_NUM = String.Empty,
                ROW_ID = 127,
                SENDER_ACC = String.Empty,
                SENDER_BANK_CODE = String.Empty,
                STATE = 127,
                SWIFT_FILENAME = String.Empty,
                SWIFT_FILE_ROW_ID = Int32.MaxValue,
                UID = 127
            };
        }){}
    }

    [Export(typeof(ITransformationRule))]
    [RuleInfo(ImplementationKey: "key-2", Name: "TBCBGE22AXXX")]
    public class MT103_DEFAULT_RuleImpl2 : MT103_DEFAULT_Rule
    {
        public MT103_DEFAULT_RuleImpl2() : base((asSwiftMessage) =>
        {

            return new B6MT103
            {
                AMOUNT = 200.00m,
                DOC_DATE_IN_DOC = DateTime.Now,
                EXTRA_INFO_DESCRIP = false,
                FLAGS = 127,
                ISO = String.Empty,
                IS_AUTHORIZED = false,
                IS_FINALYZED = false,
                IS_MODIFIED = false,
                IS_READY = false,
                PORTION = 127,
                PORTION_DATE = DateTime.Now,
                RECEIVER_ACC = String.Empty,
                RECEIVER_BANK_CODE = String.Empty,
                REF_NUM = String.Empty,
                ROW_ID = 127,
                SENDER_ACC = String.Empty,
                SENDER_BANK_CODE = String.Empty,
                STATE = 127,
                SWIFT_FILENAME = String.Empty,
                SWIFT_FILE_ROW_ID = Int32.MaxValue,
                UID = 127
            };
        })
        { }
    }
}
