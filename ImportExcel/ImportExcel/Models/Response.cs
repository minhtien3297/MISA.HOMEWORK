using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportExcel.Models
{
    public class Response<Entity>
    {
        public Entity Data { get; set; }

        public static DemoResponse<Entity> GetResult(Entity data = default(Entity))
        {
            return new DemoResponse<Entity>
            {
                Data = data
            };
        }
    }
}