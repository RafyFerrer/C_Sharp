using System;

namespace Figuras_Trigonometria
{

    class Program
    {
        public static void Main(String[] args)
        {
            bool lecturacomprobada = false;
            double c_uno = 0;
            double c_dos = 0;

            triangulo tri = new triangulo(0, 0, 0);
            do
            {
                try
                {
                    Console.WriteLine("Introduce el valor del primer cateto\n");
                    string c_uno_consola = "";
                    c_uno_consola = Console.ReadLine();
                    c_uno = double.Parse(c_uno_consola);
                    lecturacomprobada= true;
                } catch (Exception e)
                {
                    Console.WriteLine("Dato no válido, por favor introduzca dato válido");

                }
            } while (!lecturacomprobada);

            lecturacomprobada = false;
            do
            {
                try
                {
                    Console.WriteLine("Introduce el valor del segundo cateto\n");
                    string c_dos_consola = "";
                    c_dos_consola = Console.ReadLine();
                    c_dos = double.Parse(c_dos_consola);
                    lecturacomprobada = true;
                }catch(Exception e)
                {
                    Console.WriteLine("Dato introducido erróneo, por favor introduzca número correcto");
                }
            }while (!lecturacomprobada);

            tri.setCatetoUno(c_uno);
            tri.setCatetoDos(c_dos);
            tri.CalculaHipotenusa();
            
            Console.WriteLine("el valor de la hipotenusa es : {0}",tri.getHipotenusa());
            Console.WriteLine("el valor del area es: {0}",tri.Area());
        }
    }


    class triangulo
    {
        private double CatetoUno = 0;
        private double CatetoDos = 0;
        private double hipotenusa = 0;

        public void setCatetoUno(double CatetoUno)
        {
            this.CatetoUno = CatetoUno;
        }

        public void setCatetoDos(double CatetoDos)
        {
            this.CatetoDos = CatetoDos;
        }

        public void setHipotenusa(double hipotenusa)
        {
            this.hipotenusa = hipotenusa;
        }

        public double getCatetoUno()
        {
            return this.CatetoUno;
        }
        public double getCatetoDos()
        {
            return this.CatetoDos;

        }

        public double getHipotenusa()

        {

            return this.hipotenusa;
        }

        public triangulo(double catetouno, double catetodos, double hipotenusa)
        {
            this.CatetoUno = catetouno;
            this.CatetoDos = catetodos;
            this.hipotenusa = hipotenusa;

        }

        public double Area()
        {
            return this.CatetoUno * this.CatetoDos / 2;
        }

        public void CalculaHipotenusa()
        {
            double h = Math.Sqrt((Math.Pow(this.CatetoUno, 2)) + (Math.Pow(this.CatetoDos, 2)));
            this.hipotenusa = h;
        }
    }
}
