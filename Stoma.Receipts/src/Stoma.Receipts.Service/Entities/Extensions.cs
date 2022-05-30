namespace Stoma.Receipts.Service.Entities
{
    public static class Extensions
    {
        public static ReceiptDto AsDto(this Receipt receipt, Doctor doctor, Patient patient)
        {
            return new ReceiptDto(receipt.Id, doctor, patient, receipt.VisitDate);
        }
    }
}