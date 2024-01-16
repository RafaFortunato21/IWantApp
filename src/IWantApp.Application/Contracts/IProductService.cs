using IWantApp.Application.DTO;
using IWantApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IWantApp.Application.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetProducts();
        Task<ProductResponse> GetById(Guid productId);

        Task<ProductResponse> Add(ProductRequest productRequestDTO, string userCreate);
        //Task Update(ProductUpdateDTO category, Guid categoryId, string userUpdate);
        
    }
}
