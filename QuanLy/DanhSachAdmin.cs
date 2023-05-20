using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
{
    internal class DanhSachAdmin
    {
        //fields 
        private LinkedList<Admin> _l;

        //properties
        internal LinkedList<Admin> L 
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
        public DanhSachAdmin()
        {
            _l = new LinkedList<Admin>();
        }
        //constructor có tham số
        public DanhSachAdmin(LinkedList<Admin> l)
        {
            _l = l;
        }

        //methods
        public void HienThiDSAdmin()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{"User",-10}{"Password",-10}");
            for (LinkedListNode<Admin> p = _l.First; p != null; p = p.Next)
            {
                Console.WriteLine(p.Value.toString());
            }
        }

        //Ham ghi vào file
        public void Ghi(LinkedList<Admin> L, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (LinkedListNode<Admin> p = L.First; p != null; p = p.Next)
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
                        Admin sach = new Admin(t[0], t[1]);
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
