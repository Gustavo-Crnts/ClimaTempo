using ClimaTempo.Models;
using ClimaTempo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClimaTempo.ViewModels
{
    public partial class CidadeViewModel : ObservableObject
    {
        
        //Dados da pesquisa
        [ObservableProperty]
        private string cidade_pesquisada;

        [ObservableProperty]
        private ObservableCollection<Cidade> cidade_list;

        public ICommand BuscarCidadeCommand { get; }
        public CidadeViewModel()
        {
            BuscarCidadeCommand = new Command(BuscarCidade);
        }

        public async void BuscarCidade()
        {
            Cidade_list = new ObservableCollection<Cidade>();
            Cidade_list = await new CidadeService().GetCidadeByName(cidade_pesquisada);

        }
















    }
}
