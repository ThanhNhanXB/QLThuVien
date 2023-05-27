using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QLThuVien
{
    internal class DanhSachSach
    {
        //fields
        private LinkedList<Sach> _l;

        //properties
        internal LinkedList<Sach> L
        {
            get
            {
                return _l;
            }
            set
            {
                _l = value;
            }
        }
        //constructor mặc định
        public DanhSachSach()
        {
            _l = new LinkedList<Sach>();
        }

        //constructor có tham số
        public DanhSachSach(LinkedList<Sach> l)
        {
            this._l = l;
        }

        //methods
        public void HienThiDSSach()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("+----------+---------------+---------------+------------+----------+-------------+----------+----------+----------+");
            Console.WriteLine($"|{"Mã Sách",-10}|{"Tên Sách",-15}|{"Tác Giả",-15}|{"Nhà Xuất Bản",-12}|{"Giá Bán",-10}|{"Năm Phát Hành",-11}|{"Số Trang",-10}|{"Ngày Nhập",-10}|{"Tình Trạng",-10}|");
            for (LinkedListNode<Sach> p = _l.First; p != null; p = p.Next)
            {
                Console.WriteLine("+----------+---------------+---------------+------------+----------+-------------+----------+----------+----------+");
                Console.WriteLine(p.Value.toString());
            }
            Console.WriteLine("+----------+---------------+---------------+------------+----------+-------------+----------+----------+----------+");
            Console.ResetColor();
        }
        //Ham ghi vào file
        public void Ghi(Sach L, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(L.CapNhatDSSach());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể ghi file!");

            }
        }
        // Hàm đọc file
        public void Doc(string path)
        {
            string content = File.ReadAllText(path);
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    //Đọc file nếu trống sẽ thông báo
                    if (string.IsNullOrEmpty(content))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Sách trong kho chưa được trưng bày! Vui lòng quay lại sau".PadLeft(Console.WindowWidth / 2 + 58 / 2));
                        Console.ResetColor();
                    }
                    else //Nếu file có thông tin thì sẽ đọc từng phần tử
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] t = sr.ReadLine().Split('#');
                            Sach sach = new Sach(t[0], t[1], t[2], t[3], int.Parse(t[4]), int.Parse(t[5]), int.Parse(t[6]), DateTime.Parse(t[7]), int.Parse(t[8]));
                            L.AddLast(sach);
                        }
                    }    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mở file thất bại!!!");
            }
        }
        public LinkedListNode<Sach> FindMaSach(string maSach)
        {
            for (LinkedListNode<Sach> p = L.First; p != null; p = p.Next)
            {
                if (p.Value.MaSach == maSach)
                {
                    return p;
                }
            }
            return null;
        }

    }
}