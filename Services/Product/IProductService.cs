// IProductService.cs

using DTOs.Create;
using DTOs.Display;
using DTOs.Update;
using System.Collections.Generic;

namespace Services.Order
{
    public interface IProductService
    {
        List<GetProductDTO> GetAll();
        GetProductDTO GetOne(int ProductId);
        ReturnProduct Create(CreateProductDTO product);
        List<GetProductDTO> Delete(int ProductId);
        ReturnProduct Update(UpdateProduct product, int ProductId);
    }
}
