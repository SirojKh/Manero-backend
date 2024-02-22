using Manero_Backend.Helpers.Factory;
using Manero_Backend.Helpers.Repositories;
using Manero_Backend.Models.Dtos.Address;
using Manero_Backend.Models.Dtos.PaymentDetail;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Manero_Backend.Helpers.Services
{
    public class PaymentDetailService : BaseService<PaymentDetailEntity>, IPaymentDetailService
    {
        private readonly IPaymentDetailRepository _paymentDetailRepository;

        public PaymentDetailService(IPaymentDetailRepository paymentDetailRepository) : base(paymentDetailRepository)
        {
            _paymentDetailRepository = paymentDetailRepository;
        }

        public async Task<IActionResult> CreateAsync(PaymentDetailEntity entity, string userId)
        {
            entity.AppUserId = userId;

            await _paymentDetailRepository.CreateAsync(entity);

            return HttpResultFactory.Created("", "");
        }

        public async Task<IActionResult> RemoveAsync(Guid paymentDetailId, string userId)
        {
            PaymentDetailEntity entity = await _paymentDetailRepository.GetAsync(paymentDetailId, userId);
            if (entity == null)
                return HttpResultFactory.NotFound("");

            await _paymentDetailRepository.RemoveAsync(entity);

            return HttpResultFactory.NoContent();
        }

        public async Task<IActionResult> GetAllAsync(string userId)
        {
            return HttpResultFactory.Ok((await _paymentDetailRepository.GetUserPaymentDetailsAsync(userId)).Select(x => (PaymentDetailDto)x));
        }

        public async Task<IActionResult> PutAsync(PaymentDetailEntity entity, string userId)
        {
            PaymentDetailEntity originalEntity = await _paymentDetailRepository.GetAsync(entity.Id, userId);
            if (originalEntity == null)
                return HttpResultFactory.NotFound("");

            originalEntity.Id = entity.Id;
            originalEntity.CardNumber = entity.CardNumber;
            originalEntity.CardName = entity.CardName;
            originalEntity.Cvv = entity.Cvv;
            originalEntity.ExpDate = entity.ExpDate;



            await _paymentDetailRepository.UpdateAsync(originalEntity);

            return HttpResultFactory.NoContent();
        }

    }
}
