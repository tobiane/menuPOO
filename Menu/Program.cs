using System;
using System.Collections.Generic;

namespace Menu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] menu1 = { "Nuevo ", "Abrir", "Clonar Repositorio" };
            string[] menu2 = { "Ir a", "Buscar y Reemplazar", "Ir a base" };
            string[] menu3 = { "Codigo", "Abrir", "Abrir con" };

            var menus = new Dictionary<string, string[]>
            {
                { "Archivo", menu1 }, { "Editar", menu2 }, { "Ver", menu3}
            };

            MenuPrincipal menu = new MenuPrincipal(menus);
            menu.Navegar();
        }
    }
}
