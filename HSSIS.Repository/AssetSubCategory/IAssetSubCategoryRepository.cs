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
        Task<IList<AssetSubCategoryViewModel>> GetAllAssetSubCategories(int assetCategoryId);
    }
}
