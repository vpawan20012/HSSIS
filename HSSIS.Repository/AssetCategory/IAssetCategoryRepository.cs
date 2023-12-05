using HSSIS.Data.DataContext;
using HSSIS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSSIS.Repository.AssetCategory
{
    public interface IAssetCategoryRepository
    {
        Task<IList<AssetCategoryModel>> GetAllAssetCategories();  
    }
}
