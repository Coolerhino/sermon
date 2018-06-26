using System.Collections.Generic;
using System.Linq;
using Sermon_Core.Model;

namespace Sermon_Core.Protocol
{
    public class Parse
    {
        public Epistula Packet(string request){
                var lines = request.Split("\r\n").ToList();
                var mode = lines[0].Replace("MODUS", "").TrimStart();
                if (mode != "PONTIFEX" && mode != "SAPIENTIA"){ return null; };
                if (mode == "PONTIFEX"){
                    var language = lines[1];
                    var length = int.Parse(lines[2].Replace("PREPARATIO ", ""));
                    var requestEnded = lines[3] == "PROCEDAMUS"; 
                    if (requestEnded){
                        return new Epistula{Modus = mode,
                            Lingua = language,
                            Preparatio = length};
                    }
                } else {
                    var length = int.Parse(lines[1].Replace("PREPARATIO ", ""));
                    var requestEnded = lines[2] == "PROCEDAMUS"; 
                    if (requestEnded) {
                            return new Epistula{
                            Modus = mode,
                            Preparatio = length};
                    }
                }
//tu dokonczyc
            return null;
        }
    }
}

