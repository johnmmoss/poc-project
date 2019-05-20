using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace StatementsTracker.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static IList<TEntity> EnumHasData<TEnum, TEntity>(this ModelBuilder modelBuilder) where TEntity : class
        {
            var entities = new List<TEntity>();
            var enums = Enum.GetValues(typeof(TEnum));
            foreach (var e in enums)
            {
                var id = e;
                var description = e.GetEnumDescription();
                var name = e.ToString();

                var instance = (TEntity)Activator.CreateInstance(typeof(TEntity));

                var idProperty = instance.GetType().GetProperty("Id");
                var nameProperty = instance.GetType().GetProperty("Name");
                var descriptionProperty = instance.GetType().GetProperty("Description");

                idProperty.SetValue(instance, id);
                nameProperty.SetValue(instance, name);
                descriptionProperty.SetValue(instance, description);

                entities.Add(instance);
            }

            modelBuilder.Entity<TEntity>().HasData(
                entities.ToArray()
                );

            return entities;
        }
    }
}
