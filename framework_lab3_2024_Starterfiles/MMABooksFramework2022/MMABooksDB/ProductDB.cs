using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MMABooksTools;
using MMABooksProps;

namespace MMABooksDB
{
    public class ProductDB : BaseSQLDB, IReadDB, IWriteDB
    {
        public ProductDB() : base() { }

        public IBaseProps Retrieve(Object key)
        {
            string sql = "spProductSelect";
            MySqlCommand cmd = new MySqlCommand(sql, new MySqlConnection(mConnectionString));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pCode", key);

            try
            {
                cmd.Connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ProductProps p = new ProductProps();
                    p.SetState(dr);
                    dr.Close();
                    cmd.Connection.Close();
                    return p;
                }
                else
                {
                    dr.Close();
                    cmd.Connection.Close();
                    throw new Exception("Product not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Retrieve failed: " + ex.Message);
            }
        }

        public List<IBaseProps> RetrieveAll()
        {
            string sql = "spProductSelectAll";
            MySqlCommand cmd = new MySqlCommand(sql, new MySqlConnection(mConnectionString));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            List<IBaseProps> list = new List<IBaseProps>();

            try
            {
                cmd.Connection.Open();
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProductProps p = new ProductProps();
                    p.SetState(dr);
                    list.Add(p);
                }
                dr.Close();
                cmd.Connection.Close();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("RetrieveAll failed: " + ex.Message);
            }
        }

        public void Create(IBaseProps props)
        {
            ProductProps p = (ProductProps)props;
            string sql = "spProductInsert";

            MySqlCommand cmd = new MySqlCommand(sql, new MySqlConnection(mConnectionString));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pCode", p.ProductCode);
            cmd.Parameters.AddWithValue("pDescription", p.Description);
            cmd.Parameters.AddWithValue("pUnitPrice", p.UnitPrice);
            cmd.Parameters.AddWithValue("pOnHandQuantity", p.OnHandQuantity);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Create failed: " + ex.Message);
            }
        }

        public void Update(IBaseProps props)
        {
            ProductProps p = (ProductProps)props;
            string sql = "spProductUpdate";

            MySqlCommand cmd = new MySqlCommand(sql, new MySqlConnection(mConnectionString));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pCode", p.ProductCode);
            cmd.Parameters.AddWithValue("pDescription", p.Description);
            cmd.Parameters.AddWithValue("pUnitPrice", p.UnitPrice);
            cmd.Parameters.AddWithValue("pOnHandQuantity", p.OnHandQuantity);
            cmd.Parameters.AddWithValue("pOldConcurrencyID", p.ConcurrencyID);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Update failed: " + ex.Message);
            }
        }

        public void Delete(IBaseProps props)
        {
            ProductProps p = (ProductProps)props;
            string sql = "spProductDelete";

            MySqlCommand cmd = new MySqlCommand(sql, new MySqlConnection(mConnectionString));
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pCode", p.ProductCode);
            cmd.Parameters.AddWithValue("pOldConcurrencyID", p.ConcurrencyID);

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Delete failed: " + ex.Message);
            }
        }
    }
}
