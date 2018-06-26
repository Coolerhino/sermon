﻿using System;
using System.Linq;
using Sermon_Core.DataAccess;
using Sermon_Core.Model;

namespace Sermon_Core.Protocol
{
    public class Sermon
    {
        public string Generate(Epistula request)
        {
            var length = request.Preparatio;
            var mode = request.Modus;
            var language = request.Lingua.ToLower();
            var doc = new Documents();
            var fragments = doc.GetSermonTweetFragment(language, length);
            //zrob stringa
            //wez losowy poczatek z bazy danych
            //wez kolekcje length zdan z bazy danych
            //wez losowy koniec z bazy danych
            // amen dokleja modul ktory wysyla requesta, tutaj bedzie tylko
            var sentences = string.Join(" ", fragments.Select(t => t.Text));
            //var sentences = Convert.ToString(fragments.Select(t => t.Text).ToList());
            return sentences;
        }
    }
}