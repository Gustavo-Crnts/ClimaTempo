using ClimaTempo.Models;
using ClimaTempo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClimaTempo.ViewModels
{
    public partial class PrevisaoViewModel : ObservableObject //partial: significa que precisa de outra classe pra funcionar
    {
        [ObservableProperty]
        private string cidade;
        [ObservableProperty]
        private string estado;
        [ObservableProperty]
        private string condicao;
        [ObservableProperty]
        private string condicao_desc;
        [ObservableProperty]
        private DateTime data;
        [ObservableProperty]
        private double max;
        [ObservableProperty]
        private double min;
        [ObservableProperty]    
        private double indiceuv;

        [ObservableProperty]
        private List<Clima> proximosDias;

        private Previsao previsao;
        private Previsao proxPrevisao;

        
        //Dados da lista de cidades 

        public ICommand BuscarPrevisaoCommand { get; set; }

        public PrevisaoViewModel()
        {
            BuscarPrevisaoCommand = new Command(BuscarPrevisao);
        }

        public async void BuscarPrevisao()
        {
            previsao = await new PrevisaoService().GetPrevisaoById(244);

            Cidade = previsao.Cidade;
            Estado = previsao.Estado;
            Condicao = previsao.clima[0].Condicao;
            Condicao_desc = previsao.clima[0].Condicao_desc;
            Data = previsao.clima[0].Data;
            Max = previsao.clima[0].Max;
            Min = previsao.clima[0].Min;
            Indiceuv = previsao.clima[0].Indiceuv;

            proxPrevisao = await new PrevisaoService().GetPrevisaoForXDaysById(244, 3);
            ProximosDias = proxPrevisao.clima;

        }

       


    }
}
