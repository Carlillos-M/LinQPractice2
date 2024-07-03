// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Runtime.InteropServices;
using CursoLinQ2;
using Microsoft.VisualBasic;

Video 11: ThenBy & ThenByDescending

var personas = new List<Persona>(){
    new Persona { Nombre = "Carlos", Edad = 23, FechaIngreso = new DateTime(2016,3,26), Soltero = true},
    new Persona { Nombre = "Mariana", Edad = 23, FechaIngreso = new DateTime(2020,4,22), Soltero = false},
    new Persona { Nombre = "Ulises", Edad = 23, FechaIngreso = new DateTime(2022,8,15), Soltero = true},
    new Persona { Nombre = "Melany", Edad = 21, FechaIngreso = new DateTime(2015,1,15), Soltero = true},
    new Persona { Nombre = "Hugo", Edad = 60, FechaIngreso = new DateTime(2010,7,30), Soltero = false},      
};

var personasOrdenadasPorEdad = personas.OrderBy(x => x.Edad).ThenByDescending(x => x.Nombre);

foreach (var persona in personasOrdenadasPorEdad)
{
    Console.WriteLine($"{persona.Nombre} tiene {persona.Edad} años de edad");
}

var personasOrdenadasPorEdad_2 = from p in personas
                                orderby p.Edad, p.Nombre descending
                                select p;

Video 13: Select

var personas = new List<Persona>(){
     new Persona { Nombre = "Carlos", Edad = 23, FechaIngreso = new DateTime(2016,3,26), Soltero = true},
     new Persona { Nombre = "Mariana", Edad = 23, FechaIngreso = new DateTime(2020,4,22), Soltero = false},
     new Persona { Nombre = "Ulises", Edad = 23, FechaIngreso = new DateTime(2022,8,15), Soltero = true},
     new Persona { Nombre = "Melany", Edad = 21, FechaIngreso = new DateTime(2015,1,15), Soltero = true},
     new Persona { Nombre = "Hugo", Edad = 60, FechaIngreso = new DateTime(2010,7,30), Soltero = false},
};

var nombres = personas.Select(p => p.Nombre).ToList();

var nombresYEdades = personas.Select( p => new Persona {Nombre = p.Nombre, Edad = p.}).ToList();

var numeros = Enumerable.Range(1, 5).ToList();
var numerosDuplicados = numeros.Select(n => 2 * n).ToList();

var personasConIndice = personas.Select((p, indice) => new { Persona = p, indice = indice }).ToList();

foreach (var item in personasConIndice)
{
    Console.WriteLine($"{item.indice} {item.Persona.Nombre}");
}

// sintaxis de queries

var nombres_2 = (from p in personas
                select p.Nombre).ToList();

var nombresYEdades_2 = from p in personas
                        select new { Nombre = p.Nombre, Edad = p.Edad};

var numerosDuplicados_2 = from n in numeros
                        select 2 * n;


Video 14: Count y LongCount

var personas = new List<Persona>(){
     new Persona { Nombre = "Carlos",  Soltero = true},
     new Persona { Nombre = "Mariana",  Soltero = false},
     new Persona { Nombre = "Ulises",  Soltero = true},
     new Persona { Nombre = "Melany", Soltero = true},
     new Persona { Nombre = "Hugo", Soltero = false},
};

Console.WriteLine($"La cantidad de personas es {personas.Count()}");

Console.WriteLine($"La cantidad de personas solteras es {personas.Count(p => p.Soltero)}");


Video 15: Suma, Maximo y Minimo

var personas = new List<Persona>(){
     new Persona { Nombre = "Carlos", Edad = 23},
     new Persona { Nombre = "Mariana", Edad = 23},
     new Persona { Nombre = "Ulises", Edad = 23},
     new Persona { Nombre = "Melany", Edad = 21},
     new Persona { Nombre = "Hugo", Edad = 60},
};

var numeros = Enumerable.Range(1, 5);

Console.WriteLine($"La suma de los numeros es {numeros.Sum()}.");
Console.WriteLine($"La suma de las edades son {personas.Sum(p => p.Edad)}");

Console.WriteLine($"La edad maxima de las personas es {personas.Max(x => x.Edad)}");
Console.WriteLine($"La edad maxima de las personas es {personas.Min(x => x.Edad)}");


Video 19: Agregado

var numeros = Enumerable.Range(1, 5);

var resultado = numeros.Aggregate((a, b) => a * b);

Console.WriteLine($"el resultado es {resultado}");

var resultadoConValorInicial = numeros.Aggregate(10, (a, b) => a * b,);

Console.WriteLine($"El resultado con valor semilla es {resultadoConValorInicial}");


Video 21: Contains

var numeros = Enumerable.Range(1, 5);

var estaElNumero3 = numeros.Contains(3);

var estaElNumero20 = numeros.Contains(20);


Video 22: Any

var personas = new List<Persona>(){
     new Persona { Nombre = "Carlos", Edad = 23,  Soltero = true},
     new Persona { Nombre = "Mariana", Edad = 23,  Soltero = false},
     new Persona { Nombre = "Ulises", Edad = 23,  Soltero = true},
     new Persona { Nombre = "Melany", Edad = 21, Soltero = true},
     new Persona { Nombre = "Hugo", Edad = 60,  Soltero = false},
};

var existeMenor = personas.Any(p => p.Edad < 18);

var existeMayorDe30 = personas.Any(p => p.Edad > 30);


Video 27: GroupBy Simple
var personas = new List<Persona>(){
     new Persona { Nombre = "Carlos", Edad = 23,  Soltero = true},
     new Persona { Nombre = "Mariana", Edad = 23,  Soltero = false},
     new Persona { Nombre = "Ulises", Edad = 23,  Soltero = true},
     new Persona { Nombre = "Melany", Edad = 21, Soltero = true},
     new Persona { Nombre = "Hugo", Edad = 60,  Soltero = false},
     new Persona { Nombre = "Alexa", Edad = 18,  Soltero = false},
     new Persona { Nombre = "Jesus", Edad = 19,  Soltero = true},
};

var agruparPorEstadoCivil = personas.GroupBy(p => p.Soltero);

// sintaxis de queries

var agruparPorEstadoCivil_2 = from p in personas
                            group p by p.Soltero into grupos
                            select grupos;

foreach (var grupo in agruparPorEstadoCivil)
{
    Console.WriteLine($"Grupo de las personas donde Soltero = {grupo.Key} (Total: {grupo.Count()})");

    foreach (var persona in grupo)
    {
        Console.WriteLine($"- {persona.Nombre}");
    }
}


Video 28: GroupBy Rango de edad

var personas = new List<Persona>(){
     new Persona { Nombre = "Carlos", Edad = 23,  Soltero = true},
     new Persona { Nombre = "Mariana", Edad = 23,  Soltero = false},
     new Persona { Nombre = "Ulises", Edad = 23,  Soltero = true},
     new Persona { Nombre = "Melany", Edad = 21, Soltero = true},
     new Persona { Nombre = "Hugo", Edad = 60,  Soltero = false},
     new Persona { Nombre = "Alexa", Edad = 18,  Soltero = false},
     new Persona { Nombre = "Jesus", Edad = 19,  Soltero = true},
};

var agrupamientoPorRangoEdad = personas.GroupBy(p => p.Edad / 5);

// sintaxis de queries
var agrupamientoPorRangoEdad_2 = from p in personas 
                                group p by p.Edad / 5 into grupos select grupos;

foreach (var grupo in agrupamientoPorRangoEdad_2)
{
    Console.WriteLine($"Grupo de las personas en el rango de edad {grupo.Key * 5} - {grupo.Key * 5 + 5 - 1}");

    foreach (var persona in grupo)
    {
        Console.WriteLine($"- {persona.Nombre} {persona.Edad}");
    }
}


Video 29: Join

var personas = new List<Persona>(){
     new Persona { Nombre = "Carlos", EmpresaId = 1},
     new Persona { Nombre = "Mariana", EmpresaId = 2},
     new Persona { Nombre = "Ulises", EmpresaId = 3},
     new Persona { Nombre = "Melany", EmpresaId = 1},
     new Persona { Nombre = "Hugo", EmpresaId = 2},
     new Persona { Nombre = "Alexa", EmpresaId = 3},
     new Persona { Nombre = "Jesus"},
};

var empresas = new List<Empresa>(){
    new Empresa {Id = 1, Nombre = "Ferreteria"},
    new Empresa {Id = 2, Nombre = "Farmacia"},
    new Empresa {Id = 3, Nombre = "Barberia"}
};

var personasYEmpresas = personas.Join(empresas, p => p.EmpresaId, e => e.Id, (persona, empresa) => new{
    Persona = persona,
    Empresa = empresa
});

// sintaxis de queries

var personasYEmpresas_2 = from p in personas
                            join e in empresas on p.EmpresaId equals e.Id
                            select new {Persona = p, Empresa = e};


foreach (var item in personasYEmpresas)
{
    Console.WriteLine($"{item.Persona.Nombre} trabaja en {item.Empresa.Nombre}");
}

Video 30: GroupJoin

var personas = new List<Persona>(){
     new Persona { Nombre = "Carlos", EmpresaId = 1},
     new Persona { Nombre = "Mariana", EmpresaId = 2},
     new Persona { Nombre = "Ulises", EmpresaId = 3},
     new Persona { Nombre = "Melany", EmpresaId = 1},
     new Persona { Nombre = "Hugo", EmpresaId = 2},
     new Persona { Nombre = "Alexa", EmpresaId = 3},
     new Persona { Nombre = "Jesus"},
};

var empresas = new List<Empresa>(){
    new Empresa {Id = 1, Nombre = "Ferreteria"},
    new Empresa {Id = 2, Nombre = "Farmacia"},
    new Empresa {Id = 3, Nombre = "Barberia"},
    new Empresa {Id = 4, Nombre = "Zapateria"}
};

var empresasYEmpleados = empresas.GroupJoin(personas, e => e.Id, p => p.EmpresaId,
                            (empresa, personas) => new {Empresa = empresa, Personas = personas});

// sintaxis de queries
var empresasYEmpleados_2 = from empresa in empresas
                            join persona in personas
                            on empresa.Id equals persona.EmpresaId into personas2
                            select new {Empresa = empresa, Persona = personas2};

foreach (var item in empresasYEmpleados_2)
{
    Console.WriteLine($"Las siguientes personas trabajan en {item.Empresa.Nombre}");

    foreach (var persona in item.Personas)
    {
        Console.WriteLine($"- {persona.Nombre}");
    }
}


Video 31: Distinct y DistinctBy

var personas = new List<Persona>(){
     new Persona { Nombre = "Carlos", EmpresaId = 1},
     new Persona { Nombre = "Mariana", EmpresaId = 2},
     new Persona { Nombre = "Ulises", EmpresaId = 3},
     new Persona { Nombre = "Melany", EmpresaId = 1},
     new Persona { Nombre = "Hugo", EmpresaId = 2},
     new Persona { Nombre = "Alexa", EmpresaId = 3},
     new Persona { Nombre = "Carlos"},
};

int [] numeros = {1, 2, 3, 1, 1, 6};

var numerosSinRepeticiones = numeros.Distinct();

var personasSinNombresRep = personas.DistinctBy(p => p.Nombre);


// sintaxis de queries

var numerosSinRepeticiones_2 = from n in numeros.Distinct()
                                select n;

var personasSinNombresRep_2 = from p in personas.DistinctBy(p => p.Nombre)
                                select p;    


Video 32: Union y UnionBy

var personasA = new List<Persona>(){
     new Persona { Nombre = "Carlos", EmpresaId = 1},
     new Persona { Nombre = "Mariana", EmpresaId = 2},
     new Persona { Nombre = "Ulises", EmpresaId = 3},
     new Persona { Nombre = "Melany", EmpresaId = 1},
};

var personasB = new List<Persona>(){
    new Persona { Nombre = "Hugo", Edad = 25},
    new Persona { Nombre = "Carlos", EmpresaId = 1},
};

int [] numerosA = {1, 2, 3, 1, 1, 6};
int [] numerosB = {1, 2, 15};

var unionNumeros = numerosA.Union(numerosB);
var unionPersonas = personasA.UnionBy(personasB, p => p.Nombre);


Video 38: Concat

int [] A = {1, 2, 3};
int [] B = {4, 5, 6};

var resultado = A.Concat(B);

