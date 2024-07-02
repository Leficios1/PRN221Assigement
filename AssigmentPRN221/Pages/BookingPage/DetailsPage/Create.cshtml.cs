using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BussinessObject.Model.Entities;
using DataAccessObject.Database;
using Services.Services.Interface;
using BussinessObject.DTOs.Request;

namespace AssigmentPRN221.Pages.BookingPage.DetailsPage
{
    public class CreateModel : PageModel
    {
        private readonly IBookingServices _Bookingservices;
        private readonly IVetServices _vetServices;
        private readonly IPetServices _petServices;
        private readonly IServiceServices _serviceServices;
        private readonly IAccountService _accountService;
        private readonly PetManagementContext _context;

        public CreateModel(IBookingServices bookingservices, IVetServices vetServices, IPetServices petServices,
                            IServiceServices serviceServices, IAccountService accountService, PetManagementContext context)
        {
            _Bookingservices = bookingservices;
            _vetServices = vetServices;
            _petServices = petServices;
            _serviceServices = serviceServices;
            _accountService = accountService;
            _context = context;
        }

        [BindProperty]
        public BookingRequestDTO Booking { get; set; } = default!;
        public SelectList Pets { get; set; }
        public SelectList Vets { get; set; }
        public SelectList Services { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var email = HttpContext.Session.GetString("UserEmail");
            if (email == null)
            {
                return RedirectToPage("/LoginPage");
            }

            var userInfo = await _accountService.GetAccountInfoByEmail(email);
            var pets = await _petServices.getPetByUserId(userInfo.Id);
            var vets = await _vetServices.getAll();
            var services = await _serviceServices.getAll();

            Pets = new SelectList((System.Collections.IEnumerable)pets, "Id", "PetName");
            Vets = new SelectList(vets, "Id", "Name");
            Services = new SelectList(services, "Id", "ServiceName");

            Booking = new BookingRequestDTO
            {
                UserId = userInfo.Id,
                Date = DateTime.Now,
                bookingDetails = new List<BookingDetailsRequestDTO>
                {
                    new BookingDetailsRequestDTO()
                }
            };

            return Page();

        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var email = HttpContext.Session.GetString("UserEmail");
            var userInfo = await _accountService.GetAccountInfoByEmail(email);
            Booking.UserId = userInfo.Id;
            try
            {
                await _Bookingservices.createBooking(Booking);
                return RedirectToPage("/BookingPage/Index");
            }catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page();
            }
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
