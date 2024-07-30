using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using YAHALLO.Domain.Functions;

namespace YAHALLO.Infrastructure.Functions
{
    public class Enums: IEnums
    {
        //Lấy lớp từ enum có gí trị trùng với tên lớp
        //Get class from enum have same namse with class
        public Type? GetClassFromEnum(Enum enumValue)
        {
            // Lấy tên lớp tương ứng với giá trị Enum
            // Get class name match with enum value
            string? className = Enum.GetName(enumValue.GetType(), enumValue);

            if (className == null) return null;
            //tìm kiểu dữ liệu trong assemblies và namespace
            //find class type in assemblies and namespace
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.Name.Equals(className, StringComparison.OrdinalIgnoreCase))
                    {
                        //var instance = Activator.CreateInstance(type);
                        return type;
                    }
                }
            }
            return null;
        }
    }
}
