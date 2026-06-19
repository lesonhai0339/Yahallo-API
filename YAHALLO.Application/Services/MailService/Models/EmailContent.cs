using System.Collections.Generic;

namespace YAHALLO.Application.Services.MailService.Models
{
    // Các field nhập từ form -> dùng để build HTML body (an toàn, không nhúng HTML thô).
    public class EmailContent
    {
        // Tiêu đề lớn (bắt buộc).
        public string Heading { get; set; } = string.Empty;

        // Phụ đề (tùy chọn).
        public string? SubHeading { get; set; }

        // Ảnh banner hiển thị đầu body (tùy chọn).
        public string? BannerImageUrl { get; set; }

        // Các đoạn nội dung (mỗi phần tử là 1 <p>).
        public List<string> Paragraphs { get; set; } = new List<string>();

        // Nút CTA (tùy chọn) — cần cả 2 field thì nút mới hiện.
        public string? ButtonText { get; set; }
        public string? ButtonUrl { get; set; }

        // Ghi chú thêm ở cuối body (tùy chọn).
        public string? FooterNote { get; set; }
    }
}
