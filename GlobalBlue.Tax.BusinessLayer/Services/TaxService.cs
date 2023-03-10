using M = GlobalBlue.Tax.Model;

namespace GlobalBlue.Tax.BusinessLayer;

public class TaxService : ITaxService
{
    public void GetPurchaseData(M.Tax tax)
    {
        if (tax.GrossAmount != null)
        {
            CalculateNetAmount(tax);
            CalculateVatAmount(tax);
        }

        if (tax.NetAmount != null)
        {
            CalculateGrossAmount(tax);
            CalculateVatAmount(tax);
        }

        if (tax.VatAmount != null)
        {
            CalculateGrossAmount(tax);
            CalculateNetAmount(tax);
        }
    }

    private static void CalculateNetAmount(M.Tax tax)
    {
        if (tax != null)
        {
            if (tax.GrossAmount != null)
                tax.NetAmount = Math.Round((tax.GrossAmount / (1 + tax.VatRate)).Value, 2);
            else if (tax.VatAmount != null)
                tax.NetAmount = Math.Round((tax.VatAmount/ tax.VatRate).Value, 2);
        }
    }

    private static void CalculateGrossAmount(M.Tax tax)
    {
        if (tax != null)
        {
            if (tax.NetAmount != null)
                tax.GrossAmount = Math.Round((tax.NetAmount * (1 + tax.VatRate)).Value, 2);
            else if (tax.VatAmount != null)
                tax.GrossAmount = Math.Round(((tax.VatAmount / tax.VatRate) * (1 + tax.VatRate)).Value, 2);
        }
    }

    private static void CalculateVatAmount(M.Tax tax)
    {
        if (tax != null)
        {
            if (tax.NetAmount != null && tax.GrossAmount != null)
                tax.VatAmount = tax.GrossAmount - tax.NetAmount;
        }
    }
}
