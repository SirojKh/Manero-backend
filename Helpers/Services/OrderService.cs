using Manero_Backend.Helpers.Factory;
using Manero_Backend.Models.Entities;
using Manero_Backend.Models.Interfaces.Repositories;
using Manero_Backend.Models.Interfaces.Services;
using Manero_Backend.Models.Schemas.Order;
using Microsoft.AspNetCore.Mvc;

namespace Manero_Backend.Helpers.Services
{
    public class OrderService : BaseService<OrderEntity>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPromoCodeService _promoCodeService;
        private readonly IUserPromoCodeService _userPromoCodeService;
        private readonly IAddressService _addressService;
        private readonly IPaymentDetailService _paymentDetailService;
        private readonly IProductService _productService;
        private readonly IProductColorService _productColorService;
        private readonly IOrderProductsService _orderProductsService;
        private readonly IOrderStatusRepository _orderStatusRepository;
        public OrderService(IOrderRepository orderRepository, IPromoCodeService promoCodeService, IUserPromoCodeService userPromoCodeService, IAddressService addressService, IPaymentDetailService paymentDetailService, IProductService productService, IProductColorService productColorService, IOrderProductsService orderProductsService, IOrderStatusRepository orderStatusRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _promoCodeService = promoCodeService;
            _userPromoCodeService = userPromoCodeService;
            _addressService = addressService;
            _paymentDetailService = paymentDetailService;
            _productService = productService;
            _productColorService = productColorService;
            _orderProductsService = orderProductsService;
            _orderStatusRepository = orderStatusRepository;
        }

        public async Task<IActionResult> CreateAsync(OrderSchema schema, string userId)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var orderProduct in schema.OrderProducts)
            {
                if (!set.Add(orderProduct.ProductId + "" + orderProduct.SizeId + "" + orderProduct.ColorId))
                    return HttpResultFactory.BadRequest(new { ErrorMessage = "Duplicate in order products, please use quantity." });
            }

            set.Clear();

            if (!await _paymentDetailService.ExistsAsync(x => x.Id == schema.PaymentDetailId && x.AppUserId == userId))
                return HttpResultFactory.BadRequest(new { ErrorMessage = "Invalid Id/s 1" });

            if (!await _addressService.ExistsAsync(x => x.Id == schema.AddressId && x.AppUserId == userId))
                return HttpResultFactory.BadRequest(new { ErrorMessage = "Invalid Id/s 2" });
            
            PromoCodeEntity promoCode = null; 
            UserPromoCodeEntity userPromoCode = null; 

            if(schema.PromoCodeId != null)
            {
                promoCode = await _promoCodeService.GetValidateAsync((Guid)schema.PromoCodeId);
                if (promoCode == null)
                    return HttpResultFactory.BadRequest(new {ErrorMessage = "Invalid Id/s 3"});

                userPromoCode = await _userPromoCodeService.GetAsync((Guid)schema.PromoCodeId, userId);
                if(userPromoCode != null)
                {
                    if (userPromoCode.Used)
                        return HttpResultFactory.BadRequest(new {ErrorMessage = "User has already used this promocode."});
                }
            }
            
            var productIds = schema.OrderProducts.Select(x => x.ProductId).Distinct().ToList();
            if(await _productService.CountAsync(x => productIds.Contains(x.Id)) != productIds.Count)
                return HttpResultFactory.BadRequest(new { ErrorMessage = "Invalid Id/s 4" });


            foreach(var orderPoduct in schema.OrderProducts)
            {
                bool exists = await _productService.ExistsAsync(x => 
                x.ProductColors.Where(y => y.ProductId == orderPoduct.ProductId && y.ColorId == orderPoduct.ColorId).Count() != 0
                && x.ProductSizes.Where(z => z.ProductId == orderPoduct.ProductId && z.SizeId == orderPoduct.SizeId).Count() != 0);

                if(!exists)
                    return HttpResultFactory.BadRequest(new { ErrorMessage = "Invalid Id/s 5" });
            }


            //Add Order
            OrderEntity orderEntity = schema;
            orderEntity.AppUserId = userId;

            IEnumerable<ProductEntity> productEntities = await _productService.GetAllAsync(x => productIds.Contains(x.Id));

            decimal sum = 0m;
            foreach(var product in productEntities)
            {
                int totalQuantity = schema.OrderProducts.Where(x => x.ProductId == product.Id).Sum(x => x.Quantity);
                decimal price = product.Price * totalQuantity;

                if(promoCode != null)
                {
                    if(promoCode.CompanyId == product.CompanyId)
                    {
                        sum += price - (price * promoCode.Discount);
                        continue;
                    }
                }

                sum += price;
            }

            orderEntity.TotalPrice = sum;

            await _orderRepository.CreateAsync(orderEntity);

            await _orderProductsService.AddRangedAsync(schema.OrderProducts.Select(x => new OrderProductEntity() { OrderId = orderEntity.Id, ProductId = x.ProductId, ColorId = x.ColorId, SizeId = x.SizeId, Quantity = x.Quantity }).ToList());

            List<OrderStatusEntity> orderStatues = new List<OrderStatusEntity>();

            orderStatues.Add(new OrderStatusEntity()
            {
                OrderId = orderEntity.Id,
                OrderStatusTypeId = Guid.Parse("ca596a28-4009-4d29-f379-08db5a0e0d5a"),
                Completed = true,
                CompletedUnix = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                EstimatedTimeUnix = 0
            });
            orderStatues.Add(new OrderStatusEntity()
            {
                OrderId = orderEntity.Id,
                OrderStatusTypeId = Guid.Parse("087a61ce-318f-436e-f37a-08db5a0e0d5a"),
                Completed = true,
                CompletedUnix = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                EstimatedTimeUnix = 0
            });
            orderStatues.Add(new OrderStatusEntity()
            {
                OrderId = orderEntity.Id,
                OrderStatusTypeId = Guid.Parse("547fe825-7621-4b28-f37b-08db5a0e0d5a"),
                Completed = false,
                CompletedUnix = 0,
                EstimatedTimeUnix = DateTimeOffset.UtcNow.AddDays(1).ToUnixTimeSeconds()
            });
            orderStatues.Add(new OrderStatusEntity()
            {
                OrderId = orderEntity.Id,
                OrderStatusTypeId = Guid.Parse("1e915510-4161-4443-f37c-08db5a0e0d5a"),
                Completed = false,
                CompletedUnix = 0,
                EstimatedTimeUnix = DateTimeOffset.UtcNow.AddDays(4).ToUnixTimeSeconds()
            });
            orderStatues.Add(new OrderStatusEntity()
            {
                OrderId = orderEntity.Id,
                OrderStatusTypeId = Guid.Parse("00ad9bdf-55db-4959-f37d-08db5a0e0d5a"),
                Completed = false,
                CompletedUnix = 0,
                EstimatedTimeUnix = DateTimeOffset.UtcNow.AddDays(7).ToUnixTimeSeconds()
            });

            await _orderStatusRepository.AddRangedAsync(orderStatues);


            //update or add userpromocode.
            if(promoCode != null)
            {
                if(userPromoCode != null) //patch
                {
                    userPromoCode.Used = true;
                    await _userPromoCodeService.UpdateAsync(userPromoCode);
                }

                if(userPromoCode == null) //Add med used
                {
                    await _userPromoCodeService.CreateAsync(new UserPromoCodeEntity() { AppUserId = userId, PromoCodeId = promoCode.Id, Used = true });
                }
            }


            return HttpResultFactory.Created("","");

        }


    }
}
