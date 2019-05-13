﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventUPv2
{
   public class EventoManager
    {
        IRestServiceEvento restService;

        public EventoManager(IRestServiceEvento service)
        {
            restService = service;
        }

        public Task<List<Evento>> GetTasksAsync(int tipo, String testoRicerca, int ordinamentoFiltri)
        {
            return restService.RefreshDataAsync(tipo, testoRicerca, ordinamentoFiltri);
        }

        public Task SaveTaskAsync(Evento item, bool isNewItem = false)
        {
            return restService.SaveTodoItemAsync(item, isNewItem);
        }
        public Task DeleteTaskAsync(Evento ad)
        {
            return restService.DeleteTodoItemAsync(ad);
        }
    }
}
