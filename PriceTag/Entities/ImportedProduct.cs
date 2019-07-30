using System.Globalization;

namespace PriceTag.Entities
{
    class ImportedProduct : Product
    {
        //Atributos
        public double CustomsFee { get; set; }

        //Contrutores
        public ImportedProduct()
        {
        }

        public ImportedProduct(string name, double price, double customsFee) 
            : base(name, price)
        {
            CustomsFee = customsFee;
        }

        //Metodos
        public double TotalPrice()
        {
            return Price + CustomsFee;
        }

        public override string PriceTag()
        {
            return Name + " $ " + TotalPrice().ToString("F2",CultureInfo.InvariantCulture) + " (Customs fee: $ " + CustomsFee.ToString("F2", CultureInfo.InvariantCulture) + ")";
        }        
    }
}
