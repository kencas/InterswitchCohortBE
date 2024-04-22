using Application.Commands;
using Application.Presentation;
using Application.Shared;
using Application.Shared.Commands;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.Repositories;

namespace Application.Handlers
{
    public class CheckoutCommandHandler : ICommandHandler<CheckoutCommand, BaseResponse<CheckoutResponse>>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CheckoutCommandHandler(
            IUnitOfWork unitOfWork,
            IRepositoryWrapper repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CheckoutResponse>> Handle(CheckoutCommand command, CancellationToken cancellationToken)
        {

            //var product = (await _repository.Product.FindByCondition(product => product.Id == command.ProductId)).FirstOrDefault();

            //if (product != null) throw new ProductNotFoundException("Product ID does not exist");

            //product.Quantity -= command.Quantity;

            //await _repository.Product.Update(product);

            //await _repository.Save();


            return BaseResponse<CheckoutResponse>.Success("Stock updated Successful", new CheckoutResponse()
            {
                
            }, statusCode: 200);
        }
    }
}
