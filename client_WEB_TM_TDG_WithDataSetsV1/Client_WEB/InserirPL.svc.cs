using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Client_WEB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "InserirPL" in code, svc and config file together.
    public class InserirPL : IInserirPL
    {
        public void Insert(int m1, int m2, int m3, int m4, int m5, int user)
        {
            TM_TDG.WithDataSets.BLL.Playlist plbll = new TM_TDG.WithDataSets.BLL.Playlist();
            //plbll.CreatePlaylist(m1,m2,m3,m4,m5,user);
        }
    }
}
