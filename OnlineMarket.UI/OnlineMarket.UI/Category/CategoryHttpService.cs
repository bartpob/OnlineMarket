using Azure;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using OnlineMarket.Application.Categories.AddCategory;
using OnlineMarket.Application.Categories.AddSubcategory;
using OnlineMarket.Application.Categories.EditCategory;
using OnlineMarket.Application.Categories.GetAllCategories;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.UI.Abstractions;
using System.Net.Http.Json;

namespace OnlineMarket.UI.Category
{
    public class CategoryHttpService
        : BaseHttpService, ICategoryHttpService
    {
        public CategoryHttpService(HttpClient httpClient, ILocalStorageService localStorageService) 
            : base(httpClient, localStorageService)
        {
        }

        public async Task<Result> DeleteCategory(Guid Id)
        {
            await AttachBearerToken();

            var result = await HttpClient.DeleteAsync($"Category/{Id}");

            if(result.IsSuccessStatusCode)
            {
                return Result.Succeeded();
            }
            else
            {
                string responseBody = await result.Content.ReadAsStringAsync();

                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result.Failure(error);
            }
        }

        public async Task<Result<IEnumerable<CategoryResponse>>> GetCategories()
        {
            var result = await HttpClient.GetAsync("Category/");

            string responseBody = await result.Content.ReadAsStringAsync();
            if(result.IsSuccessStatusCode)
            {
                IEnumerable<CategoryResponse> response = JsonConvert.DeserializeObject<IEnumerable<CategoryResponse>>(responseBody)!;
                return Result<IEnumerable<CategoryResponse>>.Succeeded(response);
            }
            else
            {
                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result<IEnumerable<CategoryResponse>>.Failure(error);
            }
        }

        public async Task<Result> GetCategoryById(Guid Id)
        {
            var result = await HttpClient.GetAsync($"Category/{Id}");

            string responseBody = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                CategoryResponse response = JsonConvert.DeserializeObject<CategoryResponse>(responseBody)!;
                return Result<CategoryResponse>.Succeeded(response);
            }
            else
            {
                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result<CategoryResponse>.Failure(error);
            }
        }

        public async Task<Result> PostCategory(AddCategoryCommand request)
        {
            await AttachBearerToken();

            var result = await HttpClient.PostAsJsonAsync<AddCategoryCommand>($"Category/", request);

            if (result.IsSuccessStatusCode)
            {
                return Result.Succeeded();
            }
            else
            {
                string responseBody = await result.Content.ReadAsStringAsync();

                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result.Failure(error);
            }
        }

        public async Task<Result> PostSubCategory(Guid Id, AddSubcategoryRequest request)
        {
            await AttachBearerToken();

            var result = await HttpClient.PostAsJsonAsync<AddSubcategoryRequest>($"Category/{Id}", request);

            if (result.IsSuccessStatusCode)
            {
                return Result.Succeeded();
            }
            else
            {
                string responseBody = await result.Content.ReadAsStringAsync();

                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result.Failure(error);
            }
        }

        public async Task<Result> PutCategory(Guid Id, UpdateCategoryCommandRequest request)
        {
            await AttachBearerToken();

            var result = await HttpClient.PutAsJsonAsync<UpdateCategoryCommandRequest>($"Category/{Id}", request);

            if (result.IsSuccessStatusCode)
            {
                return Result.Succeeded();
            }
            else
            {
                string responseBody = await result.Content.ReadAsStringAsync();

                Error error = JsonConvert.DeserializeObject<Error>(responseBody)!;
                return Result.Failure(error);
            }
        }
    }
}
