using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using APIwishlist.Models;
using Newtonsoft.Json;

namespace APIwishlist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserlistsController : Controller//ControllerBase
    {
        private readonly WishlistContext _context;

        public UserlistsController(WishlistContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<UserList>> GetAll()
        {
            return _context.UserList.ToList();
        }

        [HttpGet("GetUserlist/{userList}", Name = "GetUserlist")]
        public ActionResult<UserList> GetById(int userList)
        {
            var item = _context.UserList.Find(userList);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("GetList/{userList}", Name = "GetList")]
        public ActionResult<UserList> GetListById(int userList)
        {
            var item = _context.UserList
                .Join(_context.ListProduct,
                ul => ul.IdList,
                lp => lp.IdList,
                (ul, lp) => new
                {
                    UserList = ul,
                    ListProduct = lp
                })
                .Join(_context.Product,
                lp => lp.ListProduct.IdProduct,
                p => p.IdProduct,
                (lp, p) => new
                {

                    Teste = lp,
                    Product = p
                })
                .Where(r => r.Teste.UserList.IdList == userList)
                .Select(s => new
                {
                    s.Teste.UserList.IdList,
                    s.Teste.UserList.NmList,
                    s.Teste.ListProduct.IdProduct,
                    s.Teste.ListProduct.CdStatus,
                    s.Product.NmProduct,
                    s.Product.IdTypeProduct,
                    s.Product.IdItem
                }).ToList();
                ;

            //List<Wishlist> wishlists = new List<Wishlist>();

            if (item == null)
            {
                return NotFound();
            }
            //return item;
            //string teste = JsonConvert.SerializeObject(item);
            
            return Json(new { Data = item });
        }
    }
}