using System;
using System.Collections.Generic;

namespace Menu
{
    class MenuPrincipal
    {
        private List<Menu> menus;
        private int currentMenuIndex = 0;
        private int currentItemIndex = 0;

        public MenuPrincipal(Dictionary<string, string[]> menus)
        {
            this.menus = new List<Menu>();
            int pos = 1;
            foreach (var subMenu in menus)
            {
                this.menus.Add(new Menu(pos++, subMenu.Key, subMenu.Value));
            }
        }

        public void Dibujar()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);


            for (int i = 0; i < menus.Count; i++)
            {
                if (i == currentMenuIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.SetCursorPosition(i * 20, 1);
                Console.Write(menus[i].nombreMenu);
                Console.ResetColor();
            }

            int columna = currentMenuIndex * 20;
            int fila = 3;
            for (int j = 0; j < menus[currentMenuIndex].items.Length; j++)
            {
                if (j == currentItemIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.SetCursorPosition(columna, fila++);
                Console.WriteLine(menus[currentMenuIndex].items[j]);
                Console.ResetColor();
            }
        }

        public void Navegar()
        {
            bool running = true;
            while (running)
            {
                Dibujar();
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.RightArrow:
                        currentMenuIndex = (currentMenuIndex + 1) % menus.Count;
                        currentItemIndex = 0; 
                        break;
                    case ConsoleKey.LeftArrow:
                        currentMenuIndex = (currentMenuIndex - 1 + menus.Count) % menus.Count;
                        currentItemIndex = 0; 
                        break;
                    case ConsoleKey.DownArrow:
                        currentItemIndex = (currentItemIndex + 1) % menus[currentMenuIndex].items.Length;
                        break;
                    case ConsoleKey.UpArrow:
                        currentItemIndex = (currentItemIndex - 1 + menus[currentMenuIndex].items.Length) % menus[currentMenuIndex].items.Length;
                        break;
                    case ConsoleKey.Enter:
                        EjecutarAccion();
                        break;
                    case ConsoleKey.Escape:
                        running = false;
                        break;
                }
            }
        }

        private void EjecutarAccion()
        {
            string selectedItem = menus[currentMenuIndex].items[currentItemIndex];
            Console.Clear();
            Console.WriteLine($"Has seleccionado: {selectedItem}");
            Console.WriteLine("Presiona cualquier tecla para volver al menú...");
            Console.ReadKey();
        }
    }
}
