using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;
using System.Text.RegularExpressions;

namespace YAHALLO.Common
{
    public class StrictDateTimeOffsetBinder : IModelBinder
    {
        private static readonly Regex IsoWithOffset = new Regex(
             @"^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(\.\d{1,7})?(Zz|[+-]\d{2}:?\d{2})$",
             RegexOptions.Compiled);
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).FirstValue;

            if (string.IsNullOrEmpty(value))
                return Task.CompletedTask;

            if(!IsoWithOffset.IsMatch(value)||
               !DateTimeOffset.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, @"
""Timestamp phải là ISO 8601 kèm offset, VD: 2026-07-20T09:30:00+07:00 hoặc ...Z""
");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }

    }
    public class StrictDateTimeOffsetBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            var type = context.Metadata.ModelType;
            if(type == typeof(DateTimeOffset) || type == typeof(DateTimeOffset?)) 
                return new StrictDateTimeOffsetBinder();    

            return null;    
        }
    }
}
