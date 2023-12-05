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
        #region Constructor
        public MasterBusinessManager(IAssetCategoryRepository assetCategoryRepository,IAssetSubCategoryRepository assetSubCategoryRepository)
        {
            base.AssetCategoryRepository = assetCategoryRepository;
            base.AssetSubCategoryRepository = assetSubCategoryRepository;
        }
        #endregion

        #region Asset Category

        public async Task<HttpResponseViewModel<IList<AssetCategoryModel>>> GetAllAssetCategories()
        {
            HttpResponseViewModel<IList<AssetCategoryModel>> response = new HttpResponseViewModel<IList<AssetCategoryModel>>();
            try
            {
                response.Result= await base.AssetCategoryRepository.GetAllAssetCategories();
            }
            catch (Exception ex)
            {
                base.HandleException(ex,response);
            }
            return response;    
        }

        public async Task<HttpResponseViewModel<AssetCategoryModel>> GetAssetCategoryById(int assetCategoryId)
        {
            HttpResponseViewModel<AssetCategoryModel> response = new HttpResponseViewModel<AssetCategoryModel>();
            try
            {
                response.Result = await base.AssetCategoryRepository.GetAssetCategoryById(assetCategoryId);
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        public async Task<HttpResponseViewModel<AssetCategoryModel>> GetAssetCategoryByName(string assetCategoryName)
        {
            HttpResponseViewModel<AssetCategoryModel> response = new HttpResponseViewModel<AssetCategoryModel>();
            try
            {
                response.Result = await base.AssetCategoryRepository.GetAssetCategoryByName(assetCategoryName);
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }
        #endregion

        #region Asset Sub Category

        
        public async Task<HttpResponseViewModel<IList<AssetSubCategoryViewModel>>> GetAllAssetSubCategories(int assetCategoryId)
        {
            HttpResponseViewModel<IList<AssetSubCategoryViewModel>> response = new HttpResponseViewModel<IList<AssetSubCategoryViewModel>>();
            try
            {
                response.Result = await base.AssetSubCategoryRepository.GetAllAssetSubCategories(assetCategoryId);
            }
            catch (Exception ex)
            {
                base.HandleException(ex, response);
            }
            return response;
        }

        #endregion

    }
}
