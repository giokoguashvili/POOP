using System.Linq;
using Swift.AltaSoftware.Wrapper.Swift.Common;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_REMIT.Tags._77T;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._51A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._52a;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._54a;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._55a;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._56a;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT._57a;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._13C;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._20;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._23B;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._23E;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._26T;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._32A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._33B;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._36;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._50a;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._53a;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._59a;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._71A;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._71F;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._71G;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._72;
using Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._77B;
using Swift.Infrastructure.Infrastructure;
using SWIFTFramework;
using SWIFTFramework.Messages.Category1;

namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.SingleCustomerCreditTransfer_REMIT
{
    public class AsMT103_REMIT : IAsSwiftMessage<AsMT103_REMIT>
    {
        private readonly SwiftMessage _swiftMessage;

        public AsMT103_REMIT(SwiftMessage swiftMessage)
        {
            _swiftMessage = swiftMessage;
            var mt103RemitMessage = new MT103REMIT(_swiftMessage);

            SenderReference_20 = new SenderReference_20(mt103RemitMessage.SendersReference_20.Value);
            TimeIndication_13C = mt103RemitMessage.TimeIndication_13C.Select(t => new TimeIndication_13C(t.Value)).ToArray();
            BankOperationCode_23B = new BankOperationCode_23B(mt103RemitMessage.BankOperationCode_23B.Value);
            InstructionCode_23E = mt103RemitMessage
                                    .InstructionCode_23E
                                    .Select(t => new InstructionCode_23E(t.Value))
                                    .ToArray();
            TransactionTypeCode_26T = new NullIfEmpty<TransactionTypeCode_26T>(
                                            mt103RemitMessage.TransactionTypeCode_26T.Value,
                                            t => new TransactionTypeCode_26T(t)
                                        ).Value();
            ValueDateCurrencyInterbankSettledAmount_32A = new ValueDateCurrencyInterbankSettledAmount_32A(
                                                                mt103RemitMessage.ValueDateCurrencyInterbankSettledAmount_32A.Value
                                                           );
            CurrencyInstructedAmount_33B = new NullIfEmpty<CurrencyInstructedAmount_33B>(
                                                mt103RemitMessage.CurrencyInstructedAmount_33B.Value,
                                                t => new CurrencyInstructedAmount_33B(t)
                                            ).Value();
            ExchangeRate_36 = new NullIfEmpty<ExchangeRate_36>(
                                    mt103RemitMessage.ExchangeRate_36.Value,
                                    t => new ExchangeRate_36(t)
                                ).Value();
            OrderingCustomer_50a = new NullIfEmpty<OrderingCustomer_50a>(
                                        () => new OrderingCustomer_50a(
                                                mt103RemitMessage.Tag50A_OrderingCustomer.Value,
                                                mt103RemitMessage.Tag50F_OrderingCustomer.Value,
                                                mt103RemitMessage.Tag50K_OrderingCustomer.Value
                                              ),
                                        mt103RemitMessage.Tag50A_OrderingCustomer.Value,
                                        mt103RemitMessage.Tag50F_OrderingCustomer.Value,
                                        mt103RemitMessage.Tag50K_OrderingCustomer.Value
                                    ).Value();
            SendingInstitution_51A = new NullIfEmpty<SendingInstitution_51A>(
                                            mt103RemitMessage.SendingInstitution_51A.Value,
                                            t => new SendingInstitution_51A(t)
                                    ).Value();

            OrderingInstitution_52a = new NullIfEmpty<OrderingInstitution_52a>(
                                           () => new OrderingInstitution_52a(
                                                    mt103RemitMessage.Tag52A_OrderingInstitution.Value,
                                                    mt103RemitMessage.Tag52D_OrderingInstitution.Value
                                                  ),
                                            mt103RemitMessage.Tag52A_OrderingInstitution.Value,
                                            mt103RemitMessage.Tag52D_OrderingInstitution.Value
                                        ).Value();
            SendersCorrespondent_53a = new NullIfEmpty<SendersCorrespondent_53a>(
                                               () => new SendersCorrespondent_53a(
                                                           mt103RemitMessage.SendersCorrespondent_53A.Value,
                                                           mt103RemitMessage.SendersCorrespondent_53B.Value,
                                                           mt103RemitMessage.SendersCorrespondent_53D.Value
                                                     ),
                                               mt103RemitMessage.SendersCorrespondent_53A.Value,
                                               mt103RemitMessage.SendersCorrespondent_53B.Value,
                                               mt103RemitMessage.SendersCorrespondent_53D.Value
                                        ).Value();
            ReceiversCorrespondent_54a = new NullIfEmpty<ReceiversCorrespondent_54a>(
                                            () => new ReceiversCorrespondent_54a(
                                                    mt103RemitMessage.ReceiversCorrespondent_54A.Value,
                                                    mt103RemitMessage.ReceiversCorrespondent_54B.Value,
                                                    mt103RemitMessage.ReceiversCorrespondent_54D.Value
                                                  ),
                                            mt103RemitMessage.ReceiversCorrespondent_54A.Value,
                                            mt103RemitMessage.ReceiversCorrespondent_54B.Value,
                                            mt103RemitMessage.ReceiversCorrespondent_54D.Value
                                        ).Value();
            ThirdReimbursementInstitution_55a = new NullIfEmpty<ThirdReimbursementInstitution_55a>(
                                                    () => new ThirdReimbursementInstitution_55a(
                                                            mt103RemitMessage.ThirdReimbursementInstitution_55A.Value,
                                                            mt103RemitMessage.ThirdReimbursementInstitution_55B.Value,
                                                            mt103RemitMessage.ThirdReimbursementInstitution_55D.Value
                                                          ),
                                                    mt103RemitMessage.ThirdReimbursementInstitution_55A.Value,
                                                    mt103RemitMessage.ThirdReimbursementInstitution_55B.Value,
                                                    mt103RemitMessage.ThirdReimbursementInstitution_55D.Value
                                                ).Value();
            IntermediaryInstitution_56a = new NullIfEmpty<IntermediaryInstitution_56a>(
                                                    () => new IntermediaryInstitution_56a(
                                                            mt103RemitMessage.IntermediaryInstitution_56A.Value,
                                                            mt103RemitMessage.IntermediaryInstitution_56C.Value,
                                                            mt103RemitMessage.IntermediaryInstitution_56D.Value
                                                        ),
                                                    mt103RemitMessage.IntermediaryInstitution_56A.Value,
                                                    mt103RemitMessage.IntermediaryInstitution_56C.Value,
                                                    mt103RemitMessage.IntermediaryInstitution_56D.Value
                                                ).Value();
            AccountWithInstitution_57a = new NullIfEmpty<AccountWithInstitution_57a>(
                                                () => new AccountWithInstitution_57a(
                                                        mt103RemitMessage.AccountWithInstitution_57A.Value,
                                                        mt103RemitMessage.AccountWithInstitution_57B.Value,
                                                        mt103RemitMessage.AccountWithInstitution_57C.Value,
                                                        mt103RemitMessage.AccountWithInstitution_57D.Value
                                                      ),
                                                mt103RemitMessage.AccountWithInstitution_57A.Value,
                                                mt103RemitMessage.AccountWithInstitution_57B.Value,
                                                mt103RemitMessage.AccountWithInstitution_57C.Value,
                                                mt103RemitMessage.AccountWithInstitution_57D.Value
                                            ).Value();
            BeneficiaryCustomer_59a = new BeneficiaryCustomer_59a(
                                            mt103RemitMessage.BeneficiaryCustomer_59.Value,
                                            mt103RemitMessage.BeneficiaryCustomer_59A.Value,
                                            mt103RemitMessage.BeneficiaryCustomer_59F.Value
                                      );
            DetailsOfCharges_71A = new DetailsOfCharges_71A(mt103RemitMessage.DetailsOfCharges_71A.Value);
            SendersCharges_71F = mt103RemitMessage
                                .SendersCharges_71F
                                .Select(t => new SendersCharges_71F(t))
                                .ToArray();
            ReceiversCharges_71G = new NullIfEmpty<ReceiversCharges_71G>(
                                        mt103RemitMessage.ReceiversCharges_71G.Value,
                                        t => new ReceiversCharges_71G(mt103RemitMessage.ReceiversCharges_71G)
                                    ).Value();

            SenterToReceiverInformation_72 = new NullIfEmpty<SenterToReceiverInformation_72>(
                                                    mt103RemitMessage.SenderToReceiverInformation_72.Value,
                                                    t => new SenterToReceiverInformation_72(t)
                                            ).Value();

            FieldSpecifications_77B = new NullIfEmpty<FieldSpecifications_77B>(
                                        mt103RemitMessage.RegulatoryReporting_77B.Value,
                                        t => new FieldSpecifications_77B(t)
                                    ).Value();

            EnvelopeContents_77T = new NullIfEmpty<EnvelopeContents_77T>(
                                        mt103RemitMessage.EnvelopeContents_77T.Value,
                                        t => new EnvelopeContents_77T(t)
                                    ).Value();
        }

        public SenderReference_20 SenderReference_20 { get; }
        public TimeIndication_13C[] TimeIndication_13C { get; }
        public BankOperationCode_23B BankOperationCode_23B { get; }
        public InstructionCode_23E[] InstructionCode_23E { get;  }
        public TransactionTypeCode_26T TransactionTypeCode_26T { get; }
        public ValueDateCurrencyInterbankSettledAmount_32A ValueDateCurrencyInterbankSettledAmount_32A { get;  }
        public CurrencyInstructedAmount_33B CurrencyInstructedAmount_33B { get; }
        public ExchangeRate_36 ExchangeRate_36 { get; }
        public OrderingCustomer_50a OrderingCustomer_50a { get; }
        public SendingInstitution_51A SendingInstitution_51A { get;  }
        public OrderingInstitution_52a OrderingInstitution_52a { get; }
        public SendersCorrespondent_53a SendersCorrespondent_53a { get; }
        public ReceiversCorrespondent_54a ReceiversCorrespondent_54a { get; }
        public ThirdReimbursementInstitution_55a ThirdReimbursementInstitution_55a { get; }
        public IntermediaryInstitution_56a IntermediaryInstitution_56a { get; }
        public AccountWithInstitution_57a AccountWithInstitution_57a { get; }
        public BeneficiaryCustomer_59a BeneficiaryCustomer_59a { get; }
        public DetailsOfCharges_71A DetailsOfCharges_71A { get; }
        public SendersCharges_71F[] SendersCharges_71F { get; }
        public ReceiversCharges_71G ReceiversCharges_71G { get; }
        public SenterToReceiverInformation_72 SenterToReceiverInformation_72 { get; }
        public FieldSpecifications_77B FieldSpecifications_77B { get; }
        public EnvelopeContents_77T EnvelopeContents_77T { get; }
        public IContent<string> BankLTAdress()
        {
            return new BankLTAdress(_swiftMessage);
        }

        public SwiftMessage Raw()
        {
            return _swiftMessage;
        }
    }
}