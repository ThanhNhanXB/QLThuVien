/*
 * Đồ Án Quản Lý Thư Viện 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
{
    internal class GiaoDien
    {
        /// <summary>
        /// Màn hình đăng nhập 
        /// </summary>
        static public void DangNhap()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|         QUẢN LÝ THƯ VIỆN         |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------- Đăng Nhập ------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor();

        }
        /// <summary>
        /// Giao dien dang nhap thanh cong 
        /// </summary>
        static public void DangNhapThanhCong()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----CHÀO MỪNG ĐẾN VỚI THƯ VIỆN-----".PadLeft(Console.WindowWidth / 2 + 36 / 2));
            Console.WriteLine("--------Đăng Nhập Thành Công--------".PadLeft(Console.WindowWidth / 2 + 36 / 2));
            Console.ResetColor();
        }
        /// <summary>
        /// Giao dien dang nhap that bai 
        /// </summary>
        static public void DangNhapThatBai()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|         QUẢN LÝ THƯ VIỆN         |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.Write(str);
            str = "";
            Console.ForegroundColor = ConsoleColor.Red;            
            str += "--------- Đăng Nhập Thất Bại -------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
                   
            str += "".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor();
        }

        /// <summary>
        /// Màn hình chọn 
        /// </summary>
        static public void ManHinhChon()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|          CHỌN CHỨC NĂNG          |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "-----Nhấn Phím Để Chọn Chức Năng----\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str = "     1--Quản Lý Sách                 \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "    2--Quản Lý Phiếu Mượn           \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "    Esc--Thoát                      \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor();

        }

        /// <summary>
        /// Màn hình chọn chứ năng sách  
        /// </summary>
        static public void MenuSach()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|           QUẢN LÝ SÁCH           |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor(); 
            Console.ForegroundColor = ConsoleColor.Blue;
            str =  "    1--Hiển Thị Thông Tin Sách     \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "    2--Thêm Sách                   \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "    3--Xóa Sách                    \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "    4--Trở Về                      \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.Red;
            str = "    >>Esc--Thoát                   \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor();

        }

        /// <summary>
        ///Màn hình Hiển Thị Sách 
        /// </summary>
        static public void HienThiSach()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|           QUẢN LÝ SÁCH           |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "----------- Hiển Thị Sách ----------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor();

        }

        /// <summary>
        ///Màn hình Thêm Sách 
        /// </summary>
        static public void ThemSach()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|           QUẢN LÝ SÁCH           |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------ Thêm Sách -------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor();

        }

        /// <summary>
        ///Màn hình Xóa Sách 
        /// </summary>
        static public void XoaSach()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|           QUẢN LÝ SÁCH           |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------- Xóa Sách -------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor();

        }

        /// <summary>
        /// Màn hình chọn chức năng phiếu mượn  
        /// </summary>
        static public void MenuPhieuMuon()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|        QUẢN LÝ PHIẾU MƯỢN        |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.Write(str);
            Console.ForegroundColor = ConsoleColor.Blue;
            str = ""; 
            str += "     1--Hiển Thị Phiếu Mượn         \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "     2--Mượn Sách                   \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "     3--Trả Sách                    \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "     4--Trở Về                      \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.Red;
            str = "     >>Esc--Thoát                    \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.Write(str);
            Console.ResetColor();

        }

        /// <summary>
        /// Màn hình chọn chức năng phiếu mượn  
        /// </summary>
        static public void HienThiPhieu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|        QUẢN LÝ PHIẾU MƯỢN        |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "-------- Hiển Thị Phiếu Mượn -------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);         
            Console.ResetColor();

        }
        /// <summary>
        /// Màn hình Mượn Sách
        /// </summary>
        static public void MuonSach()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|        QUẢN LÝ PHIẾU MƯỢN        |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------ Mượn Sách -------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);         
            Console.ResetColor();

        }
        /// <summary>
        /// Màn hình Trả sách
        /// </summary>
        static public void TraSach()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|        QUẢN LÝ PHIẾU MƯỢN        |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------- Trả Sách -------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);         
            Console.ResetColor();

        }
        /// <summary>
        /// Màn Hình dừng chương trình 
        /// </summary>
        static public void DungChuongTrinh()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|    |                             |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|--- ĐÃ THOÁT KHỎI CHƯƠNG TRÌNH ---|\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                             |    |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor();

        }
    }
}
