using AutoMapper;
using PayCore.UI.Models.Dto;
using PayCore.UI.Models.ORM;

namespace PayCore.UI.Models.Mapping
{
    public class AddEmployeeProfileDto : Profile
    {
        public AddEmployeeProfileDto()
        {
            CreateMap<AddEmployeeDto, Employee>();
        }

    }
}
