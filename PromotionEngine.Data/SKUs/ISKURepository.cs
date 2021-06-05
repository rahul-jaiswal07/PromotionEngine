using PromotionEngine.Model;
using System.Collections.Generic;

namespace PromotionEngine.Data.SKUs
{
    public interface ISKURepository
    {
        List<SKU> GetAvailableSKU();
    }
}
