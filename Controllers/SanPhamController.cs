
using DemoMVC.Data;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly AppDbContext _context;

        public SanPhamController(AppDbContext context)
        {
            _context = context;
        }

        // Danh sách sản phẩm
        public async Task<IActionResult> Index()
        {
            var sanPhams = await _context.SanPhams
                .AsNoTracking()
                .ToListAsync();

            return View(sanPhams);
        }

        // Chi tiết sản phẩm
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var sanPham = await _context.SanPhams
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (sanPham == null)
                return NotFound();

            return View(sanPham);
        }

        // Hiển thị form thêm
        public IActionResult Create()
        {
            return View();
        }

        // Lưu sản phẩm mới
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SanPham sanPham)
        {
            if (!ModelState.IsValid)
                return View(sanPham);

            _context.SanPhams.Add(sanPham);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Hiển thị form sửa
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var sanPham = await _context.SanPhams.FindAsync(id);

            if (sanPham == null)
                return NotFound();

            return View(sanPham);
        }

        // Lưu thông tin đã sửa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SanPham sanPham)
        {
            if (id != sanPham.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(sanPham);

            _context.SanPhams.Update(sanPham);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // Xác nhận trước khi xóa
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var sanPham = await _context.SanPhams
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);

            if (sanPham == null)
                return NotFound();

            return View(sanPham);
        }

        // Thực hiện xóa
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);

            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
