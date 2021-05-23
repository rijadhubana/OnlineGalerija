using Microsoft.AspNetCore.Http;
using OnlineGalerija.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGalerija.Helper
{
    public static class Authentication
    {
        private const string LogiraniKorisnik = "logirani_korisnik";
        public static void SetLogiraniKorisnik(this HttpContext context, LoggedUser korisnik, bool snimiUCookie = false)
        {
            context.Session.SetObjectAsJson(LogiraniKorisnik, korisnik);
            if (snimiUCookie)
                context.Response.SetCookieJson(LogiraniKorisnik, korisnik);
            else context.Response.SetCookieJson(LogiraniKorisnik, null);
        }
        public static LoggedUser GetLogiraniKorisnik(this HttpContext context)
        {
            LoggedUser korisnik = context.Session.GetObjectFromJson<LoggedUser>(LogiraniKorisnik);
            if (korisnik == null)
            {
                korisnik = context.Request.GetCookieJson<LoggedUser>(LogiraniKorisnik);
                context.Session.SetObjectAsJson(LogiraniKorisnik, korisnik);
            }
            return korisnik;
        }
    }
}
