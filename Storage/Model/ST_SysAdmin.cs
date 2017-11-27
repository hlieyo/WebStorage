using Foundation.Cls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ST_SysAdmin : BaseEntityObject
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string UserPwd { get; set; }
    }
}
