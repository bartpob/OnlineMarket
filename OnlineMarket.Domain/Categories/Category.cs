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
        public Guid Id { get; init; }
        public string Name { get; init; } = Name;

        public IReadOnlyCollection<Category> SubCategories => _subCategories.AsReadOnly();
        public void AddCategory(Category category)
        {
            _subCategories.Add(category);
        }
    }
}
