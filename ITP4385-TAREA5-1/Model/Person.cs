
//Id Estudiante: 181021625
//Nombre:Juan P Torres Torres
//Universidad : EDP University 
//Codigo y titulo del curso:ITP4385-Programacion orientada a objectos II
//Nombre del programa:Registro Clientes
//Fecha creacion: 10/3/2021
//Descripcion general: Programa que permite gestionar los datos de los objetos de la clase persona.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITP4385_TAREA5_1.Model
{
    public class Person
    {



        public string Name { get; set; }

        public string LastName { get; set; }

        public char Gender { get; set; }

        public int Age { get; set; }


        public DateTime DateOfBirth { get; set; }



    }
}
