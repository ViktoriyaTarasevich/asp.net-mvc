using AutoMapper;
using MovieTickets.Domain;
using MovieTickets.ViewModels;

namespace MovieTickets.App_Start
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig()
        {
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            Mapper.CreateMap<ApplicationUser, LogInViewModel>();
            Mapper.CreateMap<ApplicationUser, ManageUserViewModel>();
            Mapper.CreateMap<Ticket, TicketViewModels>();
            Mapper.CreateMap<Seance, SeanceViewModel>();
            Mapper.CreateMap<Seance, HallViewModel>();
        }
    }
}