using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using Newtonsoft.Json;
using unitee_supplier_backend.Models;

namespace unitee_supplier_backend.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        SqlConnection conn = new SqlConnection("Server=LAPTOP-1IIQ2CRS\\SQLEXPRESS; Database=UNITEE; Integrated Security=true;");

        [HttpPost]
        [Route("Departments")]
        public List<Department> Departments()
        {
            List<Department> departments = new List<Department>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Read_All_Department", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Department department = new Department
                    {
                        Department_ID = Convert.ToInt32(reader["Department_ID"]),
                        Department_Name = reader["Department_Name"].ToString()
                    };
                    departments.Add(department);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return departments;
        }

        [HttpPost]
        [Route("AddProduct")]
        public string Create_Product(Product product)
        {
            string msg = string.Empty;
            conn.Open();
            SqlCommand cmd = new SqlCommand("Create_Product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Department_ID", product.Department_ID);
            cmd.Parameters.AddWithValue("@Product_Name", product.Product_Name);
            cmd.Parameters.AddWithValue("@Product_Description", product.Product_Description);
            cmd.Parameters.AddWithValue("@Product_Image", product.Product_Image);
            cmd.Parameters.AddWithValue("@Product_Gender", product.Product_Gender);
            cmd.Parameters.AddWithValue("@Product_Type_ID", product.Product_Type_ID);
            cmd.Parameters.AddWithValue("@Product_Price", product.Product_Price);
            cmd.Parameters.AddWithValue("@Product_Quantity", product.Product_Quantity);
            cmd.Parameters.AddWithValue("@Product_Size", product.Product_Size);
            int i = cmd.ExecuteNonQuery();
            if(i > 0)
            {
                msg = "Added Succesfully";
            }
            else
            {
                msg = "Misssing Fields";
            }
            conn.Close();
            return msg;
        }

        [HttpPost]
        [Route("ProductSizes")]
        public List<ProductSize> ProductSizes()
        {
            List<ProductSize> productSizes = new List<ProductSize>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Read_All_ProductSize", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductSize productSize = new ProductSize
                    {
                        Size_ID = Convert.ToInt32(reader["Size_ID"]),
                        Size_Name = reader["Size_Name"].ToString()
                    };
                    productSizes.Add(productSize);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return productSizes;
        }

        [HttpPost]
        [Route("Products")]
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Read_All_Products", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        Product_ID = Int32.Parse(reader["Product_ID"].ToString())
                        , Department_ID = Int32.Parse(reader["Department_ID"].ToString())
                        , Product_Name = reader["Product_Name"].ToString()
                        ,
                        Product_Description = reader["Product_Description"].ToString()
                        ,
                        Product_Image = reader["Product_Image"].ToString()
                        ,
                        Product_Gender = reader["Product_Gender"].ToString()
                        ,
                        Product_Type_ID = Int32.Parse(reader["Product_Type_ID"].ToString())
                        , Product_Price = float.Parse(reader["Product_Price"].ToString())
                        , Product_Quantity = Int32.Parse(reader["Product_Quantity"].ToString())
                        , Product_Size = Int32.Parse(reader["Product_Size"].ToString())
                    };
                    products.Add(product);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return products;
        }
    }
}
