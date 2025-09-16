using Ortiz_J_Practica_Navegacion.Views;

namespace Ortiz_J_Practica_Navegacion
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(DetallePage), typeof(DetallePage)); // Registro la nueva pagina (detalles producto)
        }
    }
}
