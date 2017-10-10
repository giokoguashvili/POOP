using System;
using DapperExtensions.Mapper;

namespace Swift.Integration.Db.Models
{
    [MapConfig("DOCS_IN_SWIFT", "impexp")]
    public class DbDOCS_IN_SWIFT : IDbModel
    {
        public DateTime PORTION_DATE { get; set; }
        public int PORTION { get; set; }
        public int ROW_ID { get; set; }
        public int UID { get; set; }
        public string REF_NUM { get; set; }
        public DateTime DOC_DATE_IN_DOC { get; set; }
        public string ISO { get; set; }
        public decimal AMOUNT { get; set; }
        public string DESCRIP { get; set; }
        public string SENDER_BANK_CODE { get; set; }
        public string SENDER_BANK_NAME { get; set; }
        public string SENDER_ACC { get; set; }
        public string SENDER_ACC_NAME { get; set; }
        public string RECEIVER_BANK_CODE { get; set; }
        public string RECEIVER_BANK_NAME { get; set; }
        public string RECEIVER_ACC { get; set; }
        public string RECEIVER_ACC_NAME { get; set; }
        public string INTERMED_BANK_CODE { get; set; }
        public string INTERMED_BANK_NAME { get; set; }
        public string COR_BANK_CODE { get; set; }
        public string COR_BANK_NAME { get; set; }
        public int? CORRESPONDENT_BANK_ID { get; set; }
        public string COR_COUNTRY { get; set; }
        public string TAG_53X_STATUS { get; set; }
        public string TAG_53X_VALUE { get; set; }
        public string TAG_54X_STATUS { get; set; }
        public string TAG_54X_VALUE { get; set; }
        public string EXTRA_INFO { get; set; }
        public bool EXTRA_INFO_DESCRIP { get; set; }
        public string DET_OF_CHARG { get; set; }
        public string SWIFT_TEXT { get; set; }
        public int STATE { get; set; }
        public bool IS_READY { get; set; }
        public bool IS_FINALYZED { get; set; }
        public decimal? ACCOUNT { get; set; }
        public int? ACC_ID { get; set; }
        public string OTHER_INFO { get; set; }
        public string ERROR_REASON { get; set; }
        public DateTime? DOC_DATE { get; set; }
        public int SWIFT_FILE_ROW_ID { get; set; }
        public string SWIFT_FILENAME { get; set; }
        public DateTime? FINALYZE_DATE { get; set; }
        public int? FINALYZE_BANK_ID { get; set; }
        public int? FINALYZE_ACC_ID { get; set; }
        public decimal? FINALYZE_AMOUNT { get; set; }
        public string FINALYZE_ISO { get; set; }
        public int? FINALYZE_DOC_REC_ID { get; set; }
        public int? DOC_REC_ID { get; set; }
        public bool IS_AUTHORIZED { get; set; }
        public bool IS_MODIFIED { get; set; }
        public int FLAGS { get; set; }
        public string SENDER_COUNTRY_CODE { get; set; }
        public string SENDER_F50_OPTION { get; set; }
        public string SENDER_ADDRESS_LAT { get; set; }
        public int? SWIFT_FLAGS_1 { get; set; }
        public int? SWIFT_FLAGS_2 { get; set; }
    }

}
