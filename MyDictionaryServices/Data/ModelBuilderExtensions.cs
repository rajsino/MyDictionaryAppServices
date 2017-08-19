using Microsoft.EntityFrameworkCore;

namespace MyDictionaryServices.Data
{
    static class ModelBuilderExtensions
    {
        public static void SetStringMaxLengthConvention(this ModelBuilder builder, int len)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    if (property.ClrType == typeof(string))
                    {
                        property.SetMaxLength(255);
                    }
                }
            }
        }
    }
}
