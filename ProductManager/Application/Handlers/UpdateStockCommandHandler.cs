using Application.Commands;
using Application.Presentation;
using Application.Shared;
using Application.Shared.Commands;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.Aggregate;
using Domain.Repositories;
using Domain.Shared;
using Microsoft.AspNetCore.Identity;
using System.Text;

namespace Application.Handlers
{
    public class UpdateStockCommandHandler : ICommandHandler<UpdateStockCommand, BaseResponse<UpdateStockResponse>>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UpdateStockCommandHandler(
            IUnitOfWork unitOfWork,
            IRepositoryWrapper repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<UpdateStockResponse>> Handle(UpdateStockCommand command, CancellationToken cancellationToken)
        {

            var product = (await _repository.Product.FindByCondition(product => product.Id == command.ProductId)).FirstOrDefault();

            if (product != null) throw new ProductNotFoundException("Product ID does not exist");

            product.Quantity -= command.Quantity;

            await _repository.Product.Update(product);

            await _repository.Save();


            return BaseResponse<UpdateStockResponse>.Success("Stock updated Successful", new UpdateStockResponse()
            {
                ProductId = product.Id,
                Quantity = command.Quantity
            }, statusCode: 200);
        }
    }
}
