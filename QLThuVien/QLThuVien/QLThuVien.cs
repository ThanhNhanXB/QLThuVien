﻿/*
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
using System.Xml.Linq;

namespace QLThuVien
{
    class QLThuVien
    {
        static void Main(string[] args)
        {


            //khai báo 
            const string pathSach = "D:\\project\\CTDL\\QLThuVien\\QLThuVien\\QLThuVien\\data\\sach.txt"; 
            const string pathPhieuMuon = "D:\\project\\CTDL\\QLThuVien\\QLThuVien\\QLThuVien\\data\\phieumuon.txt"; 
            const string pathAddmin = "D:\\project\\CTDL\\QLThuVien\\QLThuVien\\QLThuVien\\data\\admin.txt"; 
            const string pathBanDoc =""; 





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
            Regex rangBuoc = new Regex("[a-zA-Z0-9]");
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
                        if(maHoa.Key != ConsoleKey.Enter)
                        {

                        pass += maHoa.KeyChar;
                        Console.Write('*');
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
                        // khai báo biến 
                        DanhSachSach sach = new DanhSachSach();
                        LinkedList<Sach> L = new LinkedList<Sach>();
                        Sach s = new Sach();
                        // Đường dẫn tới tệp tin "sach.txt"
                        string filePath = @"D:\Project\CTDL\QLThuVien\QLThuVien\QLThuVien\data\sach.txt";

                        // Nhập thông tin sách mới từ người dùng
                        s.NhapThemSach();

                        LinkedListNode<Sach> ketQua = sach.FindMaSach(s.MaSach);
                        // Kiểm tra nếu sách đã tồn tại trong tệp tin
                        if (ketQua != null) 
                        {
                            Console.WriteLine("\n     Sách đã tồn tại trong tệp!     \n".PadLeft(Console.WindowWidth / 2 + 36 / 2));
                        }
                        else
                        {
                            // Mở tệp tin để ghi thêm sách mới
                            sach.Ghi(s, filePath);
                            Console.WriteLine("\n       Thêm sách thành công!        \n".PadLeft(Console.WindowWidth / 2 + 36 / 2));
                        }
                        break;
                    //Xóa sách 
                    case '3':
                        Console.Clear();
                        GiaoDien.XoaSach();
                        string pathBook = @"D:\Project\CTDL\QLThuVien\QLThuVien\QLThuVien\data\sach.txt";
                       
                        Console.Write("Nhập mã sách cần xóa: ".PadLeft(Console.WindowWidth / 3 + 8));
                        string maSach = Console.ReadLine();

                        // Đọc tất cả các dòng từ tệp và lưu vào danh sách
                        List<string> lines = new List<string>(File.ReadAllLines(pathBook));

                        bool bookDeleted = false;

                        // Tìm và xóa sách dựa trên mã sách
                        for (int i = 0; i < lines.Count; i++)
                        {
                            string[] bookData = lines[i].Split('#');

                            // Kiểm tra mã sách trong dữ liệu sách
                            if (bookData.Length > 0 && bookData[0] == maSach)
                            {
                                lines.RemoveAt(i);
                                bookDeleted = true;
                                break;
                            }
                        }

                        if (bookDeleted)
                        {
                            // Ghi lại danh sách sách sau khi xóa
                            File.WriteAllLines(pathBook, lines);
                            Console.WriteLine("Xóa sách thành công!");
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy sách với mã sách đã nhập!");
                        }

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
                        DanhSachPhieuMuon dsPhieuMuon = new DanhSachPhieuMuon();
                        //dsPhieuMuon.Doc(@"..\..\..\..\data\phieumuon.txt");
                        dsPhieuMuon.Doc(path);
                        dsPhieuMuon.HienThiDSPhieuMuon();
                        Console.Write("       Ấn Phím bất Kỳ Để Trở Về     \n".PadLeft(Console.WindowWidth/2+36/2));
                        Console.ReadKey(true); 
                        Console.Clear();
                        break;
                    //Mượn sách 
                    case '2':
                        Console.Clear();
                        GiaoDien.MuonSach();

                        break;
                    //Trả Sách 
                    case '3':
                        Console.Clear();
                        GiaoDien.TraSach();

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
    }
}
