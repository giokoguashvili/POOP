namespace Swift.AltaSoftware.Wrapper.Swift.MT._103.Tags.DEFAULT_REMIT_STP._23B
{
    /// <summary>
    /// 4!c
    /// </summary>
    public class BankOperationCode_23B
    {
        public BankOperationCode_23B(string tag23BValue)
        {
            Type = tag23BValue.Substring(0, 4);
        }

        public string Type { get; }
    }
}