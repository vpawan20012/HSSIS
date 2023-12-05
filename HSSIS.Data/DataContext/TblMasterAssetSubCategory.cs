using System;
using System.Collections.Generic;

namespace HSSIS.Data.DataContext;

public partial class TblMasterAssetSubCategory
{
    public int AssetSubCategoryId { get; set; }

    public int? AssetCategoryId { get; set; }

    public string? AssetSubCategoryName { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? DeleteFlag { get; set; }

    public string? De { get; set; }
}
