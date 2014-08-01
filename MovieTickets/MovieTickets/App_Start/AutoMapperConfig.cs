using AutoMapper;
using BusinessLogic.Domain;
using MovieTickets.Presentation.ViewModels;

namespace MovieTickets.App_Start
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig()
        {
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>()
                .AfterMap((user, viewmodel) =>
                    {
                        
                    }
                );
            Mapper.CreateMap<ApplicationUser, LogInViewModel>();
            Mapper.CreateMap<ApplicationUser, ManageUserViewModel>();
            Mapper.CreateMap<Ticket, TicketViewModels>();
            Mapper.CreateMap<Seance, SeanceViewModel>();
            Mapper.CreateMap<Seance,HallViewModel>();
        }
    }
}