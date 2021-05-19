using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Services;

namespace MISA.QLTS.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class DepartmentController : BaseEntityController<Department>
    {
        public DepartmentController(IBaseService<Department> baseService) : base(baseService)
        {
        }
    }
}