using System;
using System.Collections.Generic;

namespace Builder
{
    public class MainApp
    {

        public static void Main()
        {
            Pedido builder;

            // Crea Heladeria con constructores de helados

            Heladeria Heladeria = new Heladeria();

            // Construir y mostrar el helado resultante

            builder = new Copa();
            Heladeria.Construct(builder);
            builder.Helado.Show();


            Console.ReadKey();
        }
    }


    // La clase 'Director' construye un objeto mediante la interfaz Builder

    class Heladeria
    {
        // Builder utiliza una compleja serie de pasos

        public void Construct(Pedido pedido)
        {
            pedido.BuildTamaño();
            pedido.BuildPrecio();
            pedido.BuildSalsas();
            pedido.BuildFrutas();
        }
    }

    // La clase abstracta 'Builder'

    abstract class Pedido
    {
        protected Helado helado;

        // Obtiene la instancia de helado  

        public Helado Helado
        {
            get { return helado; }
        }

        // Métodos de compilación abstractos

        public abstract void BuildTamaño();
        public abstract void BuildPrecio();
        public abstract void BuildSalsas();
        public abstract void BuildFrutas();
    }

    // La clase 'ConcreteBuilder1' construye y ensambla partes del producto mediante la implementación de la interfaz Builder
    //define y realiza un seguimiento de la representación que crea proporciona una interfaz para recuperar el producto

    class Copa : Pedido
    {
        public Copa()
        {
            helado = new Helado("Helado con frutas");
        }

        public override void BuildTamaño()
        {
            helado["tamaño"] = "Copa helado grande";
        }

        public override void BuildPrecio()
        {
            helado["precio"] = " $5.00 ";
        }

        public override void BuildSalsas()
        {
            helado["salsas"] = "2";
        }

        public override void BuildFrutas()
        {
            helado["frutas"] = "4";
        }
    }

    // La clase 'Producto' representa el objeto complejo en construcción.
    // ConcreteBuilder construye la representación interna del producto y define el proceso mediante el cual se ensambla.


    class Helado
    {
        private string _tipohelado;
        private Dictionary<string, string> _parts =
          new Dictionary<string, string>();

        // Constructor especifica una interfaz abstracta para crear partes de un objeto

        public Helado(string tipohelado)
        {
            this._tipohelado = tipohelado;
        }

        // Indizador
        public string this[string key]
        {
            get { return _parts[key]; }
            set { _parts[key] = value; }
        }

        // muestra el resultante del metodo
        public void Show()
        {
            Console.WriteLine("Tipo de Helado : {0}", _tipohelado);
            Console.WriteLine(" Tamaño : {0}", _parts["tamaño"]);
            Console.WriteLine(" Precio : {0}", _parts["precio"]);
            Console.WriteLine(" Salsas: {0}", _parts["salsas"]);
            Console.WriteLine(" Frutas : {0}", _parts["frutas"]);
        }
    }
}
