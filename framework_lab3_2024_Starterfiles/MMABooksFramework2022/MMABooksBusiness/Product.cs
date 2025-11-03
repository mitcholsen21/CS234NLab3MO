using System;
using System.Collections.Generic;
using MMABooksProps;
using MMABooksDB;
using MMABooksTools;

namespace MMABooksBusiness
{
    public class Product : BaseBusiness
    {
        public string ProductCode
        {
            get { return ((ProductProps)mProps).ProductCode; }
            set
            {
                if (value.Trim().Length > 0 && value.Trim().Length <= 10)
                {
                    ((ProductProps)mProps).ProductCode = value;
                    mIsDirty = true;
                    mRules.RuleBroken("ProductCode", false);
                }
                else
                    throw new ArgumentOutOfRangeException("ProductCode must be 1–10 characters long.");
            }
        }

        public string Description
        {
            get { return ((ProductProps)mProps).Description; }
            set
            {
                if (value.Trim().Length > 0)
                {
                    ((ProductProps)mProps).Description = value;
                    mIsDirty = true;
                    mRules.RuleBroken("Description", false);
                }
                else
                    throw new ArgumentOutOfRangeException("Description is required.");
            }
        }

        public decimal UnitPrice
        {
            get { return ((ProductProps)mProps).UnitPrice; }
            set
            {
                if (value >= 0)
                {
                    ((ProductProps)mProps).UnitPrice = value;
                    mIsDirty = true;
                    mRules.RuleBroken("UnitPrice", false);
                }
                else
                    throw new ArgumentOutOfRangeException("UnitPrice cannot be negative.");
            }
        }

        public int OnHandQuantity
        {
            get { return ((ProductProps)mProps).OnHandQuantity; }
            set
            {
                if (value >= 0)
                {
                    ((ProductProps)mProps).OnHandQuantity = value;
                    mIsDirty = true;
                    mRules.RuleBroken("OnHandQuantity", false);
                }
                else
                    throw new ArgumentOutOfRangeException("OnHandQuantity cannot be negative.");
            }
        }

        protected override void SetDefaultProperties()
        {
            ((ProductProps)mProps).ProductCode = "";
            ((ProductProps)mProps).Description = "";
            ((ProductProps)mProps).UnitPrice = 0.0m;
            ((ProductProps)mProps).OnHandQuantity = 0;
        }

        protected override void SetRequiredRules()
        {
            mRules.RuleBroken("ProductCode", true);
            mRules.RuleBroken("Description", true);
        }

        protected override void SetUp()
        {
            mProps = new ProductProps();
            mOldProps = new ProductProps();
            mdbReadable = new ProductDB();
            mdbWriteable = new ProductDB();
        }

        public Product() : base() { }
        public Product(string code) : base(code) { }
        private Product(ProductProps props) : base(props) { }

        public override object GetList()
        {
            List<Product> products = new List<Product>();
            List<ProductProps> propsList = (List<ProductProps>)mdbReadable.RetrieveAll();

            foreach (ProductProps p in propsList)
                products.Add(new Product(p));

            return products;
        }
    }
}
