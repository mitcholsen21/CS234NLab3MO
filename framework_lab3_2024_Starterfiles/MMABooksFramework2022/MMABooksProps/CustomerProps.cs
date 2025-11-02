using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MMABooksTools;
using DBDataReader = MySql.Data.MySqlClient.MySqlDataReader;

namespace MMABooksProps
{
    /// <summary>
    /// Serializable class representing the properties of a Customer.
    /// Implements IBaseProps for use with the MMABooks tier framework.
    /// </summary>
    [Serializable()]
    public class CustomerProps : IBaseProps
    {
        #region Auto-implemented Properties

        public int CustomerID { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public string City { get; set; } = "";
        public string State { get; set; } = "";
        public string ZipCode { get; set; } = "";

        /// <summary>
        /// ConcurrencyID. Used for optimistic concurrency control.
        /// </summary>
        public int ConcurrencyID { get; set; } = 0;

        #endregion

        #region Methods required by IBaseProps

        /// <summary>
        /// Returns a deep copy of this CustomerProps object.
        /// </summary>
        public object Clone()
        {
            CustomerProps p = new CustomerProps
            {
                CustomerID = this.CustomerID,
                Name = this.Name,
                Address = this.Address,
                City = this.City,
                State = this.State,
                ZipCode = this.ZipCode,
                ConcurrencyID = this.ConcurrencyID
            };
            return p;
        }

        /// <summary>
        /// Returns a JSON string that represents the state of this object.
        /// </summary>
        public string GetState()
        {
            string jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }

        /// <summary>
        /// Restores the state of this object from a JSON string.
        /// </summary>
        public void SetState(string jsonString)
        {
            CustomerProps p = JsonSerializer.Deserialize<CustomerProps>(jsonString);
            this.CustomerID = p.CustomerID;
            this.Name = p.Name;
            this.Address = p.Address;
            this.City = p.City;
            this.State = p.State;
            this.ZipCode = p.ZipCode;
            this.ConcurrencyID = p.ConcurrencyID;
        }

        /// <summary>
        /// Populates this object’s properties from a MySqlDataReader.
        /// </summary>
        public void SetState(DBDataReader dr)
        {
            this.CustomerID = (int)dr["CustomerID"];
            this.Name = ((string)dr["Name"]).Trim();
            this.Address = ((string)dr["Address"]).Trim();
            this.City = ((string)dr["City"]).Trim();
            this.State = ((string)dr["State"]).Trim();
            this.ZipCode = ((string)dr["ZipCode"]).Trim();
            this.ConcurrencyID = (int)dr["ConcurrencyID"];
        }

        #endregion
    }
}

