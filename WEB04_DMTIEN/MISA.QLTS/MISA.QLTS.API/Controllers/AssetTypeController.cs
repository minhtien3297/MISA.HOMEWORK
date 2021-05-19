using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;

namespace MISA.QLTS.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class AssetTypeController : BaseEntityController<AssetType>
    {
        public AssetTypeController(IBaseService<AssetType> baseService) : base(baseService)
        {
        }
    }
}