using Ortiz_J_Practica_Navegacion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ortiz_J_Practica_Navegacion.ViewModels
{
    // Recibo los datos que mande con el GoToAsync
    [QueryProperty(nameof(Nombre), "nombre")]
    [QueryProperty(nameof(Descripcion), "descripcion")]
    [QueryProperty(nameof(Precio), "precio")]
    public class DetalleViewModel : INotifyPropertyChanged
    {
        // Variables privadas para guardar los datos
        private string nombre;
        private string descripcion;
        private decimal precio;

        //Propiedad para exponer el nombre a la vista apra el binding
        public string Nombre
        {
            get => nombre;
            set { nombre = value; OnPropertyChanged(); }
        }

        //Propiedad para exponer la descripcion a la vista apra el binding
        public string Descripcion
        {
            get => descripcion;
            set { descripcion = value; OnPropertyChanged(); }
        }

        //Propiedad para exponer el precio a la vista apra el binding
        public decimal Precio
        {
            get => precio;
            set { precio = value; OnPropertyChanged(); }
        }

        //Evento de la interfaz
        public event PropertyChangedEventHandler? PropertyChanged;

        //Metodo de la interfaz
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

