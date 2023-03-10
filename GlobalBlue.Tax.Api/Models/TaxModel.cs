using FluentValidation;

namespace GlobalBlue.Tax.Api;

public class TaxModel
{
    private static readonly decimal[] _validVatRates = new[] { 0.1m, 0.13m, 0.2m };

    public decimal? NetAmount { get; set; }
    public decimal? GrossAmount { get; set; }
    public decimal? VatAmount { get; set; }
    public decimal VatRate { get; set; }

    public class TaxValidator : AbstractValidator<TaxModel>
    {
        public TaxValidator()
        {
            RuleFor(tax => tax)
               .Must(x => !(x.NetAmount == null && x.GrossAmount == null && x.VatAmount == null))
               .WithMessage("One of the net, gross or VAT amounts should be provided");

            RuleFor(tax => tax)
                 .Must(x => Convert.ToInt32(x.NetAmount != null) +
                 Convert.ToInt32(x.GrossAmount != null) +
                 Convert.ToInt32(x.VatAmount != null) == 1)
                 .WithMessage("Only one of the net, gross or VAT amounts should have value");

            RuleFor(m => m.VatRate)
                .Must(x => _validVatRates.Contains(x))
                .WithMessage("VAT rate has invalid value. Valid values: 0.1, 0.13, 0.2");

            RuleFor(m => m.NetAmount)
                .GreaterThan(0)
                .When(x => x != null)
                .WithMessage("Net amount must be greater than 0");

            RuleFor(m => m.GrossAmount)
                .GreaterThan(0)
                .When(x => x != null)
                .WithMessage("Gross amount must be greater than 0");

            RuleFor(m => m.VatAmount)
                .GreaterThan(0)
                .When(x => x != null)
                .WithMessage("VAT amount must be greater than 0");
        }
    }
}
