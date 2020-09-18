using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestApi.Models.AssetModels;
using TestApi.Models.RequestModels;
using TestApi.Services.Common;

namespace TestApi.Services.AssetRepo
{
    public class AssetService : CommonService<Asset>, IAssetService<Asset>
    {

        private readonly IAssetRepository _assetRepository;

        public AssetService(ICommonRepository<Asset> commonRepository, IAssetRepository assetRepository) : base(commonRepository)
        {
            _assetRepository = assetRepository;
        }

    }
}
