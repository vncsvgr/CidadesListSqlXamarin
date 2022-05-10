using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CidadesListSql
{
    public partial class MainPage : ContentPage
    {
        Cidade c = new Cidade();

        public MainPage()
        {
            InitializeComponent();
            carregarDados();
        }

        void limpar()
        {
            txtID.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtUF.Text = string.Empty;
            sbCidade.Text = string.Empty;
        }

        void carregarDados()
        {
            c = new Cidade();
            lstCidades.ItemsSource = c.Listar(sbCidade.Text);
        }

        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtUF.Text))
            {
                DisplayAlert("Atenção", "Favor completar as informações do cadastro", "OK");
                return;
            }

            c = new Cidade
            {
                nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Incluir();
            limpar();
            carregarDados();
        }

        private void btnAtualizar_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnExcluir_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                await DisplayAlert("Atenção", "", "OK");
                return;
            }
        }

        private void sbCidade_TextChanged(object sender, TextChangedEventArgs e)
        {
            carregarDados();
        }

        private void lstCidades_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            c = e.SelectedItem as Cidade;

            txtID.Text = c.id.ToString();
            txtNome.Text = c.nome;
            txtUF.Text = c.uf;
        }

        private void btnFinalizar_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
