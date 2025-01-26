using AutoMapper;
using SalesDatePrediction.Core.DTO;
using SalesDatePrediction.Core.Entities;
using SalesDatePrediction.Core.RepositoryContracts;
using SalesDatePrediction.Core.ServiceContracts;

namespace SalesDatePrediction.Core.Services;

internal class ProductsService : IProductsService
{
  private readonly IProductsRepository _productsRepository;
  private readonly IMapper _mapper;

  public ProductsService(IProductsRepository productsRepository, IMapper mapper)
  {
    _productsRepository = productsRepository;
    _mapper = mapper;
  }
  public async Task CreateProduct(Product product)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<ProductDTO?>> GetAllProducts()
  {
    IEnumerable<Product?> products = await _productsRepository.GetProductsAsync();

    return _mapper.Map<IEnumerable<ProductDTO?>>(products);
  }
}
