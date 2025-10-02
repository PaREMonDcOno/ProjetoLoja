namespace ProjetoLoja.Models
{
    public class Usuario
    {
        //acessores realizando o encapsulamento dos dos dados
        public int Id {get;set;} 
        public string ?Nome{ get; set; }
        public string ?Email{ get; set; }
        public string ?Senha{ get; set; }    

    }
}
