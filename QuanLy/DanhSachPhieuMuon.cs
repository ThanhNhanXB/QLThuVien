using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    internal class DanhSachPhieuMuon
    {
        //feilds
        private LinkedList<PhieuMuon> _l;

        //properties
        internal LinkedList<PhieuMuon> L
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
        public DanhSachPhieuMuon()
        {
            _l = new LinkedList<PhieuMuon>();
        }

        //constructor có tham số
        public DanhSachPhieuMuon(LinkedList<PhieuMuon> l)
        {
            L = l;
        }
        //methods
        public void HienThiDSPhieuMuon()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{"SoPhieuMuon",-10}{"MaBanDoc",-10}{"MaSach",-10}{"NgayMuon",-10}{"NgayPhaiTra",-10}{"TinhTrangPhieuMuon",-10}");
            for(LinkedListNode<PhieuMuon> p = _l.First; p != null; p = p.Next)
            {
                Console.WriteLine(p.Value.toString());
            }
        }

        // Hàm ghi file
        public void Ghi(LinkedList<PhieuMuon> L, string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (LinkedListNode<PhieuMuon> p = L.First; p != null; p = p.Next)
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
                        PhieuMuon phieuMuon = new PhieuMuon(int.Parse(t[0]), t[1] ,t[2], DateTime.Parse(t[3]), DateTime.Parse(t[4]), int.Parse(t[5]));
                        L.AddLast(phieuMuon);
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
