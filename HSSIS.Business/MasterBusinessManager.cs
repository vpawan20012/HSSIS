using HSSIS.Data.DataContext;
using HSSIS.Models.DataModels;
using HSSIS.Repository.AssetCategory;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Business
{
    public class MasterBusinessManager : BusinessManagerBase, IMasterBusinessManager
    {
        public MasterBusinessManager(IAssetCategoryRepository assetCategoryRepository)
        {
            base.assetCategoryRepository=assetCategoryRepository;
        }

        public async Task<IList<AssetCategoryModel>> GetAllAssetCategories()
        {
            try
            {
                return await base.assetCategoryRepository.GetAllAssetCategories();    
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
