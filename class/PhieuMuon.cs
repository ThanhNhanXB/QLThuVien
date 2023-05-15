using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
{
    class PhieuMuon
    {
        //fields
        private int _soPhieuMuon, _ngayPhaiTra, _tinhTrangPhieuMuon, _sTTPhieuMuon;
        private string _maBanDoc, _maSach;
        private DateTime _ngayMuon;
        //properties
        public int SoPhieuMuon
        {
            get
            {
                return _soPhieuMuon;
            }

            set
            {
                _soPhieuMuon = value;
            }
        }
        //properties
        public int NgayPhaiTra
        {
            get
            {
                return _ngayPhaiTra;
            }

            set
            {
                _ngayPhaiTra = value;
            }
        }
        //properties
        public int TinhTrangPhieuMuon
        {
            get
            {
                return _tinhTrangPhieuMuon;
            }

            set
            {
                _tinhTrangPhieuMuon = value;
            }
        }
        //properties
        public int STTPhieuMuon
        {
            get
            {
                return _sTTPhieuMuon;
            }

            set
            {
                _sTTPhieuMuon = value;
            }
        }
        //properties
        public string MaBanDoc
        {
            get
            {
                return _maBanDoc;
            }

            set
            {
                _maBanDoc = value;
            }
        }
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
        public DateTime NgayMuon
        {
            get
            {
                return _ngayMuon;
            }

            set
            {
                _ngayMuon = value;
            }
        }
        //constructor day du
        public PhieuMuon(int _soPhieuMuon, int _ngayPhaiTra, int _tinhTrangPhieuMuon, int _sTTPhieuMuon, string _maBanDoc, string _maSach, DateTime _ngayMuon)
        {
            this._soPhieuMuon = _soPhieuMuon;
            this._ngayPhaiTra = _ngayPhaiTra;
            this._tinhTrangPhieuMuon = _tinhTrangPhieuMuon;
            this._sTTPhieuMuon = _sTTPhieuMuon;
            this._maBanDoc = _maBanDoc;
            this._maSach = _maSach;
            this._ngayMuon = _ngayMuon;
        }
        //constrctor khong tham so
        public PhieuMuon()
        {

        }
        //method
        public string toString()
        {
            return $"{_sTTPhieuMuon,-10}{_maSach,-10}{_maBanDoc,-10}{_soPhieuMuon,-10}{_ngayMuon,-10}{_ngayPhaiTra,-10}{_tinhTrangPhieuMuon,-10}";
        }
    }
}
