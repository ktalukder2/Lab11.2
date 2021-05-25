using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using ShopApp.Data;
using ShopApp.Models;

namespace ShopApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            using var con = new MySqlConnection(ApplicationDbContext.Value);
            var product = con.Query<Product>("select * from product", null, null, true, 0, CommandType.Text).ToList();
            return View(product);
        }
        public IActionResult Details(int id)
        {
            using var con = new MySqlConnection(ApplicationDbContext.Value);
            var param = new DynamicParameters();
            param.Add("@ID", id);
            var product = con.Query<Product>("select * from product where ID= @ID", param, null, true, 0, CommandType.Text).FirstOrDefault();
            return View(product);
        }
        public IActionResult CategoryIndex()
        {
            using var con = new MySqlConnection(ApplicationDbContext.Value);
            var categories = con.Query<Product>("select category from product group by category", null, null, true, 0, CommandType.Text).ToList();
            return View(categories);
        }
        public IActionResult ProductDetails(string categoryName)
        {
            using var con = new MySqlConnection(ApplicationDbContext.Value);
            var param = new DynamicParameters();
            param.Add("@Category", categoryName);
            var product = con.Query<Product>("select * from product where Category= @Category", param, null, true, 0, CommandType.Text).ToList();
            return View(product);
        }


    }
}
