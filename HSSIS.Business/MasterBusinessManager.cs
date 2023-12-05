using Azure;
using HSSIS.Data.DataContext;
using HSSIS.Models.DataModels;
using HSSIS.Models.ViewModels;
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
            base.assetCategoryRepository = assetCategoryRepository;
        }

        public async Task<HttpResponseViewModel<IList<AssetCategoryModel>>> GetAllAssetCategories()
        {
            HttpResponseViewModel<IList<AssetCategoryModel>> response = new HttpResponseViewModel<IList<AssetCategoryModel>>();
            try
            {
                response.Result= await base.assetCategoryRepository.GetAllAssetCategories();
            }
            catch (Exception ex)
            {
                base.HandleException(ex,response);
            }
            return response;    
        }
    }
}
