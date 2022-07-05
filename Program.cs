using System;
using System.Collections;

namespace Telnet_Reynoso_Angel__COM2
{
    class Program
    {
        static void Main(string[] args)
        {
            Empresa miempresa = new Empresa();


            //ADICION DE 3 TECNICOS PARA QUE YA EXISTAN EN LA BASE ALGUNOS DATOS PARA TRABAJAR 
            Tecnico t1 = new Tecnico("Victor Pedrozo", 40347658, 1, "Lanus");
            Tecnico t2 = new Tecnico("Martin Cantero", 33764847, 2, "Lomas");
            Tecnico t3 = new Tecnico("Juan Peralta", 40347658, 3, "Avellaneda");
            miempresa.altaTecnico(t1);
            miempresa.altaTecnico(t2);
            miempresa.altaTecnico(t3);

            int opcion;
            bool bmenu = true;
            Console.WriteLine("------------------------ \n Bienvenido a Telnet \n------------------------ \n");
            Console.WriteLine("Elija una opcion: \n 1) Agregar Cliente \n 2) Agregar técnico \n 3) Administracion de clientes \n 4) Administracion de tecnicos \n 5) Consultas \n 6) Comprobar Cupos \n 7) Salir del Sistema");
            Console.Write("\nOpcion: ");
            opcion = ValidarNumero(7);
            Console.WriteLine();

            while (bmenu)
            {
                switch (opcion)
                {
                    case 1:
                        {
                            while (true)
                            {
                                nuevocliente(ref miempresa);
                                Console.WriteLine("Ingresar otro usuario? Pulse cualquier letra para seguir, N para salir");
                                string op = Console.ReadLine();
                                if (op.ToLower() == "n")
                                { break; }
                            }
                            break;
                        }
                    case 2:
                        {
                            while (true)
                            {
                                nuevoTecnico(ref miempresa);
                                Console.WriteLine("Ingresar otro Técnico? pulse culquier letra para seguir, N para salir");
                                string op = Console.ReadLine();
                                if (op.ToLower() == "n")
                                { break; }
                            }
                            break;
                        }
                    case 3:
                        {
                            int op;
                            Console.WriteLine();
                            Console.WriteLine("***** ADMINISTRACIÓN DE CLIENTES ***** \n\n 1) Modificar Plan y Precio de Cliente \n 2) Dar de baja Cliente \n ");
                            Console.Write("Opción: "); op = ValidarNumero(2);
                            Console.WriteLine();
                            if (op == 1)
                            {
                                Console.WriteLine("Ingrese nro Cliente: ");
                                int nroc = int.Parse(Console.ReadLine());
                                modificarPP(ref miempresa, nroc);
                            }
                            if (op == 2)
                            { eliminarCliente(ref miempresa); }
                            break;
                        }
                    case 4:
                        {
                            int op;
                            Console.WriteLine();
                            Console.WriteLine("\n***** ADMINISTRACIÓN DE TÉCNICOS ***** \n\n 1) Eliminar Técnico \n ");
                            Console.Write("Opción: "); op = ValidarNumero(1);
                            Console.WriteLine();

                            if (op == 1)
                            { eliminarTecnico(ref miempresa); }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("\n1) Lista de Clientes \n2) Total Clientes Registrados \n3) Lista de tecnicos \n4) Total de Tecnicos Registrados");
                            Console.Write("Opcion: ");
                            int op = ValidarNumero(4);

                            switch (op)
                            {
                                case 1:
                                    {
                                        listadeclientes(ref miempresa);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine($"\nExisten {miempresa.todoslosClientes().Count} Clientes registrados en el sistema\n");
                                        miempresa.todoslosClientes();
                                        break;
                                    }
                                case 3:
                                    {
                                        listaTecnicos(ref miempresa);
                                        break;
                                    }
                                case 4:
                                    {
                                        Console.WriteLine($"\nExisten {miempresa.todosLosTecnicos().Count} Tecnicos Registrados en el sistema\n");
                                        break;
                                    }
                            }
                            break;
                        }
                    case 6:
                        {
                            int dia, mes, anio;
                            Console.WriteLine("comprobar cupos:");
                            Console.Write("Dia: "); dia = ValidarNumero();
                            Console.Write("Mes: "); mes = ValidarNumero();
                            Console.Write("Año: "); anio = ValidarNumero();

                            comprobarCupos(ref miempresa, dia, mes, anio);
                            break;
                        }
                    case 7:
                        {
                            bmenu = false;
                            break;
                        }
                }
                Console.WriteLine("Elija una opcion: \n 1) Agregar Cliente \n 2) Agregar técnico \n 3) Administracion de clientes \n 4) Administracion de tecnicos \n 5) Consultas \n 6) Comprobar Cupos \n 7) Salir del Sistema");
                Console.Write("\nOpcion: ");
                opcion = ValidarNumero(7);
                if (opcion == 6)
                {
                    bmenu = false;
                }
            }
            Console.WriteLine("Programa Finalizado.");
        }

        // MÉTODO DE ADICIÓN DE CLIENTE
        static void nuevocliente(ref Empresa adicionCliente)
        {
            string nombCliente, tipodePlan;
            int numeroCliente, dniCliente, dia, mes, anio, codTecnico;
            DateTime fechaAlta;
            double precioPlan;
            Cliente nuevoCLiente;
            Tecnico asociarTecnico;
            ArrayList listTecnico = new ArrayList(adicionCliente.todosLosTecnicos());

            Console.Write("Ingrese Nombre de Cliente: "); nombCliente = Console.ReadLine();
            numeroCliente = 101000 + adicionCliente.cantidadCliente();
            numeroCliente++;
            Console.WriteLine($"Numero de cliente: {numeroCliente} ");
            Console.Write("Ingrese DNI: "); dniCliente = ValidarNumero();
            Console.Write("Dia: "); dia = ValidarNumero();
            Console.Write("Mes: "); mes = ValidarNumero();
            Console.Write("Año: "); anio = ValidarNumero();
            fechaAlta = new DateTime(anio, mes, dia);
            Console.Write("Tipo de Plan: "); tipodePlan = Console.ReadLine();
            Console.Write("Precio del Plan: $"); precioPlan = ValidarNumeroDecimal();
            Console.Write("Ingrese Nro de tecnico para asociar: "); codTecnico = ValidarNumero();
            asociarTecnico = new Tecnico(codTecnico);

            while (true)
            {
                foreach (Tecnico varTempTecnic in listTecnico)
                {
                    try
                    {
                        if (varTempTecnic.NrodeTecnico == codTecnico)
                        {
                            asociarTecnico = varTempTecnic;                         // REVISAAAAAAAAAAAAAAAAAAAR   ##############################################
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("El Nro de tecnico ingresado no coincide, intenta otra vez");
                        Console.Write("Ingrese Nro de tecnico para asociar: "); codTecnico = int.Parse(Console.ReadLine());
                    }
                }
                break;
            }

            nuevoCLiente = new Cliente(nombCliente, numeroCliente, dniCliente, fechaAlta, tipodePlan, precioPlan, asociarTecnico);
            adicionCliente.altaCliente(nuevoCLiente);

            Console.WriteLine("Cliente registrado exitosamente. \n");
        }
        //METODO MODIFICACION DE PRECIO DE CLIENTE
        static void modificarPP(ref Empresa miempresa, int nrocliente)
        {
            ArrayList listaclient;
            listaclient = new ArrayList(miempresa.todoslosClientes());
            foreach (Cliente modCliente in listaclient)
            {
                if (modCliente.NumeroCliente == nrocliente)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine($"Cliente: {modCliente.NombreCliente} \n " +
                        $" Nro de Cliente: {modCliente.NumeroCliente} \n" +
                        $"DNI: {modCliente.DniCliente}\n" +
                        $"Fecha de alta: {modCliente.FechaDeAlta}\n" +
                        $"Plan: {modCliente.TipoDePlan}\n" +
                        $"Precio: ${modCliente.PreciodePlan}\n" +
                        $"Tecnico Asignado: {modCliente.TecnicoAsignado}\n");

                    string pal;
                    Console.WriteLine("Desea modificar el valor de precio del cliente? S/N: "); pal = Console.ReadLine();
                    switch (pal.ToUpper())
                    {
                        case "S":                                                                           //REVISAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR ##############################
                            {
                                Console.Write("ingrese nuevo precio: $");
                                double nprecio = ValidarNumeroDecimal();
                                Console.WriteLine("Nombre del nuevo plan: ");
                                string nplan = Console.ReadLine();
                                modCliente.PreciodePlan = nprecio;
                                modCliente.TipoDePlan = nplan;

                                Console.WriteLine("Modificación exitosa");
                            }

                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Cliente No encontrado, intenta colocar de nuevo el nro de cliente: ");
                }
            }
        }
        //MÉTODO DE LISTA DE CLIENTES
        static void listadeclientes(ref Empresa clientes)
        {
            ArrayList listaclientes;
            listaclientes = new ArrayList(clientes.todoslosClientes());
            foreach (Cliente client in listaclientes)
            {
                Console.WriteLine("\n----------------------");
                Console.WriteLine($"Cliente: {client.NombreCliente} \n " +
                    $"Nro de Cliente: {client.NumeroCliente} \n" +
                    $"DNI: {client.DniCliente}\n" +
                    $"Fecha de alta: {client.FechaDeAlta}\n" +
                    $"Plan: {client.TipoDePlan}\n" +
                    $"Precio: {client.PreciodePlan}\n" +
                    $"Tecnico Asignado: {client.TecnicoAsignado.NombreDeTecnico}\n");
            }
        }
        //MÉTODO PARA INGRESAR NUEVO TÉCNICO
        static void nuevoTecnico(ref Empresa adicionTecnico)
        {
            string nombTecnico, areaAsignada;
            int dniTecnico, nroTecnico;
            Tecnico nuevoTecnico;

            Console.Write("Nombre del Tecnico: "); nombTecnico = Console.ReadLine();
            Console.Write("DNI: "); dniTecnico = ValidarNumero();
            Console.Write("Numero de tecnico: "); nroTecnico = ValidarNumero();
            Console.Write("Area Asignada: "); areaAsignada = Console.ReadLine();

            nuevoTecnico = new Tecnico(nombTecnico, dniTecnico, nroTecnico, areaAsignada);
            adicionTecnico.altaTecnico(nuevoTecnico);
        }
        //MÉTODO PARA VISUALIZAR LISTA DE TECNICOS
        static void listaTecnicos(ref Empresa listTecnico)
        {
            ArrayList listaTec = new ArrayList();
            listaTec = listTecnico.todosLosTecnicos();
            foreach (Tecnico tec in listaTec)
            {
                Console.WriteLine("-----------------");
                Console.Write($"Número de Tecnico: {tec.NrodeTecnico}\n" +
                    $"Técnico: {tec.NombreDeTecnico}\n" +
                    $"DNI: {tec.DniTecnico}\n" +
                    $"Area Asignada: {tec.AreaAsignada}\n");

            }
        }
        //MÉTODO PARA ELIMINAR CLIENTE
        static void eliminarCliente(ref Empresa listaClientes)
        {
            Console.WriteLine("Ingrese codigo de cliente: "); int codcliente = ValidarNumero();

            ArrayList listaclientes = new ArrayList(listaClientes.todoslosClientes());
            foreach (Cliente esbuscado in listaclientes)
            {
                if (codcliente == esbuscado.NumeroCliente)
                {
                    listaClientes.bajaCliente(esbuscado);
                    Console.WriteLine("");
                    Console.WriteLine("Cliente eliminado");
                    break;
                }
            }
        }
        //MÉTODO PARA ELIMINAR TÉCNICO
        static void eliminarTecnico(ref Empresa tecnicos)
        {
            Console.WriteLine("ingrese el Número del técnico a remover: "); int nrotecnico = ValidarNumero();
            ArrayList tecnicoscargados;
            tecnicoscargados = new ArrayList(tecnicos.todosLosTecnicos());
            foreach (Tecnico tecnicobuscado in tecnicoscargados)
            {
                if (tecnicobuscado.NrodeTecnico == nrotecnico)
                {
                    tecnicos.eliminarTecnico(tecnicobuscado);
                    Console.WriteLine("Tecnico Eliminado del registro.");
                    break;
                }
            }
        }
        //METODO PARA COMPROBAR CUPOS
        static void comprobarCupos(ref Empresa compCup, int dd, int mm, int aaaa)
        {
            DateTime fechaActual = new DateTime(aaaa, mm, dd);
            int result = DateTime.Compare(compCup.FinPromo, fechaActual);
            if (result >= 0 | compCup.Cupos > 150)
            {
                Console.WriteLine("Cupo Disponible");
            }
            else
            {
                Console.WriteLine("La fecha de Promocion a expirado.");
            }
        }
        public static int ValidarNumero(int numopcion)
        {
            string pal;
            int num;
            pal = Console.ReadLine();
            bool validacionExitosa = int.TryParse(pal, out num);
            while (true)
            {
                if (validacionExitosa)
                {
                    if (num <= numopcion)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Opcion Incorrecta, intente nuevamente: \n opcion: ");
                        pal = Console.ReadLine();
                        validacionExitosa = int.TryParse(pal, out num);
                    }
                }
                else
                {
                    Console.Write("Caracteres no validos, ingrese un valor númerico: ");
                    pal = Console.ReadLine();
                    validacionExitosa = int.TryParse(pal, out num);
                }
            }
            return num;
        }
        public static int ValidarNumero()
        {
            string pal;
            int num;
            pal = Console.ReadLine();
            bool validacionExitosa = int.TryParse(pal, out num);
            while (true)
            {
                if (validacionExitosa)
                {
                    break;
                }
                else
                {
                    Console.Write("Entrada incorrecte, ingrese un valor númerico: ");
                    pal = Console.ReadLine();
                    validacionExitosa = int.TryParse(pal, out num);
                }
            }
            return num;
        }
        public static double ValidarNumeroDecimal()
        {
            string pal;
            double num;
            pal = Console.ReadLine();
            bool validacionExitosa = double.TryParse(pal, out num);
            while (true)
            {
                if (validacionExitosa)
                {
                    break;
                }
                else
                {
                    Console.Write("Entrada incorrecte, ingrese un valor númerico: ");
                    pal = Console.ReadLine();
                    validacionExitosa = double.TryParse(pal, out num);
                }
            }
            return num;
        }
    }

    class Empresa
    {
        //Atributos de Empresa
        private ArrayList bdclientes;
        private ArrayList bdtecnicos;
        private DateTime inicioPromo;
        private DateTime finPromo;
        private int cupoPromo;

        public Empresa()
        {
            bdclientes = new ArrayList();
            bdtecnicos = new ArrayList();
            inicioPromo = new DateTime(2021, 03, 10);
            finPromo = new DateTime(2021, 06, 10);
            cupoPromo = 150;
        }
        //GENERA y GESTIONA LISTA DE CLIENTES ##############################
        public void altaCliente(Cliente nCliente)
        {
            bdclientes.Add(nCliente);
        }
        public void bajaCliente(Cliente nCliente)
        {
            bdclientes.Remove(nCliente);
        }
        public int cantidadCliente()
        {
            return bdclientes.Count;
        }
        public ArrayList todoslosClientes()
        {
            return bdclientes;
        }

        //GENERA y GESTIONA LISTA DE TECNICOS ##############################
        public void altaTecnico(Tecnico nTecnico)
        {
            bdtecnicos.Add(nTecnico);
        }
        public void eliminarTecnico(Tecnico ntecnico)
        {
            bdtecnicos.Remove(ntecnico);
        }
        public ArrayList todosLosTecnicos()
        {
            return bdtecnicos;
        }
        public int cantidadTecnicos()
        {
            return bdtecnicos.Count;
        }
        // GESTIONAR CUPOS
        public int Cupos
        {                               //REVISAAAAAAAAAAAAAAAAAR ######################################
            set { cupoPromo = value; }
            get { return cupoPromo; }
        }
        public DateTime InicioPromo
        {
            set { inicioPromo= value; }
            get { return inicioPromo; }
        }
        public DateTime FinPromo
        {
            set { finPromo = value; }
            get { return finPromo; }
        }
    }
    class Cliente
    {
        private string nombCliente, tipodePlan;
        private Tecnico tecnicoAsignado;
        private int numeroCliente, dniCliente;
        private DateTime fechaAlta;             //ATRIBUTOS PRIVADOS DE CLIENTE PARA QUE SOLO SE PUEDA ACCEDER DESDE LA CLASE
        private double precioPlan;

        public Cliente(string nombCliente, int numeroCliente, int dniCliente, DateTime fechaAlta, string tipodePlan, double precioPlan, Tecnico tecnicoAsignado)
        //DEFINICION DEL CONSTRUCTOR DE CLIENTE, INDICO LOS ATRIBUTOS Y SU RELACION CON LOS PARAMETROS
        {
            this.nombCliente = nombCliente;
            this.numeroCliente = numeroCliente;
            this.dniCliente = dniCliente;
            this.fechaAlta = fechaAlta;
            this.tipodePlan = tipodePlan;
            this.precioPlan = precioPlan;
            this.tecnicoAsignado = tecnicoAsignado;
        }
        //DEFINO LOS GETERS Y SETERS DE LOS ATRIBUTOS PRIVADOS
        public string NombreCliente
        {
            set { nombCliente = value; }
            get { return nombCliente; }
        }
        public int NumeroCliente
        {
            set { numeroCliente = value; }
            get { return numeroCliente; }
        }
        public int DniCliente
        {
            set { dniCliente = value; }
            get { return dniCliente; }
        }
        public DateTime FechaDeAlta
        {
            set { fechaAlta = value; }
            get { return fechaAlta; }
        }
        public string TipoDePlan
        {
            set { tipodePlan = value; }
            get { return tipodePlan; }
        }
        public double PreciodePlan
        {
            set { precioPlan = value; }
            get { return precioPlan; }
        }
        public Tecnico TecnicoAsignado
        {
            set { tecnicoAsignado = value; }
            get { return tecnicoAsignado; }
        }
    }
    class Tecnico
    {
        //ATRIBUTOS DEL TECNICO
        private string nombTecnico, areaAsignada;
        private int dniTecnico, nroTecnico;

        public Tecnico(string nombTecnico, int dniTecnico, int nroTecnico, string areaAsignada)
        {
            this.nombTecnico = nombTecnico;
            this.dniTecnico = dniTecnico;
            this.nroTecnico = nroTecnico;
            this.areaAsignada = areaAsignada;
        }
        public Tecnico(int nroTecnico)
        {
            this.nroTecnico = nroTecnico;
        }
        public string NombreDeTecnico
        {
            set { nombTecnico = value; }
            get { return nombTecnico; }
        }
        public int DniTecnico
        {
            set { dniTecnico = value; }
            get { return dniTecnico; }
        }
        public int NrodeTecnico
        {
            set { nroTecnico = value; }
            get { return nroTecnico; }
        }
        public string AreaAsignada
        {
            set { areaAsignada = value; }
            get { return areaAsignada; }
        }
    }
}
