using AutoMapper;
using Jumbo.Modals;
using Jumbo.Modals.DTO;

namespace Jumbo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Example mapping: from DTO to Entity
            CreateMap<AddWoofDTO, Woofer>();
            CreateMap<Woofer, AddWoofDTO>(); // If you want to return a DTO
        }
    }
}
