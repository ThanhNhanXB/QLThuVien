using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{"MaSach",-10}{"TenSach",-10}{"TacGia",-10}{"NhaXuatBan",-10}{"GiaBan",-10}{"NamPhatHanh",-10}{"SoTrang",-10}{"NgayNhapKho",-10}{"TinhTrangSach",-10}");
            for(LinkedListNode<Sach> p = _l.First; p != null; p = p.Next)
            {
                Console.WriteLine(p.Value.toString());
            }   
        }
        //Ham ghi vào file
        public void Ghi(LinkedList<Sach> L, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (LinkedListNode<Sach> p = L.First; p != null; p = p.Next)
                    {
                        sw.WriteLine(p.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Khong the ghi file");

            }
        }
        // Hàm đọc file
        public void Doc(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] t = sr.ReadLine().Split('#');
                        Sach sach = new Sach(t[0], t[1], t[2], t[3], int.Parse(t[4]), int.Parse(t[5]), int.Parse(t[6]),  DateTime.Parse(t[7]), int.Parse(t[8]));
                        L.AddLast(sach);
                    }
                }
                Console.WriteLine("Doc file thanh cong");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mo file that bai!!!");
            }
        }

    }
}
