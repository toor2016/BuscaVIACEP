﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;

namespace ViaCEP_Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            maskedTextBoxCep.Focus();

        }

        public async void GetCep (string cep, string formatoRetorno)
        {
            string uri = "http://viacep.com.br/ws/" + cep.Trim() + "/" + formatoRetorno.Trim() + "/";

            HttpClient cliente = new HttpClient();

            HttpResponseMessage resposta = await cliente.GetAsync(uri);

            HttpContent conteudo = resposta.Content;

            string resultado = await conteudo.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(resultado))
            {
               
            }
            else
            {
               
            }

        }

        private void buttonPesquisar_Click(object sender, RoutedEventArgs e)
        {
            if(maskedTextBoxCep.Text.Trim().Length < 8)
            {
                MessageBox.Show("Verifique o CEP...");
                maskedTextBoxCep.Focus();
                return;
            }

            if(comboBoxFormatoRetorno.Text.Trim().Length == 0)
            {
                MessageBox.Show("Verifique o Formato do Retorno...");
                comboBoxFormatoRetorno.Focus();
                return;
            }

            GetCep(maskedTextBoxCep.Text, comboBoxFormatoRetorno.Text);

            maskedTextBoxCep.Focus();

        }

        private void maskedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
