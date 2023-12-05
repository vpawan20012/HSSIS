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
        Task<HttpResponseViewModel<IList<AssetCategoryModel>>> GetAllAssetCategories();
        Task<HttpResponseViewModel<IList<AssetSubCategoryViewModel>>> GetAllAssetSubCategories(int assetCategoryId);
    }
}
