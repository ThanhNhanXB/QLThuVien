/*
* Đồ Án Quản Lý Thư Viện 
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QLThuVien
{
    class Sach
    {
        //fields
        private string _maSach, _tenSach, _tacGia, _nhaXuatBan;
        private int _tinhTrangSach, _soTrang, _giaBan, _namPhatHanh;
        private DateTime _ngayNhapKho;
        //properties
        public string MaSach
        {
            get
            {
                return _maSach;
            }

            set
            {
                _maSach = value;
            }
        }
        //properties
        public string TenSach
        {
            get
            {
                return _tenSach;
            }

            set
            {
                _tenSach = value;
            }
        }
        //properties
        public string TacGia
        {
            get
            {
                return _tacGia;
            }

            set
            {
                _tacGia = value;
            }
        }
        //properties
        public string NhaXuatBan
        {
            get
            {
                return _nhaXuatBan;
            }

            set
            {
                _nhaXuatBan = value;
            }
        }
        //properties
        public int TinhTrangSach
        {
            get
            {
                return _tinhTrangSach;
            }

            set
            {
                _tinhTrangSach = value;
            }
        }
        //properties
        public int SoTrang
        {
            get
            {
                return _soTrang;
            }

            set
            {
                _soTrang = value;
            }
        }
        //properties
        public int GiaBan
        {
            get
            {
                return _giaBan;
            }

            set
            {
                _giaBan = value;
            }
        }
        //properties
        public int NamPhatHanh
        {
            get
            {
                return _namPhatHanh;
            }

            set
            {
                _namPhatHanh = value;
            }
        }
        //properties
        public DateTime NgayNhapKho
        {
            get
            {
                return _ngayNhapKho;
            }

            set
            {
                _ngayNhapKho = value;
            }
        }
        //constructor day du
        public Sach(string _maSach, string _tenSach, string _tacGia, string _nhaXuatBan, int _giaBan, int _namPhatHanh, int _soTrang, DateTime _ngayNhapKho, int _tinhTrangSach)
        {
            this._maSach = _maSach;
            this._tenSach = _tenSach;
            this._tacGia = _tacGia;
            this._nhaXuatBan = _nhaXuatBan;
            this._tinhTrangSach = _tinhTrangSach;
            this._soTrang = _soTrang;
            this._giaBan = _giaBan;
            this._namPhatHanh = _namPhatHanh;
            this._ngayNhapKho = _ngayNhapKho;
        }
        //constructor khong tham so
        public Sach()
        {

        }
        //method
        public string toString()
        {
            return $"|{_maSach,-10}|{_tenSach,-15}|{_tacGia,-15}|{_nhaXuatBan,-12}|{_giaBan,-10}|{_namPhatHanh,-13}|{_soTrang,-10}|{_ngayNhapKho.ToString("dd/MM/yyyy"),-10}|{_tinhTrangSach,-10}|";
        }
        public string CapNhatDSSach()
        {
            return $"{_maSach}#{_tenSach}#{_tacGia}#{_nhaXuatBan}#{_giaBan}#{_namPhatHanh}#{_soTrang}#{_ngayNhapKho.ToString("dd/MM/yyyy")}#{_tinhTrangSach}";
        }

        public void NhapThemSach()
        {
            //Ràng buộc mã chỉ gồm số
            Regex rangBuocMa = new Regex("^[0-9]+$");

            //Ràng buộc gồm chỉ có chữ và số
            Regex rangBuocStr = new Regex("^[a-zA-Z0-9 ]+$");

            //Ràng buộc khi nhập mã sách
            bool ketQua = true;
            string filePath = @"D:\Project\CTDL\QLThuVien\QLThuVien\QLThuVien\data\sach.txt";
            while (true)
            {
                do
                {
                    if (ketQua == false)
                    {
                        Console.Clear();
                        GiaoDien.ThemSach();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("       Vui Lòng Chỉ Nhập Số\n       ".PadLeft(Console.WindowWidth / 2 + 34 / 2));
                        Console.ResetColor();
                        ketQua = true;
                    }
                    Console.Write("Nhập mã sách (Mã phải đủ 4 số): ".PadLeft(Console.WindowWidth / 3 + 8));
                    _maSach = Console.ReadLine();
                    if (!rangBuocMa.IsMatch(_maSach))
                    {
                        ketQua = false;
                    }

                } while (!rangBuocMa.IsMatch(_maSach));
                // Kiểm tra mã sách đã tồn tại trong file hay chưa
                if (File.ReadAllText(filePath).Contains(_maSach) || _maSach.Length > 4 || _maSach.Length < 4)
                {
                    Console.Clear();
                    GiaoDien.ThemSach();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("       Mã sách đã tồn tại hoặc không đúng định dạng mã. Vui lòng nhập lại!\n      ".PadLeft(Console.WindowWidth / 2 + 80 / 2));
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            }

            
            //Ràng buộc khi nhập tên sách
            ketQua = true;
            do
            {
                if (ketQua == false)
                {
                    Console.Clear();
                    GiaoDien.ThemSach();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("       Vui Lòng Điền Thông Tin\n       ".PadLeft(Console.WindowWidth / 2 + 36 / 2));
                    Console.ResetColor();
                    Console.WriteLine("Mã sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _maSach);
                    ketQua = true;
                }
                Console.Write("Nhập tên sách: ".PadLeft(Console.WindowWidth / 3 + 8));
                _tenSach = Console.ReadLine();
                if (!rangBuocStr.IsMatch(_tenSach))
                {
                    ketQua = false;
                }

            } while (!rangBuocStr.IsMatch(_tenSach));



            //Ràng buộc khi nhập tác giả
            ketQua = true;
            do
            {
                if (ketQua == false)
                {
                    Console.Clear();
                    GiaoDien.ThemSach();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("       Vui Lòng Điền Thông Tin\n      ".PadLeft(Console.WindowWidth / 2 + 36 / 2));
                    Console.ResetColor();
                    Console.WriteLine("Mã sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _maSach);
                    Console.WriteLine("Tên sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _tenSach);
                    ketQua = true;
                }
                Console.Write("Nhập tác giả: ".PadLeft(Console.WindowWidth / 3 + 8));
                _tacGia = Console.ReadLine();
                if (!rangBuocStr.IsMatch(_tacGia))
                {
                    ketQua = false;
                }

            } while (!rangBuocStr.IsMatch(_tacGia));



            // Ràng buộc khi nhập tác giả
            ketQua = true;
            do
            {
                if (ketQua == false)
                {
                    Console.Clear();
                    GiaoDien.ThemSach();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("       Vui Lòng Điền Thông Tin\n      ".PadLeft(Console.WindowWidth / 2 + 36 / 2));
                    Console.ResetColor();
                    Console.WriteLine("Mã sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _maSach);
                    Console.WriteLine("Tên sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _tenSach);
                    Console.WriteLine("Tác giả: ".PadLeft(Console.WindowWidth / 3 + 8) + _tacGia);
                    ketQua = true;
                }
                Console.Write("Nhập nhà xuất bản: ".PadLeft(Console.WindowWidth / 3 + 8));
                _nhaXuatBan = Console.ReadLine();
                if (!rangBuocStr.IsMatch(_nhaXuatBan))
                {
                    ketQua = false;
                }

            } while (!rangBuocStr.IsMatch(_nhaXuatBan));



            //Ràng buộc khi nhập giá bán
            bool isValid = false;

            while (!isValid)
            {
                Console.Write("Nhập giá bán: ".PadLeft(Console.WindowWidth / 3));
                string input = Console.ReadLine();

                isValid = int.TryParse(input, out _giaBan);

                if (!isValid)
                {
                    Console.Clear();
                    GiaoDien.ThemSach();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("        Số nhập vào không hợp lệ. Vui lòng nhập lại!\n      ".PadLeft(Console.WindowWidth / 2 + 58 / 2));
                    Console.ResetColor();
                    Console.WriteLine("Mã sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _maSach);
                    Console.WriteLine("Tên sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _tenSach);
                    Console.WriteLine("Tác giả: ".PadLeft(Console.WindowWidth / 3 + 8) + _tacGia);
                    Console.Write("Nhà xuất bản: ".PadLeft(Console.WindowWidth / 3 + 8) + _nhaXuatBan);
                }
            }

            //Ràng buộc khi nhập năm phát hành
            isValid = false;
            while (!isValid)
            {
                Console.Write("Nhập năm phát hành: ".PadLeft(Console.WindowWidth / 3 + 8));
                string input = Console.ReadLine();

                isValid = int.TryParse(input, out _namPhatHanh);

                if (!isValid)
                {
                    Console.Clear();
                    GiaoDien.ThemSach();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("        Số nhập vào không hợp lệ. Vui lòng nhập lại!\n      ".PadLeft(Console.WindowWidth / 2 + 58 / 2));
                    Console.ResetColor();
                    Console.WriteLine("Mã sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _maSach);
                    Console.WriteLine("Tên sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _tenSach);
                    Console.WriteLine("Tác giả: ".PadLeft(Console.WindowWidth / 3 + 8) + _tacGia);
                    Console.Write("Nhà xuất bản: ".PadLeft(Console.WindowWidth / 3 + 8) + _nhaXuatBan);
                    Console.Write("Giá bán: ".PadLeft(Console.WindowWidth / 3 + 20) + _giaBan);
                }
            }

            //Ràng buộc khi số trang
            isValid = false;
            while (!isValid)
            {
                Console.Write("Nhập số trang: ".PadLeft(Console.WindowWidth / 3 + 8));
                string input = Console.ReadLine();

                isValid = int.TryParse(input, out _soTrang);

                if (!isValid)
                {
                    Console.Clear();
                    GiaoDien.ThemSach();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("        Số nhập vào không hợp lệ. Vui lòng nhập lại!\n      ".PadLeft(Console.WindowWidth / 2 + 58 / 2));
                    Console.ResetColor();
                    Console.WriteLine("Mã sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _maSach);
                    Console.WriteLine("Tên sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _tenSach);
                    Console.WriteLine("Tác giả: ".PadLeft(Console.WindowWidth / 3 + 8) + _tacGia);
                    Console.Write("Nhà xuất bản: ".PadLeft(Console.WindowWidth / 3 + 8) + _nhaXuatBan);
                    Console.Write("Giá bán: ".PadLeft(Console.WindowWidth / 3 + 8) + _giaBan);
                    Console.Write("Năm phát hành: ".PadLeft(Console.WindowWidth / 3 + 8) + _namPhatHanh);
                }
            }

            //Ràng buộc khi nhập ngày nhập khi kiểu DateTime
            bool isValidDate = false;

            while (!isValidDate)
            {
                Console.Write("\nNhập ngày nhập: ".PadLeft(Console.WindowWidth / 3 + 8));
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out _ngayNhapKho))
                {
                    isValidDate = true;
                }
                else
                {
                    Console.Clear();
                    GiaoDien.ThemSach();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("       Ngày tháng không hợp lệ. Vui lòng nhập lại.!\n      ".PadLeft(Console.WindowWidth / 2 + 56 / 2));
                    Console.ResetColor();
                    Console.WriteLine("Mã sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _maSach);
                    Console.WriteLine("Tên sách: ".PadLeft(Console.WindowWidth / 3 + 8) + _tenSach);
                    Console.WriteLine("Tác giả: ".PadLeft(Console.WindowWidth / 3 + 8) + _tacGia);
                    Console.Write("Nhà xuất bản: ".PadLeft(Console.WindowWidth / 3 + 8) + _nhaXuatBan);
                    Console.Write("Giá bán: ".PadLeft(Console.WindowWidth / 3 + 8) + _giaBan);
                    Console.Write("Năm phát hành: ".PadLeft(Console.WindowWidth / 3 + 8) + _namPhatHanh);
                    Console.Write("Số trang: ".PadLeft(Console.WindowWidth / 3 + 8) + _soTrang);
                }
            }

            //Ràng buộc tình trạng sách
            _tinhTrangSach = 0;
        }
    }
}