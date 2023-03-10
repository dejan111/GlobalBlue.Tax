using AutoMapper;
using GlobalBlue.Tax.BusinessLayer;
using M = GlobalBlue.Tax.Model;
using Microsoft.AspNetCore.Mvc;

namespace GlobalBlue.Tax.Api.Controllers;

[ApiController]
public class TaxController : ControllerBase
{
    private readonly ITaxService _service;
    private readonly IMapper _mapper;

    public TaxController(ITaxService service, IMapper mapper)
    {
        _mapper = mapper;
        _service = service;
    }

    [HttpPost]
    [Route("/taxes")]
    public ActionResult<TaxModel> GetTaxData([FromBody] TaxModel taxModel)
    {
        var tax = _mapper.Map<M.Tax>(taxModel);
        _service.GetPurchaseData(tax);

        return Ok(_mapper.Map<TaxModel>(tax));
    }
}
