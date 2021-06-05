using Newtonsoft.Json;
using PromotionEngine.Common;
using PromotionEngine.Model;
using System.Collections.Generic;
using System.IO;

namespace PromotionEngine.Data.SKUs
{
    public class SKURepository : ISKURepository
    {
        public List<SKU> GetAvailableSKU()
        {
            var appDirectotry = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(appDirectotry, Constant.SKUFilePath);
            return JsonConvert.DeserializeObject<List<SKU>>(File.ReadAllText(filePath));
        }
    }
}
