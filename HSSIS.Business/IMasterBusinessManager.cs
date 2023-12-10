using HSSIS.Data.DataContext;
using HSSIS.Models.DataModels;
using HSSIS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Business
{
    public interface IMasterBusinessManager
    {
        #region Asset Category
        
        Task<HttpResponseViewModel<IList<AssetCategoryModel>>> GetAllAssetCategories(bool showDeactivated);
        Task<HttpResponseViewModel<AssetCategoryModel>> GetAssetCategoryById(int assetCategoryId);
        Task<HttpResponseViewModel<int>> AddAssetCategory(AssetCategoryModel assetCategory);
        Task<HttpResponseViewModel<int>> UpdateAssetCategory(AssetCategoryModel assetCategory);
        Task<HttpResponseViewModel<int>> DeactivateAssetCategory(AssetCategoryModel assetCategory);
        Task<HttpResponseViewModel<int>> ActivateAssetCategory(AssetCategoryModel assetCategory);
        #endregion

        #region Asset Sub Category

        Task<HttpResponseViewModel<IList<AssetSubCategoryViewModel>>> GetAllAssetSubCategories(int assetCategoryId, bool showDeactivated);
        Task<HttpResponseViewModel<AssetSubCategoryModel>> GetAssetSubCategoryById(int assetSubCategoryId);
        Task<HttpResponseViewModel<int>> AddAssetSubCategory(AssetSubCategoryModel assetSubCategory);
        Task<HttpResponseViewModel<int>> UpdateAssetSubCategory(AssetSubCategoryModel assetSubCategory);
        Task<HttpResponseViewModel<int>> DeactivateAssetSubCategory(AssetSubCategoryModel assetSubCategory);
        Task<HttpResponseViewModel<int>> ActivateAssetSubCategory(AssetSubCategoryModel assetSubCategory);
        #endregion
    }
}
