//IMPORTANDO PACOTES PARA UTILIZAR NO PROJETO
using Microsoft.AspNetCore.Mvc;
using ProjetoLoja.Repositorio;

//DEFINE O NOME E AONDE A CLASSE ESTA LOCALIZADA, NAMESPACE AJUDA A ORGANIZAR O CODIGO
//E EVITAR CONFLITOS DE NOMES
namespace ProjetoLoja.Controllers
{
    //CLASSE USUARIOCONTROLLER QUE ESTA HERDANDO DA CLASSE CONTROLLER
    public class UsuarioController : Controller
    {
        //DECLARA UMA VARIAVEL PRIVADA SOMENTE LEITURA DO TIPO USUARIOREPOSITORIO CHAMADA(INSTANCIANDO) _usuarioRepositorio;
        //UsuarioRepositorio É UMA CLASSE RESPONSAVEL POR INTERAGIR COM A CAMADA DE DADOS E GERENCIA AS INFORMAÇÕES DO USUARIO;
        private readonly UsuarioRepositorio _usuarioRepositorio;

        // CONSTRUTOR QUE RECEBE A INSTANCIA USUARIOREPOSITORIO COM PARAMETROS (INJEÇÃO DE DEPENDECIA)
        //PARA SER INICIALIZADO.

        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        //INTERFACE É UMA REPRESENTAÇAO DO RESULTADO (TELA)
        public IActionResult Login()
        {
            //RETORNA A PAGINA INDEX
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _usuarioRepositorio.ObterUsuario(email);

            if(usuario != null && usuario.senha != senha)
            {
                return RedirectToAction("Index", "Cliente");
            }
            ModelState.AddModelError("", "Email / senha Inválidos");


            //RETORNA A PAGINA INDEX
            return View();
        }
    }
}
