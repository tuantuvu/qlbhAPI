using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using qlbhAPI.Models.Entity;
using qlbhAPI.Models.Khoa;
using System.Text.Json;

namespace qlbhAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KhoaController : ControllerBase
	{
		private readonly QuanLyBanHoaContext _context;
		public KhoaController(QuanLyBanHoaContext context)
		{
			_context = context;
		}

		[HttpGet("danh-sach-khoa")]
		public IActionResult DanhSachKhoa()
		{
			var items = _context.Khoas
				.Select(c => new OutputKhoa()
				{
					Id = c.Id,
					MaKhoa = c.MaKhoa,
					TenKhoa = c.TenKhoa,
					Sdt = c.Sdt,
					//UrlImages = c.UrlImages,
				})
				.ToList();
			return Ok(items);
		}

		//api get 1 data
		[HttpGet("thong-tin-khoa/{id}")]
		public IActionResult ItemKhoa(string id)
		{
			var item = _context.Khoas.FirstOrDefault(x => x.Id == id);
			return Ok(item);
		}

		//api delete 1 data
		[HttpDelete("xoa-khoa/{id}")]
		public IActionResult XoaKhoa(string id)
		{
			var item = _context.Khoas.FirstOrDefault(x => x.Id == id);
			if (item != null)
			{
				_context.Khoas.Remove(item);
				_context.SaveChanges();
			}
			return Ok();
		}

		//api post data
		[HttpPost("them-moi-khoa")]
		//public IActionResult TaoKhoa(InputKhoa input)
		public IActionResult TaoKhoa([FromForm] InputKhoa input)
		{
			if (ModelState.IsValid)
			{
				Khoa khoa = new Khoa();
				khoa.Id = Guid.NewGuid().ToString();
				khoa.MaKhoa = input.MaKhoa;
				khoa.TenKhoa = input.TenKhoa;
				khoa.Sdt = input.SDT;
				khoa.Filter = input.MaKhoa + " " + input.TenKhoa;

				//List<OutputImage> listimage = new List<OutputImage>();
				//foreach (var img in input.Images)
				//{
				//	OutputImage output = new OutputImage();
				//	output.UrlImage = UploadFiles.SaveImage(img);
				//	output.Position = 1;
				//	listimage.Add(output);
				//}
				//khoa.UrlImages = JsonSerializer.Serialize(listimage);

				_context.Khoas.Add(khoa);
				_context.SaveChanges();
				return Ok();
			}
			return BadRequest();
		}

		//api put data
		[HttpPut("cap-nhat-khoa/{id}")]
		public IActionResult CapNhat(Guid id, [FromForm] UpdateKhoa input)
		{
			var item = _context.Khoas.FirstOrDefault(c => c.Id == id.ToString());
			if (item != null)
			{
				item.MaKhoa = input.MaKhoa;
				item.TenKhoa = input.TenKhoa;
				item.Sdt = input.SDT;
				item.Filter = input.MaKhoa + " " + input.TenKhoa;

				_context.Khoas.Update(item);
				_context.SaveChanges();
				return Ok(item);
			}
			return NotFound();
		}
	}
}
