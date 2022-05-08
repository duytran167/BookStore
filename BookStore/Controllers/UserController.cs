using BookStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Controllers
{
	[Authorize(Roles = "User")]
	public class UserController : Controller
	{
		private ApplicationUser _user;
		private ApplicationDbContext _context;
		private UserManager<ApplicationUser> _usermanager;
		public UserController()
		{
			_user = new ApplicationUser();
			_context = new ApplicationDbContext();
			_usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
		}
		// GET: User
		//updaet trainee
		[HttpGet]
		public ActionResult Checkout(int id)
		{
			var assignModel = new ViewModel.OrderDetailViewModel()
			{
				Book = _context.Book.Include(t => t.Category).SingleOrDefault(t => t.Id == id),

			};


			return View(assignModel);
		}
		[HttpPost]
		public ActionResult Checkout(ViewModel.OrderDetailViewModel model)
		{
			var userId = User.Identity.GetUserId();

			var orderDetail = new OrderDetail()
			{
				UserID = userId,
				Datetime = model.DateTime,
				BookID = model.Book.Id,
				Quantity = model.Quantity,
				TotalPrice = model.Quantity * model.Book.Price
			};
			// tru di so luong da co 
			Book update = _context.Book.ToList().Find(u => u.Id == orderDetail.BookID);
			update.Quantity -= orderDetail.Quantity;

			_context.OrderDetail.Add(orderDetail);
			_context.SaveChanges();
			return RedirectToAction("OrderList", "User");
		}
		public ActionResult OrderList(string searchString)
		{
			var userId = User.Identity.GetUserId();
			var book = _context.OrderDetail.Include(t => t.Book.Category).OrderByDescending(t => t.Datetime).Where(t => t.UserID == userId).ToList();
			if (!String.IsNullOrWhiteSpace(searchString))
			{
				book = _context.OrderDetail
				.Where(t => t.Book.Title.Contains(searchString))
				.Include(t => t.Book.Category)
				.ToList();
			}
			return View(book);
		}

	}
}