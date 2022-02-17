using System;

namespace PatronesDiseño
{
    class Program
    {
        static void Main(string[] args)
        {
            //Patron de diseño Singleton

            /*Console.WriteLine(Singleton.Instance.msj);
            Singleton.Instance.msj = "Bienvenido";
            Console.WriteLine(Singleton.Instance.msj);*/

            /*-----------------------------------------*/

            //Patron de diseño Adapter

            /*Guitarra gElectrica = new GuitarraElectrica();
            gElectrica.encenderGuitarra();
            gElectrica.apagarGuitarra();

            Guitarra gAcustica = new GuitarraElectroAcustica();
            gAcustica.encenderGuitarra();
            gAcustica.apagarGuitarra();*/

            /*--------------------------------------------*/

            //Patron de diseño Factory Method

            /*BebidaEMbriagante bebida = Creador.CreadorBebida(Creador.VINO);
            Console.WriteLine(bebida.CantidadBorracheraPorHora());*/

            /*--------------------------------------------*/


        }


        /*********************Patron de diseño Singleton*************************/
        public class Singleton
        {
            private static Singleton instance = null;
            public string msj = "";
            protected Singleton() {
                msj = "Buenas!";
            }

            public static Singleton Instance
            {
                get
                {
                    if(instance == null)
                    
                        instance = new Singleton();

                        return instance;
                    
                }
            }
        }


        /*********************Patron de diseño Adapter*************************/

        //clase abstracta de una guitarra electrica, funciona con un dispositivo electrico por eso se apaga y prende
        public abstract class Guitarra
        {
            abstract public void encenderGuitarra();
            abstract public void apagarGuitarra(); 
        }

        public class GuitarraElectrica : Guitarra
        {
            public override void apagarGuitarra()
            {
                Console.WriteLine("Silencio");
            }

            public override void encenderGuitarra()
            {
                Console.WriteLine("Tocar");
            }
        }


        //Queremos adaptar la guitarra acustica que herede de la clase abstracta de guitarra
        //pero la guitarra acustica no funciona con dispositivo electrico por lo que no puede prender ni apagarse
        //en este caso necisatamos una clase adaptador
        public class GuitarraAcutica
            {
                public void tocar()
                {
                    Console.WriteLine("Tocar");
                }

                public void dejardetocar()
                {
                    Console.WriteLine("Silencio"); 
                }
            }

            //clase adaptador
            public class GuitarraElectroAcustica : Guitarra
                {
                    GuitarraAcutica acustica = new GuitarraAcutica();

                    public override void apagarGuitarra()
                    {
                        acustica.dejardetocar();
                    }

                    public override void encenderGuitarra()
                    {
                        acustica.tocar();
                    }
                }

        /*********************Patron de diseño Fsctory Method*************************/
            public abstract class BebidaEMbriagante
        {
            public abstract int CantidadBorracheraPorHora();
        }

        public class VinoLaFuerza : BebidaEMbriagante
        {
            public override int CantidadBorracheraPorHora()
            {
                return 10;
            }
        }

        public class Cerveza : BebidaEMbriagante
        {
            public override int CantidadBorracheraPorHora()
            {
                return 20; 
            }
        }

        public class Creador
        {
            public const int VINO = 1;
            public const int CERVEZA = 2;

            public static BebidaEMbriagante CreadorBebida(int tipo)
            {
                switch (tipo)
                {
                    case VINO:
                        return new VinoLaFuerza();
                    case CERVEZA:
                        return new Cerveza();
                    default: return null;
                }
            }
        }


    }
}
