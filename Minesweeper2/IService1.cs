using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Minesweeper2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        /*
         * Things we need a service for
         * 
         * pause and resume game (serialize entire gamestate and save to file)
         * 
         * save stats (Create stats model to populate on game completion, serialze, save to file)
         * 
         * Show previous stats(deserialize stats JSON and populate into list of stats model to be presented)
         * 
         */
        [OperationContract]
        void DoWork();
    }//end Iservice1 interface
}//end namespace
