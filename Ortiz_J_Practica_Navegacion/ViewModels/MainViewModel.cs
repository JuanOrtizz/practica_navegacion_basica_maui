using Ortiz_J_Practica_Navegacion.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Ortiz_J_Practica_Navegacion.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Lista de productos
        private ObservableCollection<ProductoModel> _productos { get; set; }

        // Producto individual seleccionado
        private ProductoModel _productoSeleccionado;

        //Propiedad que expone la lista de productos a la vista para binding
        public ObservableCollection<ProductoModel> Productos 
        {
            get => _productos;
            set
            {
                if (_productos != value)
                {
                    _productos = value;
                    OnPropertyChanged();
                }
            }
        }

        // Propiedad del producto seleccionado que dispara navegacion al cambiar
        public ProductoModel ProductoSeleccionado
        {
            get => _productoSeleccionado;
            set
            {
                if (_productoSeleccionado != value)
                {
                    _productoSeleccionado = value;
                    OnPropertyChanged();
                    if (_productoSeleccionado != null)
                        IrADetalleCommand.Execute(_productoSeleccionado);// Ejecuta el comando
                }
            }
        }

        //Declaro el comando
        public Command IrADetalleCommand { get; }

        public MainViewModel()
        {
            //Creo productos apra mostrar en la vista
            Productos = new ObservableCollection<ProductoModel>
            {
                new ProductoModel { Nombre = "Remera azul", Descripcion="Es una remera azul muy interesante y lisa sin estampados", Precio=12345},
                new ProductoModel { Nombre = "Remera Roja", Descripcion="Es una remera roja muy interesante y lisa sin estampados", Precio=123456},
                new ProductoModel { Nombre = "Remera Amarilla", Descripcion="Es una remera amarilla muy interesante y lisa sin estampados", Precio=1234567},
            };

            //Inicializo el comando
            IrADetalleCommand = new Command<ProductoModel>(async (producto) =>
            {
                if (producto != null)
                {
                    // Armo un diccionario con los parametros a mandar por GoToAsync
                    var parametros = new Dictionary<string, object>
                    {
                        { "nombre", producto.Nombre },
                        { "precio", producto.Precio },
                        { "descripcion", producto.Descripcion }
                    };

                    // Uso ShellNavigationQueryParameters como vimos en la clase del 15 del 9
                    var shellParametros = new ShellNavigationQueryParameters(parametros);
                
                        await Shell.Current.GoToAsync("DetallePage", shellParametros); // Abro la pagina y paso datos 
                    }
            });

        }

        //Evento de la interfaz
        public event PropertyChangedEventHandler? PropertyChanged;

        //Metodo de la interfaz
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
