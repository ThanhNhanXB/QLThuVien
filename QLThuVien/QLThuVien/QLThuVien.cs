/*
 * Đồ Án Quản Lý Thư Viện 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Text.RegularExpressions;
namespace QLThuVien
{
    class QLThuVien
    {
        static void Main(string[] args)
        {


            //khai báo 
            //const string pathSach = "D:\\project\\CTDL\\QLThuVien\\QLThuVien\\QLThuVien\\data\\sach.txt";
            //const string pathPhieuMuon = "D:\\project\\CTDL\\QLThuVien\\QLThuVien\\QLThuVien\\data\\phieumuon.txt";
            //const string pathAddmin = "D:\\project\\CTDL\\QLThuVien\\QLThuVien\\QLThuVien\\data\\admin.txt";
            //const string pathBanDoc = "";





            bool dungChuongTrinh = false;

            //đăng nhập thư viện 
            if (DangNhap(pathAddmin) == true)
            {
                //Đăng nhập thành công, chọn chức năng 
                while (!dungChuongTrinh)
                {
                    dungChuongTrinh = false;
                    GiaoDien.ManHinhChon();
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.KeyChar)
                    {
                        case '1':
                            Console.Clear();
                            dungChuongTrinh = QuanLySach(pathSach);

                            break;
                        case '2':
                            Console.Clear();
                            dungChuongTrinh = QuanLyPhieuMuon(pathPhieuMuon);

                            break;
                        default:
                            if (key.Key == ConsoleKey.Escape)
                            {
                                Console.Clear();
                                GiaoDien.DungChuongTrinh();
                                return;
                            }
                            Console.Clear();
                            break;
                    }
                }
            }
            Console.ReadKey();
        }



        /// <summary>
        /// Hàm đăng nhập  
        /// </summary>
        /// <returns></returns>
        static bool DangNhap(string path)
        {
            //khai bao 
            const int SOLANSAI = 3;
            string user = "###", pass = "###";
            bool check = false;
            bool checkString = false;
            Regex rangBuoc = new Regex("^[a-zA-Z0-9]+$");
            ConsoleKeyInfo maHoa = new ConsoleKeyInfo();

            GiaoDien.DangNhap();
            for (int i = 0; i < SOLANSAI; i++)
            {
                //nhập username 
                do
                {
                    //Báo lỗi khi nhập username rỗng 
                    if (user == "")
                    {
                        Console.Clear();
                        GiaoDien.DangNhap();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("       Vui Lòng Điền Username\n       ".PadLeft(Console.WindowWidth / 2 + 36 / 2));
                        Console.ResetColor();
                    }
                    //báo lỗi khi nhập kí tự không hợp lệ 
                    if (user == "error")
                    {
                        Console.Clear();
                        GiaoDien.DangNhap();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("    Username Chỉ Gồm Chữ Và Số      \n".PadLeft(Console.WindowWidth / 2 + 36 / 2));
                        Console.ResetColor();
                    }
                    Console.Write("Username: ".PadLeft(Console.WindowWidth / 3 + 8));
                    user = Console.ReadLine();
                    if (user == "")
                    {
                        user = "";
                    }
                    //kiểm tra chuỗi bằng biểu thức chính quy 
                    else if (!rangBuoc.IsMatch(user))
                    {
                        user = "error";
                    }
                } while (user == "" || user == "error");

                //nhập password 
                do
                {
                    //Báo lỗi khi nhập password rỗng 
                    if (pass == "")
                    {
                        Console.Clear();
                        GiaoDien.DangNhap();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("       Vui Lòng Điền Password\n       ".PadLeft(Console.WindowWidth / 2 + 36 / 2));
                        Console.ResetColor();
                        Console.WriteLine("Username: ".PadLeft(Console.WindowWidth / 3 + 8) + user);
                    }
                    pass = "";
                    Console.Write("Password: ".PadLeft(Console.WindowWidth / 3 + 8));

                    //Mã hóa mật khẩu thành dấu *
                    do
                    {
                        maHoa = new ConsoleKeyInfo();
                        maHoa = Console.ReadKey(true);
                        if (char.IsLetterOrDigit(maHoa.KeyChar))
                        {
                            pass += maHoa.KeyChar;
                            Console.Write('*');
                        }
                        if (maHoa.Key == ConsoleKey.Backspace && pass.Length >= 0)
                        {
                            pass = pass.Remove(pass.Length - 1);
                            Console.Write("\b \b");
                        }

                    } while (maHoa.Key != ConsoleKey.Enter);

                } while (pass == "");
                //Kiểm tra chuỗi username, password trong hệ thống 
                check = KiemTraDangNhap(path, user, pass);
                if (check == false)
                {
                    Console.Clear();
                    GiaoDien.DangNhapThatBai();
                    check = false;
                }
                else
                {
                    Console.Clear();
                    GiaoDien.DangNhapThanhCong();
                    return true;
                }
            }
            Console.WriteLine("--------- Đã Nhập Sai 3 Lần --------\n".PadLeft(Console.WindowWidth / 2 + 36 / 2));
            return false;
        }
        /// <summary>
        ///Kiểm tra username và password 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        static bool KiemTraDangNhap(string path, string user, string pass)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split('#');
                        if (line[0] == user && line[1] == pass)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("khong the mo file");
            }
            return false;
        }

        /// <summary>
        /// Chức năng quản lý sách 
        /// </summary>
        /// <returns></returns>
        static bool QuanLySach(string path)
        {
            //Khai báo 

            while (true)
            {
                GiaoDien.MenuSach();
                ConsoleKeyInfo phimChon = Console.ReadKey(true);
                switch (phimChon.KeyChar)
                {
                    //Hiển Thị sách 
                    case '1':
                        Console.Clear();
                        GiaoDien.HienThiSach();
                        DanhSachSach dsSach = new DanhSachSach();
                        //dsPhieuMuon.Doc(@"..\..\..\..\data\phieumuon.txt");
                        dsSach.Doc(path);
                        dsSach.HienThiDSSach();
                        Console.Write("       Ấn Phím bất Kỳ Để Trở Về     \n".PadLeft(Console.WindowWidth / 2 + 36 / 2));
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    //Thêm sách 
                    case '2':
                        Console.Clear();
                        GiaoDien.ThemSach();

                        break;
                    //Xóa sách 
                    case '3':
                        Console.Clear();
                        GiaoDien.XoaSach();

                        break;
                    //trở về 
                    case '4':
                        Console.Clear();
                        return false;
                        break;
                    default:
                        if (phimChon.Key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            GiaoDien.DungChuongTrinh();
                            return true;
                        }
                        Console.Clear();
                        break;

                }
            }
        }
        /// <summary>
        /// Chức năng quản lý phiếu mượn 
        /// </summary>
        /// <returns></returns>
        static bool QuanLyPhieuMuon(string path)
        {
            DanhSachPhieuMuon dsPhieuMuon = new DanhSachPhieuMuon();
            while (true)
            {
                GiaoDien.MenuPhieuMuon();
                ConsoleKeyInfo phimChon = Console.ReadKey(true);
                switch (phimChon.KeyChar)
                {
                    //Hiển thị phiếu mượn 
                    case '1':
                        Console.Clear();
                        GiaoDien.HienThiPhieu();

                        //dsPhieuMuon.Doc(@"..\..\..\..\data\phieumuon.txt");
                        dsPhieuMuon.Doc(path);
                        dsPhieuMuon.HienThiDSPhieuMuon();
                        Console.Write("       Ấn Phím bất Kỳ Để Trở Về     \n".PadLeft(Console.WindowWidth / 2 + 36 / 2));
                        Console.ReadKey(true);
                        Console.Clear();
                        break;
                    //Mượn sách 
                    case '2':
                        Console.Clear();
                        GiaoDien.MuonSach();
                        MuonSach(dsPhieuMuon, path);
                        break;
                    //Trả Sách 
                    case '3':
                        Console.Clear();
                        GiaoDien.TraSach();
                        TraSach(path);
                        break;
                    //Trở về 
                    case '4':
                        Console.Clear();
                        return false;
                        break;
                    default:
                        if (phimChon.Key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            GiaoDien.DungChuongTrinh();
                            return true;
                        }
                        Console.Clear();
                        break;
                }
            }
        }
        /// <summary>
        /// hàm mượn sách
        /// </summary>
        /// <param name="path"></param>
        static void MuonSach(DanhSachPhieuMuon danhSachPhieuMuon, string path)
        {
            // Đọc dữ liệu từ file để tạo số thứ tự phiếu mượn mới
            int soThuTuPhieuMuon = LaySoThuTuPhieuMuon(path);

            // Nhập thông tin mượn sách từ người dùng
            string maBanDoc;
            do
            {
                Console.Write("Nhập mã bạn đọc: ");
                maBanDoc = Console.ReadLine();

                if (!KiemTraMaBanDocTonTai(maBanDoc))
                {
                    Console.WriteLine("Mã bạn đọc không tồn tại. Vui lòng nhập lại!");
                }
            } while (!KiemTraMaBanDocTonTai(maBanDoc));

            Console.Write("Nhập mã sách: ");
            string maSach = Console.ReadLine();

            // Kiểm tra tình trạng sách
            if (KiemTraSach(maSach))
            {
                // Tiếp tục xử lý mượn sách
                DateTime ngayMuon = DateTime.Now;
                DateTime ngayPhaiTra = ngayMuon.AddDays(7);
                int tinhTrangPhieuMuon = soThuTuPhieuMuon; // Cập nhật tình trạng sách thành số thứ tự phiếu mượn

                // Tạo đối tượng Phiếu Mượn mới
                PhieuMuon phieuMuon = new PhieuMuon(soThuTuPhieuMuon, maBanDoc, maSach, ngayMuon, ngayPhaiTra, tinhTrangPhieuMuon);

                // Tăng số thứ tự phiếu mượn mới lên 1
                soThuTuPhieuMuon++;

                // Thêm phiếu mượn mới vào danh sách
                danhSachPhieuMuon.L.AddLast(phieuMuon);

                // Ghi danh sách phiếu mượn sau khi cập nhật vào file
                danhSachPhieuMuon.Ghi(path);

                // Cập nhật tình trạng phiếu mượn và tình trạng sách
                CapNhatTinhTrangPhieuMuon(soThuTuPhieuMuon);
                CapNhatTinhTrangSach(maSach, tinhTrangPhieuMuon);

                Console.WriteLine("Mượn sách thành công!");
            }
        }

        /// <summary>
        /// hàm lấy số thứ tự phiếu mượn mới
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        static int LaySoThuTuPhieuMuon(string path)
        {
            int soThuTuPhieuMuon = 0;
            try
            {
                if (File.Exists(pathPhieuMuon))
                {
                    string[] lines = File.ReadAllLines(pathPhieuMuon);
                    if (lines.Length > 0)
                    {
                        string lastLine = lines[lines.Length - 1];
                        string[] lastLineParts = lastLine.Split('#');
                        if (lastLineParts.Length >= 6 && int.TryParse(lastLineParts[0], out soThuTuPhieuMuon))
                        {
                            // Tăng số thứ tự phiếu mượn lên 1 để tạo số phiếu mượn mới
                            soThuTuPhieuMuon++;
                        }
                        else
                        {
                            throw new Exception("Lỗi đọc dữ liệu phiếu mượn từ file.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Không thể đọc file.");
            }

            return soThuTuPhieuMuon;
        }
        /// <summary>
        /// hàm ghi thông tin Phiếu Mượn vào file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="phieuMuon"></param>
        //static void GhiPhieuMuon(LinkedList<PhieuMuon> danhSachPhieuMuon)
        //{
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(pathPhieuMuon, false)) // Sử dụng tham số false để ghi đè nội dung file
        //        {
        //            foreach (PhieuMuon phieuMuon in danhSachPhieuMuon)
        //            {
        //                string line = $"{phieuMuon.SoPhieuMuon}#{phieuMuon.MaBanDoc}#{phieuMuon.MaSach}#{phieuMuon.NgayMuon}#{phieuMuon.NgayPhaiTra}#{phieuMuon.TinhTrangPhieuMuon}";
        //                sw.WriteLine(line);
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Không thể ghi file danh sách phiếu mượn.");
        //    }
        //}

        /// <summary>
        /// hàm cập nhật tình trạng phiếu mượn sau khi mượn
        /// </summary>
        /// <param name="path"></param>
        /// <param name="soThuTuPhieuMuon"></param>
        static void CapNhatTinhTrangPhieuMuon(int soThuTuPhieuMuon)
        {
            try
            {
                string[] lines = File.ReadAllLines(pathPhieuMuon);
                if (lines.Length > 0)
                {
                    string lastLine = lines[lines.Length - 1];
                    string[] lastLineParts = lastLine.Split('#');
                    if (lastLineParts.Length >= 6)
                    {
                        lastLineParts[5] = "1"; // Cập nhật tình trạng thành 1
                        lines[lines.Length - 1] = string.Join("#", lastLineParts);
                        File.WriteAllLines(pathPhieuMuon, lines);
                    }
                    else
                    {
                        throw new Exception("Lỗi đọc dữ liệu phiếu mượn từ file.");
                    }
                }
                else
                {
                    throw new Exception("File phiếu mượn không có dữ liệu.");
                }
            }
            catch (Exception)
            {
                throw new Exception("Không thể cập nhật tình trạng phiếu mượn.");
            }
        }


        /// <summary>
        /// hàm kiểm tra mã bạn đọc đã tồn tại trong file hay chưa
        /// </summary>
        /// <param name="path"></param>
        /// <param name="maBanDoc"></param>
        /// <returns></returns>
        static bool KiemTraMaBanDocTonTai(string maBanDoc)
        {
            try
            {
                using (StreamReader sr = new StreamReader(pathBanDoc))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split('#');
                        if (line.Length >= 2 && line[0] == maBanDoc)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Không thể mở file.");
            }
            return false;
        }
        /// <summary>
        /// hàm kiểm tra sách có tồn tại hay không qua mã và sách có đang được mượn không
        /// </summary>
        /// <param name="path"></param>
        /// <param name="maSach"></param>
        /// <returns></returns>
        static bool KiemTraSach(string maSach)
        {
            try
            {
                string[] lines = File.ReadAllLines(pathSach);
                string[] phieuMuonLines = File.ReadAllLines(pathPhieuMuon);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] line = lines[i].Split('#');
                    if (line.Length >= 2 && line[0] == maSach)
                    {
                        int tinhTrangPhieuMuon;
                        if (int.TryParse(line[8], out tinhTrangPhieuMuon))
                        {
                            if (tinhTrangPhieuMuon != 0)
                            {
                                Console.Clear();
                                Console.WriteLine("Sách có mã {0} đang được mượn. Vui lòng nhập lại mã sách khác.", maSach);
                                return false;
                            }
                            else
                            {
                                if (phieuMuonLines.Length > 0)
                                {
                                    string[] phieuMuonLine = phieuMuonLines[0].Split('#');
                                    int soThuTuPhieuMuon;
                                    if (int.TryParse(phieuMuonLine[0], out soThuTuPhieuMuon))
                                    {
                                        // Cập nhật tình trạng sách
                                        line[8] = soThuTuPhieuMuon.ToString(); // Sửa giá trị tình trạng sách thành số thứ tự phiếu mượn
                                        lines[i] = string.Join("#", line);
                                        File.WriteAllLines(pathSach, lines);

                                        return true;
                                    }
                                    else
                                    {
                                        throw new Exception("Lỗi đọc số thứ tự phiếu mượn từ file.");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("File phiếu mượn không có dữ liệu.");
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("Lỗi đọc tình trạng sách từ file.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Không thể mở file.");
                return false;
            }

            Console.Clear();
            Console.WriteLine("Sách có mã {0} không tồn tại. Vui lòng nhập lại mã sách khác.", maSach);
            return false;
        }
        /// <summary>
        /// hàm kiểm tra mã sách có tồn tại hay không
        /// </summary>
        /// <param name="path"></param>
        /// <param name="maSach"></param>
        /// <returns></returns>
        static bool KiemTraMaSachTontai(string maSach)
        {
            try
            {
                using (StreamReader sr = new StreamReader(pathSach))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split('#');
                        if (line.Length >= 1 && line[0] == maSach)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Không thể mở file.");
            }
            return false;
        }
        /// <summary>
        /// hàm trả sách
        /// </summary>
        /// <param name="path"></param>
        static void TraSach(string path)
        {
            DanhSachPhieuMuon danhSachPhieuMuon = new DanhSachPhieuMuon();
            danhSachPhieuMuon.Doc(path); // Đọc danh sách phiếu mượn từ file

            string maSach;
            do
            {
                Console.Write("Nhập mã sách: ");
                maSach = Console.ReadLine();
                if (!KiemTraMaSachTontai(maSach))
                {
                    Console.Clear();
                    GiaoDien.TraSach();
                    Console.WriteLine("Mã sách không tồn tại. Vui lòng nhập lại!");
                }
            } while (!KiemTraMaSachTontai(maSach));

            bool daTraSach = false;
            bool tatCaDaTra = true;
            int soPhieuMuonChuaTra = 0;

            LinkedListNode<PhieuMuon> currentNode = danhSachPhieuMuon.L.First;
            while (currentNode != null)
            {
                if (currentNode.Value.MaSach == maSach)
                {
                    CapNhatTinhTrangSach(maSach, 0); // Cập nhật tình trạng sách

                    if (currentNode.Value.TinhTrangPhieuMuon == 1) // Cập nhật tình trạng phiếu mượn
                    {
                        currentNode.Value.TinhTrangPhieuMuon = 0;
                        daTraSach = true;

                    }
                }

                if (currentNode.Value.TinhTrangPhieuMuon == 1)
                {
                    tatCaDaTra = false;
                    soPhieuMuonChuaTra++;
                }

                currentNode = currentNode.Next;
            }

            if (daTraSach)
            {
                danhSachPhieuMuon.Ghi(path); // Ghi lại danh sách phiếu mượn sau khi cập nhật vào file

                Console.WriteLine("Đã trả sách thành công.");

                if (tatCaDaTra)
                {
                    Console.WriteLine("Tất cả các phiếu mượn đã được trả.");
                }
                else
                {
                    Console.WriteLine($"Còn {soPhieuMuonChuaTra} phiếu mượn chưa được trả.");
                }
            }
            else
            {
                Console.WriteLine($"Tất cả các phiếu có mã {maSach} đã được trả.");
            }
        }


        /// <summary>
        /// hàm đọc danh sách phiếu mượn 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        //static LinkedList<PhieuMuon> DocDanhSachPhieuMuon()
        //{
        //    LinkedList<PhieuMuon> danhSachPhieuMuon = new LinkedList<PhieuMuon>();

        //    // Đọc dữ liệu từ file và thêm vào danh sách liên kết
        //    try
        //    {
        //        if (File.Exists(pathPhieuMuon))
        //        {
        //            string[] lines = File.ReadAllLines(pathPhieuMuon);
        //            foreach (string line in lines)
        //            {
        //                string[] parts = line.Split('#');
        //                if (parts.Length >= 6)
        //                {
        //                    int soPhieuMuon, tinhTrangPhieuMuon;
        //                    DateTime ngayMuon, ngayPhaiTra;
        //                    if (int.TryParse(parts[0], out soPhieuMuon) &&
        //                        DateTime.TryParse(parts[3], out ngayMuon) &&
        //                        DateTime.TryParse(parts[4], out ngayPhaiTra) &&
        //                        int.TryParse(parts[5], out tinhTrangPhieuMuon))
        //                    {
        //                        PhieuMuon phieuMuon = new PhieuMuon(soPhieuMuon, parts[1], parts[2], ngayMuon, ngayPhaiTra, tinhTrangPhieuMuon);
        //                        danhSachPhieuMuon.AddLast(phieuMuon);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {

        //            throw new Exception("File danh sách phiếu mượn không tồn tại.");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw new Exception("Không thể đọc file danh sách phiếu mượn.");
        //    }

        //    return danhSachPhieuMuon;
        //}
        /// <summary>
        /// hàm cập nhật tình trạng sách sau khi mượn và trả
        /// </summary>
        /// <param name="path"></param>
        /// <param name="maSach"></param>
        /// <param name="soThuTuPhieuMuon"></param>
        static void CapNhatTinhTrangSach(string maSach, int tinhTrang)
        {
            try
            {
                string[] lines = File.ReadAllLines(pathSach);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] line = lines[i].Split('#');
                    if (line.Length >= 9 && line[0] == maSach)
                    {
                        line[8] = tinhTrang.ToString();
                        lines[i] = string.Join("#", line);
                        File.WriteAllLines(pathSach, lines);
                        return;
                    }
                }
                throw new Exception("Không tìm thấy sách có mã " + maSach);
            }
            catch (Exception)
            {
                throw new Exception("Không thể cập nhật tình trạng sách.");
            }
        }
        /// <summary>
        /// đường link dẫn tới file
        /// </summary>
        static string pathSach = @"D:\projeck_CTDL_giai_thuat\sach.txt";
        static string pathPhieuMuon = @"D:\projeck_CTDL_giai_thuat\phieumuon.txt";
        static string pathBanDoc = @"D:\projeck_CTDL_giai_thuat\bandoc.txt";
        static string pathAddmin = @"D:\projeck_CTDL_giai_thuat\admin.txt";
    }
}
