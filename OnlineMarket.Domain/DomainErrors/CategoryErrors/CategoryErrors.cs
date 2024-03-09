using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Domain.DomainErrors.CategoryErrors
{
    public static class CategoryErrors
    {
        public static readonly Error CategoryNotExists = new Error("CATEGORY_NOT_EXISTS", "Given id is not suitable for any category.");
        public static readonly Error EmptyName = new Error("EMPTY_NAME", "Name can't be empty.");
        public static readonly Error NameTaken = new Error("NAME_TAKEN", "Category name is already taken.");
    }
}
