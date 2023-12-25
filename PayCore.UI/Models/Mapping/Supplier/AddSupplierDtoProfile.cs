using AutoMapper;
using PayCore.UI.Models.Dto;
using PayCore.UI.Models.ORM;

namespace PayCore.UI.Models.Mapping
{
    public class AddSupplierDtoProfile : Profile
    {
        public AddSupplierDtoProfile()
        {
            CreateMap<AddSupplierDto, Supplier>()
                .AfterMap((dto, supplier) =>
                {
                    supplier.Country = "Turkiye";
                    supplier.Address = dto.Address.ToLower();
                });
        }
    }
}
