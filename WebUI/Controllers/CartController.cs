using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using Domain.DAO;
using WebUI.Common;

namespace WebUI.Controllers
{
    public class CartController : Controller
    {
       


        // GET: Cart
        /// <summary>
        /// Lấy dữ liệu từ session và đưa ra view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var cart = Session[CommonConstant.CART_SESSION];
            var listCart = new List<CartItem>();
            if ( cart != null) {
                listCart = (List<CartItem>)cart;
            }

            return View(listCart);
        }


        /// <summary>
        /// Thêm sản phẩm vào giỏ hàng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// 
        
        public ActionResult AddItem(long id, int quantity) {
            var product = new ProductDAO().GetByID(id);
            var cart = Session[CommonConstant.CART_SESSION];        
            if ( cart != null ) {
                // Nếu đã có giỏ hàng
                var listCart =  (List<CartItem>)Session[CommonConstant.CART_SESSION];
                
                // Nếu sản phẩm đã có trong giỏ hàng.
                if( listCart.Exists( x => x.Product.ID == product.ID) ) {
                    foreach (var item in listCart) {
                        if (item.Product.ID == product.ID) {
                            item.Quantity++;
                        }
                    }
                } else {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;

                    listCart.Add(item);
                }      
                // Gán vào sesion
                Session[CommonConstant.CART_SESSION] = listCart;
            } else {
                // Giỏ hàng chưa có.
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var listCart = new List<CartItem>();
                listCart.Add(item);

                // Gán vào sesion
                Session[CommonConstant.CART_SESSION] = listCart;              
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Xóa item trong giỏ hàng và trả về json
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public JsonResult DeleteCartItem(int id) {
            var listCart = (List<CartItem>)Session[CommonConstant.CART_SESSION];
            foreach( var item in listCart) {
                if ( item.Product.ID == id ) {
                    listCart.Remove(item);
                    break;
                }
            }
            Session[CommonConstant.CART_SESSION] = listCart;

            decimal total = 0;
            foreach (var item in listCart) {
                total += (item.Product.Price * item.Quantity).Value;
            }

            return Json(total);  
        }


    }
}