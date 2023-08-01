using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            conn.Open();
            SqlCommand cmd = new SqlCommand("Create_Product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@User_ID", product.User_ID);
            cmd.Parameters.AddWithValue("@Department_ID", product.Department_ID);
            cmd.Parameters.AddWithValue("@Product_Name", product.Product_Name);
            cmd.Parameters.AddWithValue("@Product_Description", product.Product_Description);
            cmd.Parameters.AddWithValue("@Product_Gender", product.Product_Gender);
            //cmd.Parameters.AddWithValue("@Product_Type_ID", product.Product_Type_ID);
            cmd.Parameters.AddWithValue("@Product_Price", product.Product_Price);
            cmd.Parameters.AddWithValue("@Product_Quantity", product.Product_Quantity);
            //cmd.Parameters.AddWithValue("@Size_ID", size.Size_ID);
            cmd.ExecuteNonQuery();
            conn.Close();

            return "Added Successfully";
        }

        [HttpPost]
        [Route("Sizes")]
        public List<Size> ProductSizes()
        {
            List<Size> sizes = new List<Size>();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Read_All_ProductSize", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Size size = new Size
                    {
                        Size_ID = Convert.ToInt32(reader["Size_ID"]),
                        Size_Name = reader["Size_Name"].ToString()
                    };
                    sizes.Add(size);
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
            return sizes;
        }

        [HttpPost]
        [Route("Products")]
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            //try
            //{
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
                        //Product_Image = reader["Product_Image"].ToString()
                        ,
                        Product_Gender = reader["Product_Gender"].ToString()
                        //Product_Type_ID = Int32.Parse(reader["Product_Type_ID"].ToString())
                        , Product_Price = float.Parse(reader["Product_Price"].ToString())
                        , Product_Quantity = Int32.Parse(reader["Product_Quantity"].ToString())
                       // , Sizes = Int32.Parse(reader["Product_Size"].ToString())
                    };
                    products.Add(product);
                }
                reader.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            //finally
            //{
                conn.Close();
            //}
            return products;
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public string Update_Product(Product product)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Update_Product", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Product_ID", product.Product_ID);
            cmd.Parameters.AddWithValue("@Department_ID", product.Department_ID);
            cmd.Parameters.AddWithValue("@Product_Name", product.Product_Name);
            cmd.Parameters.AddWithValue("@Product_Description", product.Product_Description);
            //cmd.Parameters.AddWithValue("@Product_Gender", product.Product_Gender);
            //cmd.Parameters.AddWithValue("@Product_Type_ID", product.Product_Type_ID);
            cmd.Parameters.AddWithValue("@Product_Price", product.Product_Price);
            cmd.Parameters.AddWithValue("@Product_Quantity", product.Product_Quantity);
            //cmd.Parameters.AddWithValue("@Size_ID", size.Size_ID);
            cmd.ExecuteNonQuery();
            conn.Close();

            return "Update Successfully";
        }
        [HttpGet]
        [Route("Products/{id}")]
        public Product GetProductById(int id)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("Read_Product_By_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Product_ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            Product product = null;

            if (reader.Read())
            {
                product = new Product()
                {
                    Product_ID = Int32.Parse(reader["Product_ID"].ToString())
                    ,
                    Department_ID = Int32.Parse(reader["Department_ID"].ToString())
                    ,
                    Product_Name = reader["Product_Name"].ToString()
                    ,
                    Product_Description = reader["Product_Description"].ToString()
                    //Product_Image = reader["Product_Image"].ToString()
                    ,
                    Product_Gender = reader["Product_Gender"].ToString()
                    //Product_Type_ID = Int32.Parse(reader["Product_Type_ID"].ToString())
                    ,
                    Product_Price = float.Parse(reader["Product_Price"].ToString())
                    ,
                    Product_Quantity = Int32.Parse(reader["Product_Quantity"].ToString())
                    // , Sizes = Int32.Parse(reader["Product_Size"].ToString())
                };
            }

            conn.Close();
            return product;
        }
    }
}
