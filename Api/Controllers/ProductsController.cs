﻿using Business.Abstract;
using Core.Dtos;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _service;

		public ProductsController(IProductService service)
		{
			_service = service;
		}
		/// GET api/products
		[HttpGet]
		[Authorize]
		public IActionResult GetAllWithPaging([FromQuery]PageInputDto pageInputDto)
		{
			var products = _service.GetProductWithPaging(pageInputDto);
			return Ok(products);
		}
		/// POST api/products
		[HttpPost]
		[Authorize]
		public IActionResult AddProduct([FromBody] ProductAddDto productAddDto)
		{
			var products = _service.AddProduct(productAddDto);
			//test
			return Ok(products);
		}
		[HttpGet("qr-code")]
		[Authorize]
		public IActionResult GetProductQrCode([FromQuery] long productId)
		{
			var qrcode = _service.QrCodeToProduct(productId);
			return qrcode.Success ? File(qrcode.Data, "image/png") : BadRequest(qrcode);
		}
		[HttpPut("stock")]
		[Authorize]
		public IActionResult UpdateProductStock([FromBody] UpdateProductStockDto updateProductStockDto)
		{
			var result = _service.UpdateProductStock(updateProductStockDto);
			return Ok(result);
		}
	}
}
