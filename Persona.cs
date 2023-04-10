class Persona {

    public int DNI {get; private set;}
    public string apellido{get;private set;}
    public string nombre{get;private set;}
    public DateTime fnac{get;private set;}
    public string email{get;set;}

    public Persona(int dni_, string apellido_, string nombre_, DateTime fnac_, string email_) {
        DNI=dni_;apellido=apellido_;nombre=nombre_;fnac=fnac_;email=email_;
    }

    public bool PuedeVotar() {
        if (ObtenerEdad()>=16) return true;
        else return false;
    }
    public int ObtenerEdad() {
        int edad=DateTime.Today.Year-fnac.Year;
        return edad;
    }

}