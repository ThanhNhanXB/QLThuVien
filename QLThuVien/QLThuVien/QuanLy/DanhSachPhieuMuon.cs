using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
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
            Console.ForegroundColor = ConsoleColor.DarkGray;
            int strLength = 76; 
            Console.WriteLine("+-------------+----------+----------+----------+-------------+-------------+".PadLeft(Console.WindowWidth/2+strLength/2));
            Console.WriteLine($"|{"Số Phiếu Mượn",-10}|{"Mã Bạn Đọc",-10}|{"Mã Sách",-10}|{"Ngày Mượn",-10}|{"Ngày Phải Trả",-13}|{"Tình Trạng PM",-13}|".PadLeft(Console.WindowWidth / 2 + strLength / 2));
            for (LinkedListNode<PhieuMuon> p = _l.First; p != null; p = p.Next)
            {
                Console.WriteLine("+-------------+----------+----------+----------+-------------+-------------+".PadLeft(Console.WindowWidth / 2 + strLength / 2));
                Console.WriteLine(p.Value.toString().PadLeft(Console.WindowWidth / 2 + strLength / 2));
            }
            Console.WriteLine("+-------------+----------+----------+----------+-------------+-------------+".PadLeft(Console.WindowWidth / 2 + strLength / 2));
            Console.ResetColor();
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
                        sw.WriteLine(p.Value.toString());
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
                        PhieuMuon phieuMuon = new PhieuMuon(int.Parse(t[0]), t[1], t[2], DateTime.Parse(t[3]), DateTime.Parse(t[4]), int.Parse(t[5]));
                        L.AddLast(phieuMuon);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Mo file that bai!!!");
            }
        }
    }
}
