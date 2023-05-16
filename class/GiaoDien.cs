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
        /// Màn hình chọn 
        /// </summary>
        static public void ManHinhChon()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string str = "";  
            const int strLength = 36;
            Console.ForegroundColor = ConsoleColor.Cyan;
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|          CHỌN CHỨC NĂNG          |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);  
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str); 
            Console.ForegroundColor = ConsoleColor.White;
            str  = "1--Quản Lý Thư Viện                 \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "2--Quản Lý Phiếu Mượn               \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "Esc--Thoát                          \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
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
            Console.ForegroundColor = ConsoleColor.White;
            str  = "1--Hiển Thị Thông Tin Sách          \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "2--Thêm Sách                        \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "3--Xóa Sách                         \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "Esc--Thoát                          \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor();

        } 
        /// <summary>
        /// Màn hình khung sách   
        /// </summary>
        static public void Sach()
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
            Console.ForegroundColor = ConsoleColor.White;
            str  = "1--Hiển Thị Thông Tin Sách          \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "2--Thêm Sách                        \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "3--Xóa Sách                         \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "Esc--Thoát                          \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
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
            str += "|           QUẢN LÝ SÁCH           |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "|                                  |\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "------------------------------------\n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            str  = "1--Hiển Thị Phiếu Mượn              \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "2--Mượn Sách                        \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "3--Trả Sách                         \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "Esc--Thoát                          \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor();

        } 
        /// <summary>
        /// Màn hình xuất khung Phiếu mượn 
        /// </summary>
        static public void PhieuMuon()
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
            Console.ForegroundColor = ConsoleColor.White;
            str  = "1--Hiển Thị Phiếu Mượn              \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "2--Mượn Sách                        \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "3--Trả Sách                         \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            str += "Esc--Thoát                          \n".PadLeft(Console.WindowWidth / 2 + strLength / 2);
            Console.WriteLine(str);
            Console.ResetColor();

        }
        
    }
}
