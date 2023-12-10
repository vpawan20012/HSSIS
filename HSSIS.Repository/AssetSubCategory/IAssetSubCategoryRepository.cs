using HSSIS.Models.DataModels;
using HSSIS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Repository.AssetSubCategory
{
    public interface IAssetSubCategoryRepository
    {
        Task<IList<AssetSubCategoryViewModel>> GetAllAssetSubCategories(int assetCategoryId,bool showDeactivated);
        Task<AssetSubCategoryModel> GetAssetSubCategoryById(int assetSubCategoryId);
        AssetSubCategoryModel GetAssetSubCategoryByName(string assetSubCategoryName);
        Task<int> AddAssetSubCategory(AssetSubCategoryModel assetSubCategory);
        Task<int> UpdateAssetSubCategory(AssetSubCategoryModel assetSubCategory);
        Task<int> DeactivateAssetSubCategory(AssetSubCategoryModel assetSubCategory);
        Task<int> ActivateAssetSubCategory(AssetSubCategoryModel assetSubCategory);
    }
}
