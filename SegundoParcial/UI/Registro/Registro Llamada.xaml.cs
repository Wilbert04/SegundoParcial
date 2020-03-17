using SegundoParcial.BLL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SegundoParcial.UI.Registro
{
    /// <summary>
    /// Interaction logic for RLlamada.xaml
    /// </summary>
    public partial class RLlamada : Window
    {
        
        Llamada llamada = new Llamada();

        public RLlamada()
        {
            InitializeComponent();
            this.DataContext = llamada;
            
        }

        private void Limpiar()
        {
            IdTextbox.Text = "0";
            DescripcionTextbox.Text = string.Empty;
           

        }

        private void Button_Nuevo(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void IdTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private void DescripcionTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }

        }

        private void ProblemaTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }

        }

        private void SolucionTextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[a-zA-Z]"))
            {
                e.Handled = true;
            }

        }

        private bool Validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(DescripcionTextbox.Text))
            {
                MessageBox.Show("Descripcion no puede estar vacio");
                DescripcionTextbox.Focus();
                paso = false;
            }
            return paso;
        }

        private bool ExisteEnBaseDato()
        {
            Llamada llamada = LlamadaBLL.Buscar(Convert.ToInt32(IdTextbox.Text));
            return (llamada != null);
        }


        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = llamada;
        }

        private void Button_Guardar(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!Validar())
                return;

            if (IdTextbox.Text == "0")
                paso = LlamadaBLL.Guardar(llamada);

            else
            {
                if (!ExisteEnBaseDato())
                {
                    MessageBox.Show("No puede modificar una llamada que no existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                paso = LlamadaBLL.Modificar(llamada);
            }

            if (paso)
            {
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No se Guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Eliminar(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextbox.Text, out id);



            if (LlamadaBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado con exito!!!", "ELiminado", MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show(" No eliminado !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Buscar(object sender, RoutedEventArgs e)
        {
            int id;
            Llamada llamada1 = new Llamada();
            int.TryParse(IdTextbox.Text, out id);

            llamada1 = LlamadaBLL.Buscar(id);

            if (llamada1 != null)
            {
                MessageBox.Show("Persona Encontrada");
                llamada = llamada1;
                Cargar();
            }
            else
            {
                MessageBox.Show(" No se encontrado la llamda !!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_AgregarDetalle(object sender, RoutedEventArgs e)
        {

            llamada.Detalles.Add(new LlamadaDetalle(llamada.LlamadaId, ProblemaTextbox.Text, SolucionTextbox.Text));
            Cargar();
            
            ProblemaTextbox.Clear();
            SolucionTextbox.Clear();
        }

        private void Button_Remover(object sender, RoutedEventArgs e)
        {
            if (DataGrid.Columns.Count > 0 && DataGrid.SelectedCells != null)

                llamada.Detalles.RemoveAt(DataGrid.SelectedIndex);

            Cargar();
        }
    }
}
