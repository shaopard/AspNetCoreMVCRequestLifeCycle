using Microsoft.AspNetCore.Mvc.ModelBinding;
using SampleMVCRequestLifeCycle.Models;
using System.Collections.Generic;

namespace SampleMVCRequestLifeCycle.Model_Binding
{
    public class CSVModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(List<Order>))
            {
                return new CSVModelBinder();
            }

            return null;
        }
    }
}
