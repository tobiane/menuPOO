namespace Menu
{
    class Menu
    {
        public string[] items;
        public string nombreMenu;
        public int posMenu;

        public Menu(int posMenu, string nombreMenu, string[] opciones)
        {
            this.items = opciones;
            this.nombreMenu = nombreMenu;
            this.posMenu = posMenu;
        }
    }
}
