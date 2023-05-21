/*
 * Đồ Án Quản Lý Thư Viện 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QLThuVien
{
    class QLThuVien
    {
        static void Main(string[] args)
        {
            /*
             * Chú ý dùng phím tiếng anh để debug chương trình  
             * tiếng việt sau khi chọn menu sẽ đứng 
             */ 


            //khai báo 
            bool dungChuongTrinh=false; 
            
            //đăng nhập thư viện 
            if (DangNhap() == true)
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
                            dungChuongTrinh = QuanLySach();

                            break;
                        case '2':
                            Console.Clear();
                            dungChuongTrinh = QuanLyPhieuMuon(); 

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
        static bool DangNhap()
        {
            //khai bao 
            const int SOLANSAI = 3;
            string user, pass;
            bool check = false;
            GiaoDien.DangNhap();
            for (int i = 0; i < SOLANSAI; i++)
            {
                //CHƯA có ràng buộc khi nhập username và password 
                Console.Write("Username: ".PadLeft(Console.WindowWidth / 3 + 8));
                user = Console.ReadLine();
                Console.Write("Password: ".PadLeft(Console.WindowWidth / 3 + 8));
                pass = Console.ReadLine();
                check = KiemTraDangNhap("D:\\project\\CTDL\\QLThuVien\\QLThuVien\\QLThuVien\\data\\admin.txt", user, pass);
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
                        if (line[0]==user && line[1]==pass)
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
        static bool QuanLySach()
        {
            //Khai báo 

            while (true)
            {
                GiaoDien.MenuSach();
                ConsoleKeyInfo phimChon = Console.ReadKey(true) ;
                switch (phimChon.KeyChar)
                {
                    //Hiển Thị sách 
                    case '1':
                        Console.Clear();
                        GiaoDien.HienThiSach(); 
                        
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
        static bool QuanLyPhieuMuon()
        {
            while (true)
            {
                GiaoDien.MenuPhieuMuon();
                ConsoleKeyInfo phimChon = Console.ReadKey(true) ;
                switch (phimChon.KeyChar)
                {
                    //Hiển thị phiếu mượn 
                    case '1':
                        Console.Clear();
                        GiaoDien.HienThiPhieu(); 
                        
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
