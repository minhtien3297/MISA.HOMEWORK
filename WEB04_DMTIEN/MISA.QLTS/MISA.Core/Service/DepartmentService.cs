using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;

namespace MISA.Core.Service
{
    public class DepartmentService : BaseService<Department>
    {
        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
        }
    }
}