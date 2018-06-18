using System.Collections.Generic;
using System.Linq;

namespace Sermon_Core.Protocol
{
    public class Parse
    {
        public string Message(string request){
            var response = "";
            if (request == "DOMINUS VOBISCUM"){
                response = "ET CUM SPIRITU TUO";
            }
            else {

                var lines = request.Split("\r\n").ToList();
                if (!(lines[0] == "PROCEDAMUS")) { return response = "PECCATUM MORTIFERUM";};
//tu dokonczyc
            }
            return response;
        }
    }
}