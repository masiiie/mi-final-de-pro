using System;
using System.Collections.Generic;
using Weboo.ExamenABBE.Utils;

namespace Weboo.ExamenABBE
{
    public class ABBE<T> where T : IComparable<T>
    {
        T val;
        public T Valor { get { return val; } set { val = value; } }
        ABBE<T> iz;
        ABBE<T> der;
        public ABBE<T> Izquierdo { get { return iz; } set { iz = value; } }
        public ABBE<T> Derecho { get { return der; } set { der = value; } }
        public T Maximo
        {
            get
            {
                if (this.Derecho == null) return this.Valor;
                else return this.Derecho.Maximo;
            }
        }
        public T Minimo
        {
            get
            {
                if (this.Izquierdo == null) return this.Valor;
                else return this.Izquierdo.Minimo;
            }
        }
        ABBE(T valor, ABBE<T> izquierdo, ABBE<T> derecho)
        {
            if (izquierdo.Valor.CompareTo(valor) != 0)
            {
                if (derecho.Valor.CompareTo(valor) != 0) throw new Exception("Parametro invalido");
            }
            if (izquierdo.Maximo.CompareTo(derecho.Minimo) == 1) throw new Exception("Parametro invalido");

            val = valor;
            iz = izquierdo;
            der = derecho;
        }
        public ABBE()
        {
            val = default(T);
            iz = null; der = null;
        }
        ABBE(T valor)
        {
            val = valor;
            der = null; iz = null;
        }

        public void Inserta(T valor)
        {
            if (this.EsHoja() && this.Valor==null || this.Valor.CompareTo(default(T))==0) this.Valor = valor;
            else if (this.EsHoja())
            {
                if (valor.CompareTo(this.Valor) == -1)
                {
                    this.Izquierdo = new ABBE<T>(valor);
                    this.Derecho = new ABBE<T>(this.Valor);
                }
                else
                {
                    this.Derecho = new ABBE<T>(valor);
                    this.Izquierdo = new ABBE<T>(this.Valor);
                }
            }
            else
            {
                if (valor.CompareTo(this.Valor) == -1) this.Izquierdo.Inserta(valor);
                else if (valor.CompareTo(this.Valor) == 1) this.Derecho.Inserta(valor);
            }
        }
        public bool EsHoja()
        {
            if (this.Izquierdo == null && this.Derecho == null) return true;
            return false;
        }

        public IEnumerable<Frecuencia<T>> FrecuenciaPorValor()
        {
            var result = new List<Frecuencia<T>>();
            var aux = new List<Frecuence<T>>();
            var annadidos = new List<T>();
            foreach (T item in this.EntreOrden())
            {
                if (annadidos.Contains(item))
                {
                    foreach (Frecuence<T> element in aux)
                    {
                        if (element.valor.CompareTo(item) == 0)
                        {
                            element.Cantidad++;
                            break;
                        }
                    }
                }
                else
                {
                    annadidos.Add(item);
                    var fre = new Frecuence<T>();
                    fre.valor = item;
                    fre.Cantidad = 1;
                    aux.Add(fre);
                }
            }

            //ahora voy a pasar los valores a la lista original
            foreach (Frecuence<T> item in aux)
            {
                result.Add(new Frecuencia<T>(item.valor, item.Cantidad));
            }
            return result;

        }
        public IEnumerable<T> EntreOrden()
        {
            if (this.EsHoja()) yield return this.Valor;
            else
            {
                foreach (T item in this.Izquierdo.EntreOrden())
                {
                    yield return item;
                }
                yield return this.Valor;
                foreach (T item in this.Derecho.EntreOrden())
                {
                    yield return item;
                }
            }
        }
    }
    public class Frecuence<T> where T : IComparable<T>
    {
        public T valor;
        public int Cantidad;
        public Frecuence()
        {
            valor = default(T);
            Cantidad = 0;
        }
    }
}
