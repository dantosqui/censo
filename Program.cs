﻿
List<Persona> listaPersonas = new List<Persona>();
bool salir = false;
do
{
    Console.WriteLine("Menu \n1: Cargar nueva persona \n2: Obtener estadísticas del censo \n3: Buscar Persona \n4: Modificar mail de una persona\n5: Salir");
    int rta = int.Parse(Console.ReadLine());
    switch (rta)
    {
        case 1:
            AnadirPersonaLista(ref listaPersonas);
            break;
        case 2:
            MostrarEstadisticasDelCenso(listaPersonas);
            break;
        case 3:
            int m = BuscarPersona(listaPersonas);
            if (m==listaPersonas.Count) Console.WriteLine("No se encontró el DNI");
            else if (m==-1) Console.WriteLine("Aún no hay personas");
            else {
                string pv;
                if (listaPersonas[m].PuedeVotar()) pv="P"; else pv="No p";
                Console.WriteLine ("A continuación los datos de la persona cuyo DNI es: " + listaPersonas[m].DNI + "\nNombre y Apellido: " + listaPersonas[m].nombre +" "+ listaPersonas[m].apellido + "\nSu fecha de nacimiento es: " + listaPersonas[m].fnac + " Y su edad es " + listaPersonas[m].ObtenerEdad() + ". \n" + pv +"uede votar" + "\nCorreo electrónico: "+listaPersonas[m].email);
            }
            break;
        case 4:
            ModificarMail(ref listaPersonas);
            break;
        case 5:
        salir=true;
        break;
        default:
            Console.WriteLine("No válido!");
            break;
    }
} while (!salir);


static void AnadirPersonaLista(ref List<Persona> lp)
{

    Console.WriteLine("Ingresaremos una persona.");


    bool v = false; int dni;
    do
    {
        Console.Write("Ingrese DNI: ");
        v = !(int.TryParse(Console.ReadLine(), out dni));
        if (!v)
        {
            foreach (Persona i in lp)
            {
                v = i.DNI == dni;
            }
        }
    } while (v);

    string ap;  do{Console.Write("Ingrese apellido: "); ap = Console.ReadLine();} while(ap.Length<=0);
    string nom; do{Console.Write("Ingrese nombre: "); nom= Console.ReadLine();}while(nom.Length<=0);

    DateTime fechaNacimiento = new DateTime();
    do
    {
        Console.Write("Ingrese Fecha de nacimiento (AAAA/MM/DD): ");
        v = !(DateTime.TryParse(Console.ReadLine(), out fechaNacimiento));
    } while (v);

    Console.Write("Ingrese el correo electrónico: "); string em = Console.ReadLine();


    Persona p1 = new Persona(dni, ap, nom, fechaNacimiento, em);
    lp.Add(p1);

    Console.WriteLine("La persona " + p1.nombre + " " + p1.apellido + " fue añadida al censo");
}

static void MostrarEstadisticasDelCenso(List<Persona> lp)
{
    if(lp.Any()) {

    Console.WriteLine("Cantidad de personas: " + lp.Count);

    int cantidadDePersonasQuePuedenVotar = 0; int sed = 0;
    foreach (Persona i in lp) { if (i.PuedeVotar()) cantidadDePersonasQuePuedenVotar++; sed += i.ObtenerEdad(); }

    Console.WriteLine("Cantidad de personas que pueden votar: " + cantidadDePersonasQuePuedenVotar);

    Console.WriteLine("Promedio de edad: " + sed / lp.Count);
    }
    else Console.WriteLine("Aún no hay personas");

}

static int BuscarPersona(List<Persona> lp) {
    
    if(lp.Any()) {
    Console.Write("Ingrese el número de documento de la persona que que quiere buscar: ");
    int numeroDeDocumentoDeLaPersonaQueQuiereBuscar; bool v;
    do{v= int.TryParse(Console.ReadLine(), out numeroDeDocumentoDeLaPersonaQueQuiereBuscar);}while(!v);
    
    int i = -1;
    v=false;
    while (!v && i!=lp.Count) {
        
        i++;
        v=lp[i].DNI==numeroDeDocumentoDeLaPersonaQueQuiereBuscar;
        
        
    }
    return i;
    }
    else return -1;
    
    
}

static void ModificarMail(ref List<Persona> lp) {
    Console.WriteLine("Se buscará a la persona cuyo correo electrónico quiere cambiar.");
    int m=BuscarPersona(lp);

    if (m==lp.Count) Console.WriteLine("No se encontró el DNI");
    else if (m==-1) Console.WriteLine("Aún no hay personas");
    else{Console.Write("Ingrese el nuevo correo de " + lp[m].nombre + " " + lp[m].apellido + ": ");
    lp[m].email=Console.ReadLine();}
}
