/*
 * Quản lý đồ án thư viện
 * LinkedList Danh sách bạn đọc
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class DanhSachBanDoc
    {
        //fields
        private LinkedList<BanDoc> _l;

        //properties
        public LinkedList<BanDoc> L
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
        public DanhSachBanDoc()
        {
            _l = new LinkedList<BanDoc>();
        }

        //constructor có tham số
        public DanhSachBanDoc(LinkedList<BanDoc> l)
        {
            _l = l;
        }

        //methods
        public void HienThiDSBanDoc()
        {
            for(LinkedListNode<BanDoc> p = _l.First; p != null; p = p.Next)
            {
                Console.WriteLine(p.Value);
            }
        }

        // Hàm ghi file
        public void Ghi(LinkedList<BanDoc> L, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (LinkedListNode<BanDoc> p = L.First; p != null; p = p.Next)
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
        public LinkedList<BanDoc> Doc(string path)
        {
            LinkedList<BanDoc> L = new LinkedList<BanDoc>();
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] t = sr.ReadLine().Split('#');
                        BanDoc banDoc = new BanDoc(t[0], t[1], DateTime.Parse(t[3]));
                        L.AddLast(banDoc);
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
