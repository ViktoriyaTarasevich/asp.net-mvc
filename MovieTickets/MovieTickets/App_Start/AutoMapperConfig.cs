using AutoMapper;
using MovieTickets.Domain;
using MovieTickets.ViewModels;
using MovieTickets.Entities.Models;
using Seance = MovieTickets.Entities.Models.Seance;
using Ticket = MovieTickets.Domain.Ticket;


namespace MovieTickets.App_Start
{
    public class AutoMapperConfig
    {
        public AutoMapperConfig()
        {
            
        }

        public static void CreateMapping()
        {
            Mapper.CreateMap<Ticket, TicketViewModels>();
            Mapper.CreateMap<Seance, SeanceViewModel>();
            Mapper.CreateMap<MovieTickets.Domain.Seance, MovieTickets.Entities.Models.Seance>();
        }
    }
}