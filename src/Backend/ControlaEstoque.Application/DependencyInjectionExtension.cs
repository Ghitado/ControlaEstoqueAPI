using ControlaEstoque.Application.UseCases.Product.Delete;
using ControlaEstoque.Application.UseCases.Product.Get;
using ControlaEstoque.Application.UseCases.Product.GetById;
using ControlaEstoque.Application.UseCases.Product.Register;
using ControlaEstoque.Application.UseCases.Product.Update;
using ControlaEstoque.Application.UseCases.Product.Updates;
using ControlaEstoque.Application.UseCases.Sale.Delete;
using ControlaEstoque.Application.UseCases.Sale.Get;
using ControlaEstoque.Application.UseCases.Sale.GetById;
using ControlaEstoque.Application.UseCases.Sale.Register;
using ControlaEstoque.Application.UseCases.Sale.Update;
using Microsoft.Extensions.DependencyInjection;

namespace ControlaEstoque.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterProductUseCase, RegisterProductUseCase>();
            services.AddScoped<IGetProductsUseCase, GetProductsUseCase>();
            services.AddScoped<IGetProductByIdUseCase, GetProductByIdUseCase>();
            services.AddScoped<IUpdateProductUseCase, UpdateProductUseCase>();
            services.AddScoped<IUpdateProductsUseCase, UpdateProductsUseCase>();
            services.AddScoped<IDeleteProductUseCase, DeleteProductUseCase>();

            services.AddScoped<IRegisterSaleUseCase, RegisterSaleUseCase>();
            services.AddScoped<IGetSalesUseCase, GetSalesUseCase>();
            services.AddScoped<IGetSaleByIdUseCase, GetSaleByIdUseCase>();
            services.AddScoped<IUpdateSaleUseCase, UpdateSaleUseCase>();
            services.AddScoped<IDeleteSaleUseCase, DeleteSaleUseCase>();
        }
    }
}
