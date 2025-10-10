using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ErrorOr;

using Generita.Application.Common.Interfaces.Repository;
using Generita.Application.Common.Messaging;

namespace Generita.Application.Books.Queries.GetAllBookCategories
{
    public class GetAllBookCategoriesHandler : IQueryHandler<GetAllBookCategoriesQuery, ICollection<GetAllBookCategoriesResponse>>
    {
        private IBookCategoryRepository _categoryRepository;

        public GetAllBookCategoriesHandler(IBookCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ErrorOr<ICollection<GetAllBookCategoriesResponse>>> Handle(GetAllBookCategoriesQuery request, CancellationToken cancellationToken)
        {
            var response = await _categoryRepository.GetAll();
            return response.Select(x=>new GetAllBookCategoriesResponse() { Id=x.Id,CategoryName=x.CategoryName}).DistinctBy(x=>x.CategoryName).ToList();
        }
    }
}
