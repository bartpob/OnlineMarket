using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.Categories
{
    public sealed class Category(string Name)
    {
        private readonly List<Category> _subCategories = new();
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; private set; } = Name;

        public IReadOnlyCollection<Category> SubCategories => _subCategories.AsReadOnly();
        public void AddCategory(Category category)
        {
            _subCategories.Add(category);
        }

        public void Update(string Name)
        {
            this.Name = Name;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _subCategories
            .Concat(_subCategories.SelectMany(subCategory => subCategory.GetAllCategories()))
            .Prepend(this);
        }
    }
}
