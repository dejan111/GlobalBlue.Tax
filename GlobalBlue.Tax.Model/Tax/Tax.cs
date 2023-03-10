namespace GlobalBlue.Tax.Model;

public class Tax
{
    public decimal? NetAmount { get; set; }
    public decimal? GrossAmount { get; set; }
    public decimal? VatAmount { get; set; }
    public decimal VatRate { get; set; }
}