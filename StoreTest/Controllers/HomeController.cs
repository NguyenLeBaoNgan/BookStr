using PagedList;
using StoreTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace StoreTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
          return View();
        }
        DBContext db = new DBContext();
        public ActionResult Slider()
        {
            return View(db.Sliders.Take(5).ToList());
        }
        public ActionResult ProductList(int? page)
        {
            if (page == null) page = 1;
            var model = db.Products.OrderBy(x => x.ID);
            int pageSize = 8;
            int pageNumber = (page ?? 1);

            return View(model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult DetailProduct(int? ID)
        {
            Product product = db.Products.Find(ID);
            return View(product);
        }
        public ActionResult ProductByTacGia(int? ID)
        {
            return View(db.Products.Where(x => x.IsDeleted == false && x.IDTacGia == ID).ToList());
        }
        public ActionResult ProductByCategory(int? ID)
        {
            return View(db.Products.Where(x => x.IsDeleted == false && x.IDCategory == ID).ToList());
        }
        public ActionResult AddCart(int ID)
        {
            Product product = db.Products.Find(ID);
            if (Session["Cart"] == null)
            {
                List<Cart> cartList = new List<Cart>();
                Cart cart = new Cart();
                cart.ID = ID;
                cart.Name = product.Name;
                cart.Image = product.Image;
                cart.Cost = product.Cost;
                cart.Quality = 1;
                cartList.Add(cart);
                Session["Cart"] = cartList;
            }
            else
            {
                List<Cart> carts = (List<Cart>)Session["Cart"];
                int index = isExists(ID);
                if (index > -1)
                {
                    carts[index].Quality++;
                }
                else
                {
                    Cart cart = new Cart();
                    cart.ID = ID;
                    cart.Name = product.Name;
                    cart.Image = product.Image;
                    cart.Cost = product.Cost;
                    cart.Quality = 1;
                    carts.Add(cart);
                }
                Session["Cart"] = carts;
            }
            return RedirectToAction("Index");
        }
        public ActionResult ShoppingCart()
        {
            List<Cart> carts = (List<Cart>)Session["Cart"];
            return View(carts);
        }
        public ActionResult RemoveCart(int ID)
        {
            List<Cart> carts = (List<Cart>)Session["Cart"];
            int index = isExists(ID);
            carts.RemoveAt(index);
            Session["Cart"] = carts;
            return RedirectToAction("ShoppingCart", carts);
        }
        public ActionResult Search(string keyword)
        {
            return View(db.Products.Where(x => x.Name.ToLower().Contains(keyword.ToLower())
            || x.TacGia.Name.ToLower().Contains(keyword.ToLower())
            || x.Category.Name.ToLower().Contains(keyword.ToLower())).ToList());
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Account account)
        {
            bool check = false;
            foreach (Account acc in db.Accounts.ToList())
            {
                if (acc.Username.Trim().Equals(account.Username) && acc.Password.Trim().Equals(account.Password))
                {
                    check = true;
                }
            }
            if (check  )
            {
              
                return RedirectToAction("Index", "Products", new { Areas = "Admin" });
            }
            
            else
            {
                ViewBag.ThongBao = "tai khoan hoac mat khau khong chinh xac";
            }

            return View(account);

        }
        private int isExists(int ID)
        {
            List<Cart> carts = (List<Cart>)Session["Cart"];
            for (int i = 0; i < carts.Count; i++)
            {
                if (carts[i].ID == ID)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 
        /// </summary>
        
        public ActionResult Register()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Account account)
        {
            if (ModelState.IsValid)
            {
                var check = db.Accounts.FirstOrDefault(x => x.Username == account.Username);
                if (check == null)
                {
                    account.Password = GetMD5(account.Password);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Accounts.Add(account);
                  
                    
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ViewBag.error = "Username already exists";
                    return View();
                }


            }
            return View();


        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}