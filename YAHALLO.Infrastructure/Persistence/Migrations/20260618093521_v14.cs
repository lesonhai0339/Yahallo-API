using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YAHALLO.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Country_PhoneCode",
                table: "Country");

            migrationBuilder.AddColumn<int>(
                name: "FaxCode",
                table: "Country",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "VietnameseName",
                table: "Country",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "",
                collation: "Latin1_General_CI_AI");

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Code", "CreateDate", "DeleteDate", "FaxCode", "FullName", "IdUserCreate", "IdUserDelete", "IdUserUpdate", "Name", "PhoneCode", "UpdateDate", "VietnameseName" },
                values: new object[,]
                {
                    { "00000000-0000-0000-0000-000000000001", 1, null, null, 93, "Afghanistan", null, null, null, "AF", 93, null, "Afghanistan" },
                    { "00000000-0000-0000-0000-000000000002", 2, null, null, 358, "Åland Islands", null, null, null, "AX", 358, null, "Quần đảo Åland" },
                    { "00000000-0000-0000-0000-000000000003", 3, null, null, 355, "Albania", null, null, null, "AL", 355, null, "Albania" },
                    { "00000000-0000-0000-0000-000000000004", 4, null, null, 213, "Algeria", null, null, null, "DZ", 213, null, "Algeria" },
                    { "00000000-0000-0000-0000-000000000005", 5, null, null, 1684, "American Samoa", null, null, null, "AS", 1684, null, "Samoa thuộc Mỹ" },
                    { "00000000-0000-0000-0000-000000000006", 6, null, null, 376, "Andorra", null, null, null, "AD", 376, null, "Andorra" },
                    { "00000000-0000-0000-0000-000000000007", 7, null, null, 244, "Angola", null, null, null, "AO", 244, null, "Angola" },
                    { "00000000-0000-0000-0000-000000000008", 8, null, null, 1264, "Anguilla", null, null, null, "AI", 1264, null, "Anguilla" },
                    { "00000000-0000-0000-0000-000000000009", 9, null, null, 672, "Antarctica", null, null, null, "AQ", 672, null, "Nam Cực" },
                    { "00000000-0000-0000-0000-000000000010", 10, null, null, 1268, "Antigua and Barbuda", null, null, null, "AG", 1268, null, "Antigua và Barbuda" },
                    { "00000000-0000-0000-0000-000000000011", 11, null, null, 54, "Argentina", null, null, null, "AR", 54, null, "Argentina" },
                    { "00000000-0000-0000-0000-000000000012", 12, null, null, 374, "Armenia", null, null, null, "AM", 374, null, "Armenia" },
                    { "00000000-0000-0000-0000-000000000013", 13, null, null, 297, "Aruba", null, null, null, "AW", 297, null, "Aruba" },
                    { "00000000-0000-0000-0000-000000000014", 14, null, null, 61, "Australia", null, null, null, "AU", 61, null, "Úc" },
                    { "00000000-0000-0000-0000-000000000015", 15, null, null, 43, "Austria", null, null, null, "AT", 43, null, "Áo" },
                    { "00000000-0000-0000-0000-000000000016", 16, null, null, 994, "Azerbaijan", null, null, null, "AZ", 994, null, "Azerbaijan" },
                    { "00000000-0000-0000-0000-000000000017", 17, null, null, 1242, "Bahamas", null, null, null, "BS", 1242, null, "Bahamas" },
                    { "00000000-0000-0000-0000-000000000018", 18, null, null, 973, "Bahrain", null, null, null, "BH", 973, null, "Bahrain" },
                    { "00000000-0000-0000-0000-000000000019", 19, null, null, 880, "Bangladesh", null, null, null, "BD", 880, null, "Bangladesh" },
                    { "00000000-0000-0000-0000-000000000020", 20, null, null, 1246, "Barbados", null, null, null, "BB", 1246, null, "Barbados" },
                    { "00000000-0000-0000-0000-000000000021", 21, null, null, 375, "Belarus", null, null, null, "BY", 375, null, "Belarus" },
                    { "00000000-0000-0000-0000-000000000022", 22, null, null, 32, "Belgium", null, null, null, "BE", 32, null, "Bỉ" },
                    { "00000000-0000-0000-0000-000000000023", 23, null, null, 501, "Belize", null, null, null, "BZ", 501, null, "Belize" },
                    { "00000000-0000-0000-0000-000000000024", 24, null, null, 229, "Benin", null, null, null, "BJ", 229, null, "Benin" },
                    { "00000000-0000-0000-0000-000000000025", 25, null, null, 1441, "Bermuda", null, null, null, "BM", 1441, null, "Bermuda" },
                    { "00000000-0000-0000-0000-000000000026", 26, null, null, 975, "Bhutan", null, null, null, "BT", 975, null, "Bhutan" },
                    { "00000000-0000-0000-0000-000000000027", 27, null, null, 591, "Bolivia (Plurinational State of)", null, null, null, "BO", 591, null, "Bolivia" },
                    { "00000000-0000-0000-0000-000000000028", 28, null, null, 599, "Bonaire, Sint Eustatius and Saba", null, null, null, "BQ", 599, null, "Bonaire, Sint Eustatius và Saba" },
                    { "00000000-0000-0000-0000-000000000029", 29, null, null, 387, "Bosnia and Herzegovina", null, null, null, "BA", 387, null, "Bosnia và Herzegovina" },
                    { "00000000-0000-0000-0000-000000000030", 30, null, null, 267, "Botswana", null, null, null, "BW", 267, null, "Botswana" },
                    { "00000000-0000-0000-0000-000000000031", 31, null, null, 47, "Bouvet Island", null, null, null, "BV", 47, null, "Đảo Bouvet" },
                    { "00000000-0000-0000-0000-000000000032", 32, null, null, 55, "Brazil", null, null, null, "BR", 55, null, "Brazil" },
                    { "00000000-0000-0000-0000-000000000033", 33, null, null, 246, "British Indian Ocean Territory", null, null, null, "IO", 246, null, "Lãnh thổ Ấn Độ Dương thuộc Anh" },
                    { "00000000-0000-0000-0000-000000000034", 34, null, null, 673, "Brunei Darussalam", null, null, null, "BN", 673, null, "Brunei" },
                    { "00000000-0000-0000-0000-000000000035", 35, null, null, 359, "Bulgaria", null, null, null, "BG", 359, null, "Bulgaria" },
                    { "00000000-0000-0000-0000-000000000036", 36, null, null, 226, "Burkina Faso", null, null, null, "BF", 226, null, "Burkina Faso" },
                    { "00000000-0000-0000-0000-000000000037", 37, null, null, 257, "Burundi", null, null, null, "BI", 257, null, "Burundi" },
                    { "00000000-0000-0000-0000-000000000038", 38, null, null, 238, "Cabo Verde", null, null, null, "CV", 238, null, "Cabo Verde" },
                    { "00000000-0000-0000-0000-000000000039", 39, null, null, 855, "Cambodia", null, null, null, "KH", 855, null, "Campuchia" },
                    { "00000000-0000-0000-0000-000000000040", 40, null, null, 237, "Cameroon", null, null, null, "CM", 237, null, "Cameroon" },
                    { "00000000-0000-0000-0000-000000000041", 41, null, null, 1, "Canada", null, null, null, "CA", 1, null, "Canada" },
                    { "00000000-0000-0000-0000-000000000042", 42, null, null, 1345, "Cayman Islands", null, null, null, "KY", 1345, null, "Quần đảo Cayman" },
                    { "00000000-0000-0000-0000-000000000043", 43, null, null, 236, "Central African Republic", null, null, null, "CF", 236, null, "Cộng hòa Trung Phi" },
                    { "00000000-0000-0000-0000-000000000044", 44, null, null, 235, "Chad", null, null, null, "TD", 235, null, "Tchad" },
                    { "00000000-0000-0000-0000-000000000045", 45, null, null, 56, "Chile", null, null, null, "CL", 56, null, "Chile" },
                    { "00000000-0000-0000-0000-000000000046", 46, null, null, 86, "China", null, null, null, "CN", 86, null, "Trung Quốc" },
                    { "00000000-0000-0000-0000-000000000047", 47, null, null, 61, "Christmas Island", null, null, null, "CX", 61, null, "Đảo Giáng Sinh" },
                    { "00000000-0000-0000-0000-000000000048", 48, null, null, 61, "Cocos (Keeling) Islands", null, null, null, "CC", 61, null, "Quần đảo Cocos" },
                    { "00000000-0000-0000-0000-000000000049", 49, null, null, 57, "Colombia", null, null, null, "CO", 57, null, "Colombia" },
                    { "00000000-0000-0000-0000-000000000050", 50, null, null, 269, "Comoros", null, null, null, "KM", 269, null, "Comoros" },
                    { "00000000-0000-0000-0000-000000000051", 51, null, null, 242, "Congo", null, null, null, "CG", 242, null, "Congo" },
                    { "00000000-0000-0000-0000-000000000052", 52, null, null, 243, "Congo (Democratic Republic of the)", null, null, null, "CD", 243, null, "Cộng hòa Dân chủ Congo" },
                    { "00000000-0000-0000-0000-000000000053", 53, null, null, 682, "Cook Islands", null, null, null, "CK", 682, null, "Quần đảo Cook" },
                    { "00000000-0000-0000-0000-000000000054", 54, null, null, 506, "Costa Rica", null, null, null, "CR", 506, null, "Costa Rica" },
                    { "00000000-0000-0000-0000-000000000055", 55, null, null, 225, "Côte d'Ivoire", null, null, null, "CI", 225, null, "Bờ Biển Ngà" },
                    { "00000000-0000-0000-0000-000000000056", 56, null, null, 385, "Croatia", null, null, null, "HR", 385, null, "Croatia" },
                    { "00000000-0000-0000-0000-000000000057", 57, null, null, 53, "Cuba", null, null, null, "CU", 53, null, "Cuba" },
                    { "00000000-0000-0000-0000-000000000058", 58, null, null, 599, "Curaçao", null, null, null, "CW", 599, null, "Curaçao" },
                    { "00000000-0000-0000-0000-000000000059", 59, null, null, 357, "Cyprus", null, null, null, "CY", 357, null, "Síp" },
                    { "00000000-0000-0000-0000-000000000060", 60, null, null, 420, "Czechia", null, null, null, "CZ", 420, null, "Cộng hòa Séc" },
                    { "00000000-0000-0000-0000-000000000061", 61, null, null, 45, "Denmark", null, null, null, "DK", 45, null, "Đan Mạch" },
                    { "00000000-0000-0000-0000-000000000062", 62, null, null, 253, "Djibouti", null, null, null, "DJ", 253, null, "Djibouti" },
                    { "00000000-0000-0000-0000-000000000063", 63, null, null, 1767, "Dominica", null, null, null, "DM", 1767, null, "Dominica" },
                    { "00000000-0000-0000-0000-000000000064", 64, null, null, 1809, "Dominican Republic", null, null, null, "DO", 1809, null, "Cộng hòa Dominica" },
                    { "00000000-0000-0000-0000-000000000065", 65, null, null, 593, "Ecuador", null, null, null, "EC", 593, null, "Ecuador" },
                    { "00000000-0000-0000-0000-000000000066", 66, null, null, 20, "Egypt", null, null, null, "EG", 20, null, "Ai Cập" },
                    { "00000000-0000-0000-0000-000000000067", 67, null, null, 503, "El Salvador", null, null, null, "SV", 503, null, "El Salvador" },
                    { "00000000-0000-0000-0000-000000000068", 68, null, null, 240, "Equatorial Guinea", null, null, null, "GQ", 240, null, "Guinea Xích Đạo" },
                    { "00000000-0000-0000-0000-000000000069", 69, null, null, 291, "Eritrea", null, null, null, "ER", 291, null, "Eritrea" },
                    { "00000000-0000-0000-0000-000000000070", 70, null, null, 372, "Estonia", null, null, null, "EE", 372, null, "Estonia" },
                    { "00000000-0000-0000-0000-000000000071", 71, null, null, 251, "Ethiopia", null, null, null, "ET", 251, null, "Ethiopia" },
                    { "00000000-0000-0000-0000-000000000072", 72, null, null, 500, "Falkland Islands (Malvinas)", null, null, null, "FK", 500, null, "Quần đảo Falkland" },
                    { "00000000-0000-0000-0000-000000000073", 73, null, null, 298, "Faroe Islands", null, null, null, "FO", 298, null, "Quần đảo Faroe" },
                    { "00000000-0000-0000-0000-000000000074", 74, null, null, 679, "Fiji", null, null, null, "FJ", 679, null, "Fiji" },
                    { "00000000-0000-0000-0000-000000000075", 75, null, null, 358, "Finland", null, null, null, "FI", 358, null, "Phần Lan" },
                    { "00000000-0000-0000-0000-000000000076", 76, null, null, 33, "France", null, null, null, "FR", 33, null, "Pháp" },
                    { "00000000-0000-0000-0000-000000000077", 77, null, null, 594, "French Guiana", null, null, null, "GF", 594, null, "Guyane thuộc Pháp" },
                    { "00000000-0000-0000-0000-000000000078", 78, null, null, 689, "French Polynesia", null, null, null, "PF", 689, null, "Polynesia thuộc Pháp" },
                    { "00000000-0000-0000-0000-000000000079", 79, null, null, 262, "French Southern Territories", null, null, null, "TF", 262, null, "Vùng đất phía Nam thuộc Pháp" },
                    { "00000000-0000-0000-0000-000000000080", 80, null, null, 241, "Gabon", null, null, null, "GA", 241, null, "Gabon" },
                    { "00000000-0000-0000-0000-000000000081", 81, null, null, 220, "Gambia", null, null, null, "GM", 220, null, "Gambia" },
                    { "00000000-0000-0000-0000-000000000082", 82, null, null, 995, "Georgia", null, null, null, "GE", 995, null, "Gruzia" },
                    { "00000000-0000-0000-0000-000000000083", 83, null, null, 49, "Germany", null, null, null, "DE", 49, null, "Đức" },
                    { "00000000-0000-0000-0000-000000000084", 84, null, null, 233, "Ghana", null, null, null, "GH", 233, null, "Ghana" },
                    { "00000000-0000-0000-0000-000000000085", 85, null, null, 350, "Gibraltar", null, null, null, "GI", 350, null, "Gibraltar" },
                    { "00000000-0000-0000-0000-000000000086", 86, null, null, 30, "Greece", null, null, null, "GR", 30, null, "Hy Lạp" },
                    { "00000000-0000-0000-0000-000000000087", 87, null, null, 299, "Greenland", null, null, null, "GL", 299, null, "Greenland" },
                    { "00000000-0000-0000-0000-000000000088", 88, null, null, 1473, "Grenada", null, null, null, "GD", 1473, null, "Grenada" },
                    { "00000000-0000-0000-0000-000000000089", 89, null, null, 590, "Guadeloupe", null, null, null, "GP", 590, null, "Guadeloupe" },
                    { "00000000-0000-0000-0000-000000000090", 90, null, null, 1671, "Guam", null, null, null, "GU", 1671, null, "Guam" },
                    { "00000000-0000-0000-0000-000000000091", 91, null, null, 502, "Guatemala", null, null, null, "GT", 502, null, "Guatemala" },
                    { "00000000-0000-0000-0000-000000000092", 92, null, null, 44, "Guernsey", null, null, null, "GG", 44, null, "Guernsey" },
                    { "00000000-0000-0000-0000-000000000093", 93, null, null, 224, "Guinea", null, null, null, "GN", 224, null, "Guinea" },
                    { "00000000-0000-0000-0000-000000000094", 94, null, null, 245, "Guinea-Bissau", null, null, null, "GW", 245, null, "Guinea-Bissau" },
                    { "00000000-0000-0000-0000-000000000095", 95, null, null, 592, "Guyana", null, null, null, "GY", 592, null, "Guyana" },
                    { "00000000-0000-0000-0000-000000000096", 96, null, null, 509, "Haiti", null, null, null, "HT", 509, null, "Haiti" },
                    { "00000000-0000-0000-0000-000000000097", 97, null, null, 672, "Heard Island and McDonald Islands", null, null, null, "HM", 672, null, "Đảo Heard và McDonald" },
                    { "00000000-0000-0000-0000-000000000098", 98, null, null, 379, "Holy See", null, null, null, "VA", 379, null, "Tòa Thánh Vatican" },
                    { "00000000-0000-0000-0000-000000000099", 99, null, null, 504, "Honduras", null, null, null, "HN", 504, null, "Honduras" },
                    { "00000000-0000-0000-0000-000000000100", 100, null, null, 852, "Hong Kong", null, null, null, "HK", 852, null, "Hồng Kông" },
                    { "00000000-0000-0000-0000-000000000101", 101, null, null, 36, "Hungary", null, null, null, "HU", 36, null, "Hungary" },
                    { "00000000-0000-0000-0000-000000000102", 102, null, null, 354, "Iceland", null, null, null, "IS", 354, null, "Iceland" },
                    { "00000000-0000-0000-0000-000000000103", 103, null, null, 91, "India", null, null, null, "IN", 91, null, "Ấn Độ" },
                    { "00000000-0000-0000-0000-000000000104", 104, null, null, 62, "Indonesia", null, null, null, "ID", 62, null, "Indonesia" },
                    { "00000000-0000-0000-0000-000000000105", 105, null, null, 98, "Iran (Islamic Republic of)", null, null, null, "IR", 98, null, "Iran" },
                    { "00000000-0000-0000-0000-000000000106", 106, null, null, 964, "Iraq", null, null, null, "IQ", 964, null, "Iraq" },
                    { "00000000-0000-0000-0000-000000000107", 107, null, null, 353, "Ireland", null, null, null, "IE", 353, null, "Ireland" },
                    { "00000000-0000-0000-0000-000000000108", 108, null, null, 44, "Isle of Man", null, null, null, "IM", 44, null, "Đảo Man" },
                    { "00000000-0000-0000-0000-000000000109", 109, null, null, 972, "Israel", null, null, null, "IL", 972, null, "Israel" },
                    { "00000000-0000-0000-0000-000000000110", 110, null, null, 39, "Italy", null, null, null, "IT", 39, null, "Ý" },
                    { "00000000-0000-0000-0000-000000000111", 111, null, null, 1876, "Jamaica", null, null, null, "JM", 1876, null, "Jamaica" },
                    { "00000000-0000-0000-0000-000000000112", 112, null, null, 81, "Japan", null, null, null, "JP", 81, null, "Nhật Bản" },
                    { "00000000-0000-0000-0000-000000000113", 113, null, null, 44, "Jersey", null, null, null, "JE", 44, null, "Jersey" },
                    { "00000000-0000-0000-0000-000000000114", 114, null, null, 962, "Jordan", null, null, null, "JO", 962, null, "Jordan" },
                    { "00000000-0000-0000-0000-000000000115", 115, null, null, 7, "Kazakhstan", null, null, null, "KZ", 7, null, "Kazakhstan" },
                    { "00000000-0000-0000-0000-000000000116", 116, null, null, 254, "Kenya", null, null, null, "KE", 254, null, "Kenya" },
                    { "00000000-0000-0000-0000-000000000117", 117, null, null, 686, "Kiribati", null, null, null, "KI", 686, null, "Kiribati" },
                    { "00000000-0000-0000-0000-000000000118", 118, null, null, 850, "Korea (Democratic People's Republic of)", null, null, null, "KP", 850, null, "Triều Tiên" },
                    { "00000000-0000-0000-0000-000000000119", 119, null, null, 82, "Korea (Republic of)", null, null, null, "KR", 82, null, "Hàn Quốc" },
                    { "00000000-0000-0000-0000-000000000120", 120, null, null, 965, "Kuwait", null, null, null, "KW", 965, null, "Kuwait" },
                    { "00000000-0000-0000-0000-000000000121", 121, null, null, 996, "Kyrgyzstan", null, null, null, "KG", 996, null, "Kyrgyzstan" },
                    { "00000000-0000-0000-0000-000000000122", 122, null, null, 856, "Lao People's Democratic Republic", null, null, null, "LA", 856, null, "Lào" },
                    { "00000000-0000-0000-0000-000000000123", 123, null, null, 371, "Latvia", null, null, null, "LV", 371, null, "Latvia" },
                    { "00000000-0000-0000-0000-000000000124", 124, null, null, 961, "Lebanon", null, null, null, "LB", 961, null, "Liban" },
                    { "00000000-0000-0000-0000-000000000125", 125, null, null, 266, "Lesotho", null, null, null, "LS", 266, null, "Lesotho" },
                    { "00000000-0000-0000-0000-000000000126", 126, null, null, 231, "Liberia", null, null, null, "LR", 231, null, "Liberia" },
                    { "00000000-0000-0000-0000-000000000127", 127, null, null, 218, "Libya", null, null, null, "LY", 218, null, "Libya" },
                    { "00000000-0000-0000-0000-000000000128", 128, null, null, 423, "Liechtenstein", null, null, null, "LI", 423, null, "Liechtenstein" },
                    { "00000000-0000-0000-0000-000000000129", 129, null, null, 370, "Lithuania", null, null, null, "LT", 370, null, "Litva" },
                    { "00000000-0000-0000-0000-000000000130", 130, null, null, 352, "Luxembourg", null, null, null, "LU", 352, null, "Luxembourg" },
                    { "00000000-0000-0000-0000-000000000131", 131, null, null, 853, "Macao", null, null, null, "MO", 853, null, "Ma Cao" },
                    { "00000000-0000-0000-0000-000000000132", 132, null, null, 389, "Macedonia (the former Yugoslav Republic of)", null, null, null, "MK", 389, null, "Bắc Macedonia" },
                    { "00000000-0000-0000-0000-000000000133", 133, null, null, 261, "Madagascar", null, null, null, "MG", 261, null, "Madagascar" },
                    { "00000000-0000-0000-0000-000000000134", 134, null, null, 265, "Malawi", null, null, null, "MW", 265, null, "Malawi" },
                    { "00000000-0000-0000-0000-000000000135", 135, null, null, 60, "Malaysia", null, null, null, "MY", 60, null, "Malaysia" },
                    { "00000000-0000-0000-0000-000000000136", 136, null, null, 960, "Maldives", null, null, null, "MV", 960, null, "Maldives" },
                    { "00000000-0000-0000-0000-000000000137", 137, null, null, 223, "Mali", null, null, null, "ML", 223, null, "Mali" },
                    { "00000000-0000-0000-0000-000000000138", 138, null, null, 356, "Malta", null, null, null, "MT", 356, null, "Malta" },
                    { "00000000-0000-0000-0000-000000000139", 139, null, null, 692, "Marshall Islands", null, null, null, "MH", 692, null, "Quần đảo Marshall" },
                    { "00000000-0000-0000-0000-000000000140", 140, null, null, 596, "Martinique", null, null, null, "MQ", 596, null, "Martinique" },
                    { "00000000-0000-0000-0000-000000000141", 141, null, null, 222, "Mauritania", null, null, null, "MR", 222, null, "Mauritania" },
                    { "00000000-0000-0000-0000-000000000142", 142, null, null, 230, "Mauritius", null, null, null, "MU", 230, null, "Mauritius" },
                    { "00000000-0000-0000-0000-000000000143", 143, null, null, 262, "Mayotte", null, null, null, "YT", 262, null, "Mayotte" },
                    { "00000000-0000-0000-0000-000000000144", 144, null, null, 52, "Mexico", null, null, null, "MX", 52, null, "Mexico" },
                    { "00000000-0000-0000-0000-000000000145", 145, null, null, 691, "Micronesia (Federated States of)", null, null, null, "FM", 691, null, "Micronesia" },
                    { "00000000-0000-0000-0000-000000000146", 146, null, null, 373, "Moldova (Republic of)", null, null, null, "MD", 373, null, "Moldova" },
                    { "00000000-0000-0000-0000-000000000147", 147, null, null, 377, "Monaco", null, null, null, "MC", 377, null, "Monaco" },
                    { "00000000-0000-0000-0000-000000000148", 148, null, null, 976, "Mongolia", null, null, null, "MN", 976, null, "Mông Cổ" },
                    { "00000000-0000-0000-0000-000000000149", 149, null, null, 382, "Montenegro", null, null, null, "ME", 382, null, "Montenegro" },
                    { "00000000-0000-0000-0000-000000000150", 150, null, null, 1664, "Montserrat", null, null, null, "MS", 1664, null, "Montserrat" },
                    { "00000000-0000-0000-0000-000000000151", 151, null, null, 212, "Morocco", null, null, null, "MA", 212, null, "Maroc" },
                    { "00000000-0000-0000-0000-000000000152", 152, null, null, 258, "Mozambique", null, null, null, "MZ", 258, null, "Mozambique" },
                    { "00000000-0000-0000-0000-000000000153", 153, null, null, 95, "Myanmar", null, null, null, "MM", 95, null, "Myanmar" },
                    { "00000000-0000-0000-0000-000000000154", 154, null, null, 264, "Namibia", null, null, null, "NA", 264, null, "Namibia" },
                    { "00000000-0000-0000-0000-000000000155", 155, null, null, 674, "Nauru", null, null, null, "NR", 674, null, "Nauru" },
                    { "00000000-0000-0000-0000-000000000156", 156, null, null, 977, "Nepal", null, null, null, "NP", 977, null, "Nepal" },
                    { "00000000-0000-0000-0000-000000000157", 157, null, null, 31, "Netherlands", null, null, null, "NL", 31, null, "Hà Lan" },
                    { "00000000-0000-0000-0000-000000000158", 158, null, null, 687, "New Caledonia", null, null, null, "NC", 687, null, "New Caledonia" },
                    { "00000000-0000-0000-0000-000000000159", 159, null, null, 64, "New Zealand", null, null, null, "NZ", 64, null, "New Zealand" },
                    { "00000000-0000-0000-0000-000000000160", 160, null, null, 505, "Nicaragua", null, null, null, "NI", 505, null, "Nicaragua" },
                    { "00000000-0000-0000-0000-000000000161", 161, null, null, 227, "Niger", null, null, null, "NE", 227, null, "Niger" },
                    { "00000000-0000-0000-0000-000000000162", 162, null, null, 234, "Nigeria", null, null, null, "NG", 234, null, "Nigeria" },
                    { "00000000-0000-0000-0000-000000000163", 163, null, null, 683, "Niue", null, null, null, "NU", 683, null, "Niue" },
                    { "00000000-0000-0000-0000-000000000164", 164, null, null, 672, "Norfolk Island", null, null, null, "NF", 672, null, "Đảo Norfolk" },
                    { "00000000-0000-0000-0000-000000000165", 165, null, null, 1670, "Northern Mariana Islands", null, null, null, "MP", 1670, null, "Quần đảo Bắc Mariana" },
                    { "00000000-0000-0000-0000-000000000166", 166, null, null, 47, "Norway", null, null, null, "NO", 47, null, "Na Uy" },
                    { "00000000-0000-0000-0000-000000000167", 167, null, null, 968, "Oman", null, null, null, "OM", 968, null, "Oman" },
                    { "00000000-0000-0000-0000-000000000168", 168, null, null, 92, "Pakistan", null, null, null, "PK", 92, null, "Pakistan" },
                    { "00000000-0000-0000-0000-000000000169", 169, null, null, 680, "Palau", null, null, null, "PW", 680, null, "Palau" },
                    { "00000000-0000-0000-0000-000000000170", 170, null, null, 970, "Palestine, State of", null, null, null, "PS", 970, null, "Palestine" },
                    { "00000000-0000-0000-0000-000000000171", 171, null, null, 507, "Panama", null, null, null, "PA", 507, null, "Panama" },
                    { "00000000-0000-0000-0000-000000000172", 172, null, null, 675, "Papua New Guinea", null, null, null, "PG", 675, null, "Papua New Guinea" },
                    { "00000000-0000-0000-0000-000000000173", 173, null, null, 595, "Paraguay", null, null, null, "PY", 595, null, "Paraguay" },
                    { "00000000-0000-0000-0000-000000000174", 174, null, null, 51, "Peru", null, null, null, "PE", 51, null, "Peru" },
                    { "00000000-0000-0000-0000-000000000175", 175, null, null, 63, "Philippines", null, null, null, "PH", 63, null, "Philippines" },
                    { "00000000-0000-0000-0000-000000000176", 176, null, null, 64, "Pitcairn", null, null, null, "PN", 64, null, "Quần đảo Pitcairn" },
                    { "00000000-0000-0000-0000-000000000177", 177, null, null, 48, "Poland", null, null, null, "PL", 48, null, "Ba Lan" },
                    { "00000000-0000-0000-0000-000000000178", 178, null, null, 351, "Portugal", null, null, null, "PT", 351, null, "Bồ Đào Nha" },
                    { "00000000-0000-0000-0000-000000000179", 179, null, null, 1787, "Puerto Rico", null, null, null, "PR", 1787, null, "Puerto Rico" },
                    { "00000000-0000-0000-0000-000000000180", 180, null, null, 974, "Qatar", null, null, null, "QA", 974, null, "Qatar" },
                    { "00000000-0000-0000-0000-000000000181", 181, null, null, 262, "Réunion", null, null, null, "RE", 262, null, "Réunion" },
                    { "00000000-0000-0000-0000-000000000182", 182, null, null, 40, "Romania", null, null, null, "RO", 40, null, "Romania" },
                    { "00000000-0000-0000-0000-000000000183", 183, null, null, 7, "Russian Federation", null, null, null, "RU", 7, null, "Nga" },
                    { "00000000-0000-0000-0000-000000000184", 184, null, null, 250, "Rwanda", null, null, null, "RW", 250, null, "Rwanda" },
                    { "00000000-0000-0000-0000-000000000185", 185, null, null, 590, "Saint Barthélemy", null, null, null, "BL", 590, null, "Saint Barthélemy" },
                    { "00000000-0000-0000-0000-000000000186", 186, null, null, 290, "Saint Helena, Ascension and Tristan da Cunha", null, null, null, "SH", 290, null, "Saint Helena" },
                    { "00000000-0000-0000-0000-000000000187", 187, null, null, 1869, "Saint Kitts and Nevis", null, null, null, "KN", 1869, null, "Saint Kitts và Nevis" },
                    { "00000000-0000-0000-0000-000000000188", 188, null, null, 1758, "Saint Lucia", null, null, null, "LC", 1758, null, "Saint Lucia" },
                    { "00000000-0000-0000-0000-000000000189", 189, null, null, 590, "Saint Martin (French part)", null, null, null, "MF", 590, null, "Saint Martin (phần thuộc Pháp)" },
                    { "00000000-0000-0000-0000-000000000190", 190, null, null, 508, "Saint Pierre and Miquelon", null, null, null, "PM", 508, null, "Saint Pierre và Miquelon" },
                    { "00000000-0000-0000-0000-000000000191", 191, null, null, 1784, "Saint Vincent and the Grenadines", null, null, null, "VC", 1784, null, "Saint Vincent và Grenadines" },
                    { "00000000-0000-0000-0000-000000000192", 192, null, null, 685, "Samoa", null, null, null, "WS", 685, null, "Samoa" },
                    { "00000000-0000-0000-0000-000000000193", 193, null, null, 378, "San Marino", null, null, null, "SM", 378, null, "San Marino" },
                    { "00000000-0000-0000-0000-000000000194", 194, null, null, 239, "Sao Tome and Principe", null, null, null, "ST", 239, null, "São Tomé và Príncipe" },
                    { "00000000-0000-0000-0000-000000000195", 195, null, null, 966, "Saudi Arabia", null, null, null, "SA", 966, null, "Ả Rập Xê Út" },
                    { "00000000-0000-0000-0000-000000000196", 196, null, null, 221, "Senegal", null, null, null, "SN", 221, null, "Senegal" },
                    { "00000000-0000-0000-0000-000000000197", 197, null, null, 381, "Serbia", null, null, null, "RS", 381, null, "Serbia" },
                    { "00000000-0000-0000-0000-000000000198", 198, null, null, 248, "Seychelles", null, null, null, "SC", 248, null, "Seychelles" },
                    { "00000000-0000-0000-0000-000000000199", 199, null, null, 232, "Sierra Leone", null, null, null, "SL", 232, null, "Sierra Leone" },
                    { "00000000-0000-0000-0000-000000000200", 200, null, null, 65, "Singapore", null, null, null, "SG", 65, null, "Singapore" },
                    { "00000000-0000-0000-0000-000000000201", 201, null, null, 1721, "Sint Maarten (Dutch part)", null, null, null, "SX", 1721, null, "Sint Maarten (phần thuộc Hà Lan)" },
                    { "00000000-0000-0000-0000-000000000202", 202, null, null, 421, "Slovakia", null, null, null, "SK", 421, null, "Slovakia" },
                    { "00000000-0000-0000-0000-000000000203", 203, null, null, 386, "Slovenia", null, null, null, "SI", 386, null, "Slovenia" },
                    { "00000000-0000-0000-0000-000000000204", 204, null, null, 677, "Solomon Islands", null, null, null, "SB", 677, null, "Quần đảo Solomon" },
                    { "00000000-0000-0000-0000-000000000205", 205, null, null, 252, "Somalia", null, null, null, "SO", 252, null, "Somalia" },
                    { "00000000-0000-0000-0000-000000000206", 206, null, null, 27, "South Africa", null, null, null, "ZA", 27, null, "Nam Phi" },
                    { "00000000-0000-0000-0000-000000000207", 207, null, null, 500, "South Georgia and the South Sandwich Islands", null, null, null, "GS", 500, null, "Nam Georgia và Quần đảo Nam Sandwich" },
                    { "00000000-0000-0000-0000-000000000208", 208, null, null, 211, "South Sudan", null, null, null, "SS", 211, null, "Nam Sudan" },
                    { "00000000-0000-0000-0000-000000000209", 209, null, null, 34, "Spain", null, null, null, "ES", 34, null, "Tây Ban Nha" },
                    { "00000000-0000-0000-0000-000000000210", 210, null, null, 94, "Sri Lanka", null, null, null, "LK", 94, null, "Sri Lanka" },
                    { "00000000-0000-0000-0000-000000000211", 211, null, null, 249, "Sudan", null, null, null, "SD", 249, null, "Sudan" },
                    { "00000000-0000-0000-0000-000000000212", 212, null, null, 597, "Suriname", null, null, null, "SR", 597, null, "Suriname" },
                    { "00000000-0000-0000-0000-000000000213", 213, null, null, 47, "Svalbard and Jan Mayen", null, null, null, "SJ", 47, null, "Svalbard và Jan Mayen" },
                    { "00000000-0000-0000-0000-000000000214", 214, null, null, 268, "Swaziland", null, null, null, "SZ", 268, null, "Eswatini" },
                    { "00000000-0000-0000-0000-000000000215", 215, null, null, 46, "Sweden", null, null, null, "SE", 46, null, "Thụy Điển" },
                    { "00000000-0000-0000-0000-000000000216", 216, null, null, 41, "Switzerland", null, null, null, "CH", 41, null, "Thụy Sĩ" },
                    { "00000000-0000-0000-0000-000000000217", 217, null, null, 963, "Syrian Arab Republic", null, null, null, "SY", 963, null, "Syria" },
                    { "00000000-0000-0000-0000-000000000218", 218, null, null, 886, "Taiwan, Province of China", null, null, null, "TW", 886, null, "Đài Loan" },
                    { "00000000-0000-0000-0000-000000000219", 219, null, null, 992, "Tajikistan", null, null, null, "TJ", 992, null, "Tajikistan" },
                    { "00000000-0000-0000-0000-000000000220", 220, null, null, 255, "Tanzania, United Republic of", null, null, null, "TZ", 255, null, "Tanzania" },
                    { "00000000-0000-0000-0000-000000000221", 221, null, null, 66, "Thailand", null, null, null, "TH", 66, null, "Thái Lan" },
                    { "00000000-0000-0000-0000-000000000222", 222, null, null, 670, "Timor-Leste", null, null, null, "TL", 670, null, "Đông Timor" },
                    { "00000000-0000-0000-0000-000000000223", 223, null, null, 228, "Togo", null, null, null, "TG", 228, null, "Togo" },
                    { "00000000-0000-0000-0000-000000000224", 224, null, null, 690, "Tokelau", null, null, null, "TK", 690, null, "Tokelau" },
                    { "00000000-0000-0000-0000-000000000225", 225, null, null, 676, "Tonga", null, null, null, "TO", 676, null, "Tonga" },
                    { "00000000-0000-0000-0000-000000000226", 226, null, null, 1868, "Trinidad and Tobago", null, null, null, "TT", 1868, null, "Trinidad và Tobago" },
                    { "00000000-0000-0000-0000-000000000227", 227, null, null, 216, "Tunisia", null, null, null, "TN", 216, null, "Tunisia" },
                    { "00000000-0000-0000-0000-000000000228", 228, null, null, 90, "Turkey", null, null, null, "TR", 90, null, "Thổ Nhĩ Kỳ" },
                    { "00000000-0000-0000-0000-000000000229", 229, null, null, 993, "Turkmenistan", null, null, null, "TM", 993, null, "Turkmenistan" },
                    { "00000000-0000-0000-0000-000000000230", 230, null, null, 1649, "Turks and Caicos Islands", null, null, null, "TC", 1649, null, "Quần đảo Turks và Caicos" },
                    { "00000000-0000-0000-0000-000000000231", 231, null, null, 688, "Tuvalu", null, null, null, "TV", 688, null, "Tuvalu" },
                    { "00000000-0000-0000-0000-000000000232", 232, null, null, 256, "Uganda", null, null, null, "UG", 256, null, "Uganda" },
                    { "00000000-0000-0000-0000-000000000233", 233, null, null, 380, "Ukraine", null, null, null, "UA", 380, null, "Ukraine" },
                    { "00000000-0000-0000-0000-000000000234", 234, null, null, 971, "United Arab Emirates", null, null, null, "AE", 971, null, "Các Tiểu vương quốc Ả Rập Thống nhất" },
                    { "00000000-0000-0000-0000-000000000235", 235, null, null, 44, "United Kingdom of Great Britain and Northern Ireland", null, null, null, "GB", 44, null, "Vương quốc Anh" },
                    { "00000000-0000-0000-0000-000000000236", 236, null, null, 1, "United States of America", null, null, null, "US", 1, null, "Hoa Kỳ" },
                    { "00000000-0000-0000-0000-000000000237", 237, null, null, 1, "United States Minor Outlying Islands", null, null, null, "UM", 1, null, "Các đảo nhỏ xa của Hoa Kỳ" },
                    { "00000000-0000-0000-0000-000000000238", 238, null, null, 598, "Uruguay", null, null, null, "UY", 598, null, "Uruguay" },
                    { "00000000-0000-0000-0000-000000000239", 239, null, null, 998, "Uzbekistan", null, null, null, "UZ", 998, null, "Uzbekistan" },
                    { "00000000-0000-0000-0000-000000000240", 240, null, null, 678, "Vanuatu", null, null, null, "VU", 678, null, "Vanuatu" },
                    { "00000000-0000-0000-0000-000000000241", 241, null, null, 58, "Venezuela (Bolivarian Republic of)", null, null, null, "VE", 58, null, "Venezuela" },
                    { "00000000-0000-0000-0000-000000000242", 242, null, null, 84, "Viet Nam", null, null, null, "VN", 84, null, "Việt Nam" },
                    { "00000000-0000-0000-0000-000000000243", 243, null, null, 1284, "Virgin Islands (British)", null, null, null, "VG", 1284, null, "Quần đảo Virgin thuộc Anh" },
                    { "00000000-0000-0000-0000-000000000244", 244, null, null, 1340, "Virgin Islands (U.S.)", null, null, null, "VI", 1340, null, "Quần đảo Virgin thuộc Mỹ" },
                    { "00000000-0000-0000-0000-000000000245", 245, null, null, 681, "Wallis and Futuna", null, null, null, "WF", 681, null, "Wallis và Futuna" },
                    { "00000000-0000-0000-0000-000000000246", 246, null, null, 212, "Western Sahara", null, null, null, "EH", 212, null, "Tây Sahara" },
                    { "00000000-0000-0000-0000-000000000247", 247, null, null, 967, "Yemen", null, null, null, "YE", 967, null, "Yemen" },
                    { "00000000-0000-0000-0000-000000000248", 248, null, null, 260, "Zambia", null, null, null, "ZM", 260, null, "Zambia" },
                    { "00000000-0000-0000-0000-000000000249", 249, null, null, 263, "Zimbabwe", null, null, null, "ZW", 263, null, "Zimbabwe" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Country_PhoneCode",
                table: "Country",
                column: "PhoneCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Country_PhoneCode",
                table: "Country");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000003");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000004");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000005");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000006");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000007");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000008");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000009");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000010");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000011");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000012");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000013");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000014");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000015");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000016");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000017");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000018");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000019");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000020");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000021");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000022");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000023");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000024");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000025");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000026");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000027");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000028");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000029");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000030");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000031");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000032");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000033");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000034");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000035");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000036");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000037");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000038");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000039");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000040");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000041");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000042");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000043");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000044");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000045");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000046");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000047");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000048");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000049");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000050");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000051");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000052");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000053");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000054");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000055");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000056");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000057");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000058");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000059");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000060");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000061");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000062");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000063");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000064");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000065");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000066");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000067");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000068");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000069");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000070");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000071");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000072");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000073");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000074");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000075");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000076");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000077");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000078");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000079");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000080");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000081");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000082");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000083");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000084");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000085");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000086");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000087");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000088");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000089");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000090");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000091");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000092");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000093");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000094");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000095");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000096");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000097");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000098");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000099");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000100");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000101");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000102");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000103");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000104");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000105");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000106");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000107");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000108");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000109");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000110");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000111");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000112");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000113");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000114");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000115");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000116");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000117");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000118");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000119");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000120");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000121");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000122");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000123");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000124");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000125");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000126");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000127");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000128");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000129");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000130");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000131");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000132");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000133");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000134");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000135");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000136");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000137");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000138");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000139");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000140");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000141");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000142");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000143");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000144");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000145");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000146");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000147");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000148");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000149");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000150");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000151");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000152");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000153");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000154");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000155");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000156");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000157");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000158");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000159");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000160");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000161");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000162");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000163");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000164");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000165");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000166");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000167");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000168");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000169");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000170");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000171");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000172");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000173");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000174");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000175");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000176");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000177");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000178");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000179");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000180");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000181");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000182");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000183");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000184");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000185");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000186");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000187");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000188");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000189");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000190");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000191");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000192");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000193");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000194");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000195");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000196");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000197");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000198");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000199");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000200");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000201");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000202");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000203");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000204");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000205");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000206");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000207");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000208");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000209");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000210");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000211");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000212");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000213");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000214");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000215");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000216");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000217");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000218");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000219");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000220");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000221");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000222");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000223");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000224");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000225");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000226");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000227");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000228");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000229");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000230");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000231");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000232");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000233");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000234");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000235");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000236");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000237");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000238");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000239");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000240");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000241");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000242");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000243");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000244");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000245");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000246");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000247");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000248");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000249");

            migrationBuilder.DropColumn(
                name: "FaxCode",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "VietnameseName",
                table: "Country");

            migrationBuilder.CreateIndex(
                name: "IX_Country_PhoneCode",
                table: "Country",
                column: "PhoneCode",
                unique: true);
        }
    }
}
