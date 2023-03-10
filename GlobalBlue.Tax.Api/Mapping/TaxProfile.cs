using AutoMapper;
using M = GlobalBlue.Tax.Model;

namespace GlobalBlue.Tax.Api;

public class TaxProfile : Profile
{
    public TaxProfile()
    {
        CreateMap<M.Tax, TaxModel>().ReverseMap();
    }
}
