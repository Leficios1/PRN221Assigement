using AutoMapper;
using BussinessObject.DTOs.Request;
using BussinessObject.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Services.Interface;
using System.Drawing;

namespace AssigmentPRN221.Pages.BookingPage.DetailsPage.Kennel
{

    public class AddKennelModel : PageModel
    {
        private readonly IKennelRecordService _kennelRecordService;
        private readonly IBookingServices _bookingServices;
        private readonly IKennelService _kennelService;
        private readonly IPetServices _petServices;
        private readonly IMapper _mapper;

        public AddKennelModel(IKennelRecordService kennelRecordService, IBookingServices bookingServices, IKennelService kennelService
            , IMapper mapper, IPetServices petServices)
        {
            _kennelRecordService = kennelRecordService;
            _bookingServices = bookingServices;
            _kennelService = kennelService;
            _mapper = mapper;
            _petServices = petServices;
        }

        [BindProperty]
        public KennelRecord KennelRecord { get; set; }

        public SelectList Kennels { get; set; }

        public async Task<IActionResult> OnGetAsync(string petName, int KennelId)
        {
            var kennels = await _kennelService.GetAllKennelInvalid();
            Kennels = new SelectList(kennels, "KennelId", "Name");

            if (petName == null)
            {
                return NotFound($"Pet with name '{petName}' not found.");
            }

            var petId = await _petServices.getPetIdByPetName(petName);
            Console.WriteLine($"PetName: {petName}");
            Console.WriteLine($"PetId: {petId}");

            if (petId == 0)
            {
                return NotFound($"Pet with name '{petName}' not found.");
            }
            KennelRecord = new KennelRecord
            {
                PetId = petId,
                CheckInDate = DateTime.Now
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine($"PetId: {KennelRecord.PetId}");
            Console.WriteLine($"KennelId: {KennelRecord.KennelId}");
            Console.WriteLine($"CheckInDate: {KennelRecord.CheckInDate}");
            Console.WriteLine($"CheckOutDate: {KennelRecord.CheckOutDate}");
            Console.WriteLine($"Treatment: {KennelRecord.Treatment}");


            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            var mapper = _mapper.Map<KennelRecordRequestDTO>(KennelRecord);
            await _kennelRecordService.AddKennelRecord(mapper);

            return RedirectToPage("/BookingPage/Index");
        }
    }
}
