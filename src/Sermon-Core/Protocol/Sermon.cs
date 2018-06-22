using Sermon_Core.Model;

namespace Sermon_Core.Protocol
{
    public class Sermon
    {
        public string Generate(Epistula request)
        {
            var length = request.Preparatio;
            var mode = request.Modus;
            var language = request.Lingua;
            //zrob stringa
            //wez losowy poczatek z bazy danych
            //wez kolekcje length zdan z bazy danych
            //wez losowy koniec z bazy danych
            // amen dokleja modul ktory wysyla requesta, tutaj bedzie tylko
            return "It works";
        }
    }
}