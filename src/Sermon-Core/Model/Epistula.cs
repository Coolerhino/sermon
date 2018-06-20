namespace Sermon_Core.Model
{
    /// <summary>
    /// Protocol starts with sending DOMINUS VOBISCUM to the server
    /// If everything is correct and client can send requests, server responds with ET CUM SPIRITU TUO
    /// Then a request can be made, which consist of lines:
    /// MODUS [PONTIFEX/SAPIENTIA]
    /// LINGUA [language] (only in pontifex mode, but optional)
    /// PREPARATIO [number] 
    /// PROCEDAMUS [ends request]
    /// separated by \r\n
    /// If the server encounters error, it will respond with
    /// PECCATUM MORTIFERUM
    /// If the request is correct, server should return a sermon text, terminated by
    /// AMEN
    /// To close connection, you can send
    /// SILENTIUM
    /// </summary>
    public class Epistula
    {
        /// <summary>
        /// Mode of the generator:
        /// PONTIFEX - generate sermon from Pope Francis twitter
        /// SAPIENTIA - generate random funny sermon
        /// </summary>
        public string Modus { get; set; }
        /// <summary>
        /// If PONTIFEX mode is activated, you can select language. Default is EN
        /// </summary>
        public string Lingua { get; set; }
        /// <summary>
        /// How much sentences the sermon should have (without start and end sentence)
        /// </summary>
        public int Preparatio { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(Lingua))
            {
                return $@"MODUS {Modus}
{Lingua}
PREPARATIO {Preparatio}
PROCEDAMUS";
            }
            return $@"MODUS {Modus}
PREPARATIO {Preparatio}
PROCEDAMUS";
        }
    }
}