using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
{
    class BanDoc
    {
        //fields
        private string _maBanDoc, _tenBanDoc;
        private DateTime _ngayDangkyBD;
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
        public int NgayDangkyBD
        {
            get
            {
                return _ngayDangkyBD;
            }

            set
            {
                _ngayDangkyBD = value;
            }
        }
        //properties
        public string TenBanDoc
        {
            get
            {
                return _tenBanDoc;
            }

            set
            {
                _tenBanDoc = value;
            }
        }
        //constructor day du
        public BanDoc(string _maBanDoc, string _tenBanDoc, int _ngayDangkyBD)
        {
            this._maBanDoc = _maBanDoc;
            this._tenBanDoc = _tenBanDoc;
            this._ngayDangkyBD = _ngayDangkyBD;
        }
        //constructor khong tham so
        public BanDoc()
        {

        }
        //method
        public string toString()
        {
            return $"{_maBanDoc,-10}{_tenBanDoc,-10}{_ngayDangkyBD,-10}";
        }
    }
}
