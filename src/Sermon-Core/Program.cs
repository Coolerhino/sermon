using System;
using Sermon_Core.Communication;

namespace Sermon_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var connections = new Connections(4425);
            connections.Handle().Wait();
        }
    }
}
//protocol
// MODUS (tryb pracy apki)
// * PONTIFEX - generuj ze zdan papieza franciszka
// * SAPIENTIA - generuj filozoficzna przemowe, nie rozni sie od 90% slyszanych na ambonach
// jak user okresli tryb, okresl dlugosc
// PREPARATIO <liczba>
// SILENTIUM - koniec komunikacji zamkniecie socketu
// na serwerze - AUDIO (uslyszalem, daj nastepna komende)
// PROCEDAMUS - konczy wiadomosc
//do pontifexa mozna dodac parametr LINGUA okreslajacy jezyk, domyslnie polski
//struktura
// 1 zdanie wprowadzajace, typu "kochani swieci", "drodzy parafianie", "bracia i siostry w chrystusie panu" "czcigodni bracia w kaplanstwie, szanowna sluzbo liturgiczna, wierny ludzie boży" 