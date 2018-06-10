using System.Threading.Tasks;
using AutoMapper;
using IdGenerator.Core;
using IdGenerator.Core.Repository;
using IdGenerator.Infrastructure.Services;
using Moq;
using Xunit;

namespace IdGenerator.Test.Unit
{
    public class CategoryServiceXTests
    {
        readonly ICategoryService _categoryService;
        readonly Mock<ICategoryRepository> _categoryRepositoryMock;

        public CategoryServiceXTests()
        {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _categoryService = new CategoryService(new Mock<IMapper>().Object, _categoryRepositoryMock.Object);
        }

        [Fact]
        public async Task Should_Return_Category_When_Exist_In_Repository()
        {
            _categoryRepositoryMock.Setup(s => s.GetAsync("7777")).ReturnsAsync(new Category("7777", "Things"));

            var category = await _categoryService.GetAsync("7777");

            Assert.Equal("7777", category.Id);
            Assert.Equal("Things", category.Name);
        }
    }
}
