using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeck_CTDL_giai_thuat
{
    class BanDoc
    {
        //fields
        private string _maBanDoc, _tenBanDoc;
        private int _ngayDangkyBD;
        //method
        public BanDoc(string _maBanDoc, string _tenBanDoc, int _ngayDangkyBD)
        {
            this._maBanDoc = _maBanDoc;
            this._tenBanDoc = _tenBanDoc;
            this._ngayDangkyBD = _ngayDangkyBD;
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
        //method
        public string toString()
        {
            return $"{_maBanDoc,-10}{_tenBanDoc,-10}{_ngayDangkyBD,-10}";
        }
    }
}
