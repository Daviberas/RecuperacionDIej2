using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperacionDIej2.Models
{
    public class clsPersona:INotifyPropertyChanged
    {
        //Atributos
        private int _id;
        private String _nombre; 
        private String _apellidos; 
        private DateTime _fechaNac; 
        private String _direccion; 
        private String _telefono;
        public event PropertyChangedEventHandler PropertyChanged;

        //Constructores
        public clsPersona()
        {
            _id = 0;
            _nombre = "";
            _apellidos = "";
            _fechaNac = DateTime.Now;
            _direccion = "";
            _telefono = "";
        }

        public clsPersona(int id, String nombre, String apellidos, DateTime fechaNac, String direccion, String telefono)
        {
            _id = id;
            _nombre = nombre;
            _apellidos = apellidos;
            _fechaNac = fechaNac;
            _direccion = direccion;
            _telefono = telefono;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public String Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                OnPropertyChanged("Nombre");
            }
        }

        public String Apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                _apellidos = value;
                OnPropertyChanged("Apellidos");
            }
        }

        public DateTime FechaNac
        {
            get
            {
                return _fechaNac;
            }
            set
            {
                _fechaNac = value;
                OnPropertyChanged("FechaNac");
            }
        }

        public String Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
                OnPropertyChanged("Direccion");
            }
        }

        public String Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
                OnPropertyChanged("Telefono");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
