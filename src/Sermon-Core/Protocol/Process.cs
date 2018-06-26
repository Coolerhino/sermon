using Sermon_Core.Protocol;
namespace Sermon_Core.Protocol
{
    public class Process
    {
        public string Request(string message){
            if (message == "DOMINUS VOBISCUM"){
                return "ET CUM SPIRITU TUO";
            } else {
                var parse = new Parse();
                var packet = parse.Packet(message);
                if (packet == null) { return "PECCATUM MORTIFERUM";};
                var sermon = new Sermon().Generate(packet) + "AMEN";
                return sermon;
            }
            return "PECCATUM MORTIFERUM";
        }
    }
}