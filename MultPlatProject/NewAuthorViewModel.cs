using Flurl;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MultPlatProject
{
    public class NewAuthorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<ErrorResponse> RequestFailed;

        public event EventHandler AuthorAdded;

        string mName;

        public string Name
        {
            get => mName; // No getter, meramente retorna variável interna
            set
            {
                // No setter, primeiro verifica se valor sendo atribuido é
                // diferente do atual
                if (!Equals(mName, value))
                {
                    // Se for, atribui novo valor a variável interna.
                    mName = value;

                    // E dispara evento indicando que a propriedade Authors mudou.
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }


        public ICommand PostCommand { get; private set; }

        public NewAuthorViewModel()
        {
            // Função para ser executada quando o GetCommand for executado.
            async void execute()
            {
                try
                {
                    var author = new Author() { Name = mName };
                    // Vai atualizar autores
                    var httpResponse = await

                        // Começa pegando url do web service, como string
                        Constants.BaseServiceUrl

                                 // Namespace Flurl adiciona extensão em string
                                 // para concatenar mais um pedaço de rota a URL.
                                 // No caso, o pedaço da rota é o nome da classe
                                 // Author, para consultar os autores.
                                 .AppendPathSegment(typeof(Author).Name)

                                 // Namespace Flurl também adiciona extensão em 
                                 // Url para realizar requisição HTTP GET na URL
                                 // especificada e, daí, desserializar o retorno
                                 // como um tipo passado (no caso, uma List de Book.
                                 .PostJsonAsync(author);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        AuthorAdded?.Invoke(this, new EventArgs());
                    }
                }
                // Se webservice retornar erro, lança uma FlurlHttpException
                catch (FlurlHttpException ex)
                {
                    // Nesse caso, pega o corpo da resposta de erro e
                    // desserializa como um DTO ErrorResponse
                    var error = await ex.GetResponseJsonAsync<ErrorResponse>();

                    // Invoca evento de requisição zoada.
                    RequestFailed?.Invoke(this, error);
                }
            }

            // Atribui valor ao comando.
            PostCommand = new Command(execute);
        }
    }
}
