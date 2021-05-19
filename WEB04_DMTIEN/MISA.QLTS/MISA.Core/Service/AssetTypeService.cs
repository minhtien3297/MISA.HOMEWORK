using MISA.Core.Entities;
using MISA.Core.Interfaces.Repositories;

namespace MISA.Core.Service
{
    public class AssetTypeService : BaseService<AssetType>
    {
        public AssetTypeService(IAssetTypeRepository assetTypeRepository) : base(assetTypeRepository)
        {
        }
    }
}