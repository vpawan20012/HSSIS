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
        
        Task<HttpResponseViewModel<IList<AssetCategoryModel>>> GetAllAssetCategories();
        Task<HttpResponseViewModel<AssetCategoryModel>> GetAssetCategoryById(int assetCategoryId);
        Task<HttpResponseViewModel<AssetCategoryModel>> GetAssetCategoryByName(string assetCategoryName);
        #endregion

        #region Asset Sub Category

        Task<HttpResponseViewModel<IList<AssetSubCategoryViewModel>>> GetAllAssetSubCategories(int assetCategoryId);
        #endregion
    }
}
