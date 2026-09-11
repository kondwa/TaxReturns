namespace TaxReturns.Plugins.VAT.Domain.Entities
{
    public static class VatTaxpayerType
    {
        public const string Entity = "Entity";
        public const string Individual = "Individual";

        /// <summary>Normalises free-text input to <see cref="Entity"/> or <see cref="Individual"/>.</summary>
        public static string Normalize(string? value)
        {
            var v = value?.Trim();
            if (string.Equals(v, Entity, StringComparison.OrdinalIgnoreCase)
                || string.Equals(v, "Corporate", StringComparison.OrdinalIgnoreCase)
                || string.Equals(v, "Company", StringComparison.OrdinalIgnoreCase)
                || string.Equals(v, "Organisation", StringComparison.OrdinalIgnoreCase)
                || string.Equals(v, "Organization", StringComparison.OrdinalIgnoreCase))
                return Entity;
            if (string.Equals(v, Individual, StringComparison.OrdinalIgnoreCase)
                || string.Equals(v, "Person", StringComparison.OrdinalIgnoreCase)
                || string.Equals(v, "Sole Proprietor", StringComparison.OrdinalIgnoreCase))
                return Individual;
            return string.Empty;
        }

        public static bool IsEntity(string? value) => Normalize(value) == Entity;
    }
}
