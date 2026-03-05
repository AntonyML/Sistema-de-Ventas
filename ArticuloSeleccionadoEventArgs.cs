namespace sistema_de_ventas
{
    public class ArticuloSeleccionadoEventArgs
    {
        private string columna4;
        private string columna5;

        public int Columna7 { get; }
        public string Columna0 { get; }
        public string Columna2 { get; }
        public string Columna3 { get; }

        public ArticuloSeleccionadoEventArgs(int columna7, string columna0, string columna2, string columna3)
        {
            Columna7 = columna7;
            Columna0 = columna0;
            Columna2 = columna2;
            Columna3 = columna3;
        }

        public ArticuloSeleccionadoEventArgs(int columna7, string columna0, string columna2, string columna3, string columna4, string columna5) : this(columna7, columna0, columna2, columna3)
        {
            this.columna4 = columna4;
            this.columna5 = columna5;
        }
    }
}