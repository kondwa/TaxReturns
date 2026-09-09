namespace TaxReturns.Domain.Models
{
    public record PenaltyQuery(
        int Page,
        int PageSize,
        string? Tpin,
        string? ReturnReference
    );

}
