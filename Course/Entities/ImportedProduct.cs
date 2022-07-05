using System.Globalization;

namespace Course.Entities
{
    class ImportedProduct : Product
    {
        public double CustomFee { get; set; }

        public ImportedProduct(string name, double price, double customFee) : base(name, price)
        {
            CustomFee = customFee;
        }

        public double TotalPrice()
        {
            return Price + CustomFee;
        }

        public override string PriceTag()
        {
            return Name + " $ " + Price.ToString("F2", CultureInfo.InvariantCulture)
                + " (Custom fee: $ " + CustomFee.ToString("F2", CultureInfo.InvariantCulture) + ")";
        }
    }
}
