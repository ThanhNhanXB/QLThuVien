using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return $"{_maSach,-10}{_tenSach,-10}{_tacGia,-10}{_nhaXuatBan,-10}{_giaBan,-10}{_namPhatHanh,-10}{_soTrang,-10}{_ngayNhapKho,-10}{_tinhTrangSach,-10}";
        }
    }
}
