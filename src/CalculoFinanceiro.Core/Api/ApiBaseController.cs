using Microsoft.AspNetCore.Mvc;

namespace CalculoFinanceiro.Core.Api
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiBaseController : ControllerBase
    {
    }
}
