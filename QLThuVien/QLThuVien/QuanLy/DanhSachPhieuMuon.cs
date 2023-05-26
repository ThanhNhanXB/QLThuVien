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

        //// Hàm ghi file
        //public void Ghi(LinkedList<PhieuMuon> L, string path)
        //{
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(path))
        //        {
        //            for (LinkedListNode<PhieuMuon> p = L.First; p != null; p = p.Next)
        //            {
        //                sw.WriteLine(p.Value);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Khong the ghi file");

        //    }
        //}

        //// Hàm đọc file
        //public void Doc(string path)
        //{
        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(path))
        //        {
        //            while (!sr.EndOfStream)
        //            {
        //                string[] t = sr.ReadLine().Split('#');
        //                PhieuMuon phieuMuon = new PhieuMuon(int.Parse(t[0]), t[1], t[2], DateTime.Parse(t[3]), DateTime.Parse(t[4]), int.Parse(t[5]));
        //                L.AddLast(phieuMuon);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Mo file that bai!!!");
        //    }
        //}
        public void Ghi(string path)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path, false)) // Sử dụng tham số false để ghi đè nội dung file
                {
                    foreach (PhieuMuon phieuMuon in L)
                    {
                        string line = $"{phieuMuon.SoPhieuMuon}#{phieuMuon.MaBanDoc}#{phieuMuon.MaSach}#{phieuMuon.NgayMuon}#{phieuMuon.NgayPhaiTra}#{phieuMuon.TinhTrangPhieuMuon}";
                        sw.WriteLine(line);
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Không thể ghi file danh sách phiếu mượn.");
            }
        }

        // Hàm đọc file
        public void Doc(string path)
        {
            L.Clear();
            //Đọc dữ liệu từ file và thêm vào danh sách liên kết
            try
            {
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split('#');
                        if (parts.Length >= 6)
                        {
                            int soPhieuMuon, tinhTrangPhieuMuon;
                            DateTime ngayMuon, ngayPhaiTra;
                            if (int.TryParse(parts[0], out soPhieuMuon) &&
                                DateTime.TryParse(parts[3], out ngayMuon) &&
                                DateTime.TryParse(parts[4], out ngayPhaiTra) &&
                                int.TryParse(parts[5], out tinhTrangPhieuMuon))
                            {
                                PhieuMuon phieuMuon = new PhieuMuon(soPhieuMuon, parts[1], parts[2], ngayMuon, ngayPhaiTra, tinhTrangPhieuMuon);
                                L.AddLast(phieuMuon);
                            }
                        }
                    }
                }
                else
                {

                    throw new Exception("File danh sách phiếu mượn không tồn tại.");
                }
            }
            catch (Exception)
            {
                throw new Exception("Không thể đọc file danh sách phiếu mượn.");
            }
        }

    }
}
