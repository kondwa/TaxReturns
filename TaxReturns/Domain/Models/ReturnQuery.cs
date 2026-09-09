namespace TaxReturns.Domain.Models
{
    public record ReturnQuery(
        int Page,
        int PageSize,
        int? PeriodYear,
        int? PeriodMonth,
        string? Tpin,
        string? Status,
        string? Prn
    );
}
