using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Projeto_Agenda.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Agenda.ViewModel
{
    partial class ViewModel: ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<ItemLista> lista;

        Repositorio bd = new();

        [ObservableProperty]
        string texto;

        [ObservableProperty]
        DateTime horario;

        [ObservableProperty]
        string diaDaSemana;

        [ObservableProperty]
        DateTime datetimeRetorno;

        public ViewModel()
        {
            Lista = new(bd.GetItems());
            ConsultaData();

        }

        [RelayCommand]
        void Inserir()
        {
            var item = new ItemLista();
            item.Item = Texto;
            item.Horario = horario;


            if (bd.Inserir(item) > 0)
            {
                Lista.Add(item);
            }
            else
            {

            }
        }

        [RelayCommand]
        void Apagar(ItemLista item)
        {
            Lista.Remove(item);
            bd.Delete(item);
        }

        [RelayCommand]
        void Organizar(ItemLista item)
        {
            Lista = new(Lista.OrderBy((e) => e.Horario));
        }

        class WorldTime
        {
            public DateTime datetime { get; set; }
            public int day_of_week { get; set; }
            public int day_of_year { get; set; }
            public int week_number { get; set; }
        }


        [ObservableProperty]
        int day_of_weekRetorno;

        [ObservableProperty]
        int day_of_yearRetorno;

        [ObservableProperty]
        int week_numberRetorno;

        async void ConsultaData()
        {
            var url = "https://worldtimeapi.org/api/timezone/America/Sao_Paulo";
            var cliente = new HttpClient();
            var resposta = await cliente.GetAsync(url);
            if (resposta.StatusCode == HttpStatusCode.OK)
            {
                var conteudo = await resposta.Content.ReadFromJsonAsync<WorldTime>();
                DatetimeRetorno = conteudo.datetime;
                Day_of_weekRetorno = conteudo.day_of_week;
                Day_of_yearRetorno = conteudo.day_of_year;
                Week_numberRetorno = conteudo.week_number;

                switch (Day_of_weekRetorno)
                {
                    case 0:
                        diaDaSemana = "Domingo";
                        break;
                    case 1:
                        diaDaSemana = "Segunda-Feira";
                        break;
                    case 2:
                        diaDaSemana = "Terça-Feira";
                        break;
                    case 3:
                        diaDaSemana = "Quarta-Feira";
                        break;
                    case 4:
                        diaDaSemana = "Quinta-feira";
                        break;
                    case 5:
                        diaDaSemana = "Sexta-feira";
                        break;
                    case 6:
                        diaDaSemana = "Sábado";
                        break;
                }

                Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(1000);
                        DatetimeRetorno = DatetimeRetorno.AddSeconds(1);
                        
                    }
                });


            }
        }
    }
}
