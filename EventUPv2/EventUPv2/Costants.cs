﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EventUPv2
{
    public static class Constants
    {
        // The iOS simulator can connect to localhost. However, Android emulators must use the 10.0.2.2 special alias to your host loopback interface.
        //  public static string BaseAddress = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001" : "https://localhost:5001";
        //  public static string TodoItemsUrl = BaseAddress + "/api/todoitems/{0}";
<<<<<<< HEAD
        public static string UserUrl = null;
        public static string AdminUrl = null;
        public static string DeleteUserUrl = null;
        public static string DeleteAdminUrl = null;
        public static string RegisterUserUrl = "http://newes.dlinkddns.com/EventUp/index.php?rest_route=/enventup/client/register";
        public static string RegisterAdminUrl = "http://newes.dlinkddns.com/EventUp/index.php?rest_route=/enventup/company/list";
=======
        public static string registerUrl = "http://newes.dlinkddns.com/EventUp/index.php?rest_route=/enventup/client/register";
        public static string listAdminUrl = "http://newes.dlinkddns.com/EventUp/index.php?rest_route=/enventup/company/list";
>>>>>>> 49b129f3227bc639ef0e88b813ee42201e102ac2
        public static string EventoUrl = null;
        public static string NewsUrl = null;
        public static string PartecipaUrl = null;
        public static string LoginUrl = "http://newes.dlinkddns.com/EventUp/index.php?rest_route=/jwt-auth/v1/token";
        public static string listInteressiUrl = "http://newes.dlinkddns.com/EventUp/index.php?rest_route=/enventup/interessi";
        public static Admin CurrentAdmin = null;
        public static User CurrentUser = null;
        public static Boolean[] OrdineFiltri;
       
        public static List<Evento> listaEventiStorico;
        public static List<Evento> listaEventiCorso;
        public static List<Evento> listaEventi;
        public static List<News> listaNews;
        public static List<Interesse> interessi;
        public static List<Admin> aziende;
        public static List<Evento> listaEventiAzienda;
        public static List<Evento> listaEventiIncorsoAzienda;
        public static List<Evento> listEventoAziendaPassato;
        public static List<News> listaNewsAzienda;
        public static List<String[]> Presenze;
        public static string token="";

        public static bool AccesCons { get;  set; }
    }
}
