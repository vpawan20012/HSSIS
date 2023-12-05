using System;
using System.Collections.Generic;

namespace HSSIS.Data.DataContext;

public partial class TblMasterAssetCategory
{
    public int AssetCategoryId { get; set; }

    public string? AssetCategoryName { get; set; }

    public string? Description { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? DeleteFlag { get; set; }
}
