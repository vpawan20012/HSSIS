using Azure;
using HSSIS.Data.DataContext;
using HSSIS.Models.DataModels;
using HSSIS.Models.ViewModels;
using HSSIS.Repository.AssetCategory;
using HSSIS.Repository.AssetSubCategory;
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
        public MasterBusinessManager(IAssetCategoryRepository assetCategoryRepository,IAssetSubCategoryRepository assetSubCategoryRepository)
        {
            base.assetCategoryRepository = assetCategoryRepository;
            base.assetSubCategoryRepository = assetSubCategoryRepository;
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

        public async Task<HttpResponseViewModel<IList<AssetSubCategoryViewModel>>> GetAllAssetSubCategories(int assetCategoryId)
        {
            HttpResponseViewModel<IList<AssetSubCategoryViewModel>> response = new HttpResponseViewModel<IList<AssetSubCategoryViewModel>>();
            try
            {
                response.Result = await base.assetSubCategoryRepository.GetAllAssetSubCategories(assetCategoryId);
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }
    }
}
