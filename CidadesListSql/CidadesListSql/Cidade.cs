using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;

namespace CidadesListSql
{
    public class Cidade
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }

        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader rConsulta;
        string strConexao = "server=br536.hostgator.com.br;uid=dsetec86_aula;pwd=etecjau;database=dsetec86_bd_xamarin";

        List<Cidade> cidades = new List<Cidade>();

        public List<Cidade> Listar(string nome)
        {
            try
            {
                conexao = new MySqlConnection(strConexao);
                conexao.Open();
                comando = new MySqlCommand("select * from cidadew where nome like @nome order by nome", conexao);
                comando.Parameters.AddWithValue("@nome", nome + "%");
                rConsulta = comando.ExecuteReader();
                while (rConsulta.Read())
                {
                    Cidade c = new Cidade()
                    {
                        id = int.Parse(rConsulta["ID"].ToString()),
                        nome = rConsulta["NOME"].ToString(),
                        uf = rConsulta["UF"].ToString()
                    };
                    cidades.Add(c);
                }
                conexao.Close();
                return cidades;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async void Incluir()
        {
            try
            {
                conexao = new MySqlConnection(strConexao);
                conexao.Open();
                comando = new MySqlCommand("insert into cidades (nome, uf) " +
                                                       "values (@nome, @uf)", conexao);
                comando.Parameters.AddWithValue("@nome", nome);
                comando.Parameters.AddWithValue("@uf", uf);
                comando.ExecuteNonQuery();
                conexao.Close();
            }
            catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public async void Atualizar()
        {

        }
    }
}
