using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkedList
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
            for(LinkedListNode<Sach> p = _l.First; p != null; p = p.Next)
            {
                Console.WriteLine(p.Value);
                //Sach sach = p.Value;
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
        public LinkedList<Sach> Doc(string path)
        {
            LinkedList<Sach> L = new LinkedList<Sach>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] t = sr.ReadLine().Split('#');
                        Sach sach = new Sach(t[0], t[1], t[2], t[3], int.Parse(t[4]), int.Parse(t[5]), int.Parse(t[6]), int.Parse(t[7]), DateTime.Parse(t[8]));
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
