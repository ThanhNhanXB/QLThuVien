using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
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
            for (LinkedListNode<Admin> p = _l.First; p != null; p = p.Next)
            {
                Console.WriteLine(p.Value);
                //Admin admin = p.Value;
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
        public LinkedList<Admin> Doc(string path)
        {
            LinkedList<Admin> L = new LinkedList<Admin>();
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mo file that bai!!!");
            }
            return L;
        }
    }
}
