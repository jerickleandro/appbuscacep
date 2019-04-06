using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App_BuscaCep.Servico.Modelo;
using App_BuscaCep.Servico;

namespace App_BuscaCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {

            // Validações


            //Buscar - Logica

            string cep = CEP.Text.Trim();
            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);


                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0},{1} {2} {3}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("Erro.", "O endereço não foi encontrado para o CEP informado: " + cep, "Ok");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro crítico", e.Message, "OK");
                }

            }
        }
        private bool isValidCEP(string cep)
        {

            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP Invalido! O CEP deve conter 8 caracteres.", "Ok");
                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "CEP Invalido! O CEP deve conter apenas numeros", "Ok");
                valido = false;
            }

            return valido;

        }
    }
}
