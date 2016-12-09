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
        
        [HttpPost]
        public JsonResult AddItem(int id) {
            var product = new ProductDAO().GetByID(id);
            var cart = Session[CommonConstant.CART_SESSION];        
            if ( cart != null ) {
                // Nếu đã có giỏ hàng
                var list =  (List<CartItem>)Session[CommonConstant.CART_SESSION];
                
                // Nếu sản phẩm đã có trong giỏ hàng.
                if( list.Exists( x => x.Product.ID == product.ID) ) {
                    foreach (var item in list) {
                        if (item.Product.ID == product.ID) {
                            item.Quantity++;
                        }
                    }
                } else {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = 1;

                    list.Add(item);
                }      
                // Gán vào sesion
                Session[CommonConstant.CART_SESSION] = list;
            } else {
                // Giỏ hàng chưa có.
                var item = new CartItem();
                item.Product = product;
                item.Quantity = 1;
                var list = new List<CartItem>();
                list.Add(item);

                // Gán vào sesion
                Session[CommonConstant.CART_SESSION] = list;              
            }

            var listCart = (List<CartItem>)Session[CommonConstant.CART_SESSION];
            decimal total = 0;
            int count = 0;
            foreach (var item in listCart) {
                total += (item.Product.Price * item.Quantity).Value;
                count++;
            }

            var data = new { total, count };
            return Json(data);        
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

            var data = new {
                totalData = total,
                count = listCart.Count
            };

            return Json(data);  
        }


    }
}