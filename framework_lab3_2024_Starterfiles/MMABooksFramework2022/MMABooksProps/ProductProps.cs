using System;
using System.Text.Json;
using MMABooksTools;
using DBDataReader = MySql.Data.MySqlClient.MySqlDataReader;

namespace MMABooksProps
{
    [Serializable()]
    public class ProductProps : IBaseProps
    {
        #region Auto-implemented Properties
        public string ProductCode { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal UnitPrice { get; set; } = 0.0m;
        public int OnHandQuantity { get; set; } = 0;
        public int ConcurrencyID { get; set; } = 0;
        #endregion

        #region IBaseProps Implementation
        public object Clone()
        {
            ProductProps p = new ProductProps
            {
                ProductCode = this.ProductCode,
                Description = this.Description,
                UnitPrice = this.UnitPrice,
                OnHandQuantity = this.OnHandQuantity,
                ConcurrencyID = this.ConcurrencyID
            };
            return p;
        }

        public string GetState()
        {
            return JsonSerializer.Serialize(this);
        }

        public void SetState(string jsonString)
        {
            ProductProps p = JsonSerializer.Deserialize<ProductProps>(jsonString);
            this.ProductCode = p.ProductCode;
            this.Description = p.Description;
            this.UnitPrice = p.UnitPrice;
            this.OnHandQuantity = p.OnHandQuantity;
            this.ConcurrencyID = p.ConcurrencyID;
        }

        public void SetState(DBDataReader dr)
        {
            this.ProductCode = ((string)dr["ProductCode"]).Trim();
            this.Description = ((string)dr["Description"]).Trim();
            this.UnitPrice = (decimal)dr["UnitPrice"];
            this.OnHandQuantity = (int)dr["OnHandQuantity"];
            this.ConcurrencyID = (int)dr["ConcurrencyID"];
        }
        #endregion
    }
}
