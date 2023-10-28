using (var contextdb = new AsigContext())
{
    contextdb.Database.EnsureCreated();

    while (true)
    {
        Console.WriteLine("Menu de Asignatura");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine("| Seleccione una opción que desea realizar:        |");
        Console.WriteLine("| 1- Agregar un nuevo registro                     |");
        Console.WriteLine("| 2- Mostrar los datos de la tabla (Asignatura)    |");
        Console.WriteLine("| 3- Modificar los datos de la tabla (Asignatura   |");
        Console.WriteLine("| 4- Salir                                         |");
        Console.WriteLine("----------------------------------------------------");
        Console.WriteLine();
        Console.Write("Usuario ingrese el número de la opción que quiere realizar: ");

        if (int.TryParse(Console.ReadLine(), out int opcion))
        {
            switch (opcion)
            {
                case 1:
                    var Agregar_Nuevo_Registros = true;
                    while (Agregar_Nuevo_Registros)
                    {
                        Console.WriteLine("Ingrese el nombre el nuevo: ");
                        var Nuevo_Nombre = Console.ReadLine();
                        Console.WriteLine("Ingrese nueva unidades valorativas:");
                        int Nuevo_unidades_valorativas = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingrese  nuevo ciclo");
                        var Nuevo_ciclo = Console.ReadLine();
                        Console.WriteLine("Ingrese los nuevo inscritos");
                        int inscritos = Convert.ToInt32(Console.ReadLine());
                        var asignatura1 = new Asignatura()
                        {
                            nombre = Nuevo_Nombre,
                            unidades_valorativas = Nuevo_unidades_valorativas,
                            ciclo = Nuevo_ciclo,
                            inscritos = inscritos
                        };
                        contextdb.Add(asignatura1);
                        contextdb.SaveChanges();
                        Console.WriteLine("-Registro completado-");
                        Console.WriteLine();

                        Console.Write(@"Usuario ¿Desea agregar más registros?
Si su respuesta es si ingrese la letra: S
Si su respuesta es No ingrese la letra: N (Y volvera al menu inicial)
Ingrese su respuesta: ");
                        string Respuesta_del_usuario = Console.ReadLine();

                        Agregar_Nuevo_Registros = (Respuesta_del_usuario.Trim().ToUpper() == "S");
                    }
                    break;
                case 2:
                    using (var sqlserver = new AsigContext())
                    {
 
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine("|                              Datos de la tabla                                    |");
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine("| Id        | Nombre |  Unidades valorativas                    | Ciclo | Inscritos |");
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");

                        foreach (var item in sqlserver.asignaturas)
                        {
                            Console.WriteLine($"| {item.id,-9} | {item.nombre,-27} {item.unidades_valorativas,-27} | {item.ciclo,-4} | {item.inscritos,-5}|");
                        }

                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    var Modificar_Registros = true;
                    using (var sqlserver = new AsigContext())
                    {

                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine("|                              Datos de la tabla                                    |");
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine("| Id        | Nombre |  Unidades valorativas                    | Ciclo | Inscritos |");
                        Console.WriteLine("|-----------------------------------------------------------------------------------|");

                        foreach (var item in sqlserver.asignaturas)
                        {
                            Console.WriteLine($"| {item.id,-9} | {item.nombre,-27} {item.unidades_valorativas,-27} | {item.ciclo,-4} | {item.inscritos,-5}|");
                        }

                        Console.WriteLine("|-----------------------------------------------------------------------------------|");
                        Console.WriteLine();
                    }
                    while (Modificar_Registros)
                    {

                        Console.Write("Ingrese el Id del estudiante que desea modificar: ");
                        if (int.TryParse(Console.ReadLine(), out int Id_Modificar))
                        {
                            using (var sqlserver = new AsigContext())
                            {
                                var Estudiante_Modifcado = sqlserver.asignaturas.FirstOrDefault(Modificar_Estudiante => Modificar_Estudiante.id == Id_Modificar);

                                if (Estudiante_Modifcado != null)
                                {
                                    Console.WriteLine("----------------------------------------------------");
                                    Console.WriteLine("|Seleccione el atributo que desea modificar:        |");
                                    Console.WriteLine("| 1- Nombre                                         |");
                                    Console.WriteLine("----------------------------------------------------");
                                    Console.WriteLine();
                                    Console.Write("Usuario ingrese el número de la opción que quiere realizar: ");

                                    if (int.TryParse(Console.ReadLine(), out int Registro_Modificar))
                                    {
                                        switch (Registro_Modificar)
                                        {
                                            case 1:
                                                Console.Write("Ingrese el nuevo nombre que sera modicado: ");
                                                Estudiante_Modifcado.nombre = Console.ReadLine();
                                                break;
                                         
                                            default:
                                                Console.WriteLine("Error esa opción no es válida, intente de nuevo y asegurese que lo haya hecho segun lo indicado.");
                                                break;
                                        }

                                        sqlserver.SaveChanges();
                                        Console.WriteLine("-Registro modificado-");
                                        Console.Write(@"Usuario ¿Desea modificar más registros?
Si su respuesta es si ingrese la letra: S
Si su respuesta es No ingrese la letra: N (Y volvera al menu inicial)
Ingrese su respuesta: ");
                                        string Respuesta_del_usuario = Console.ReadLine();

                                        Modificar_Registros = (Respuesta_del_usuario.Trim().ToUpper() == "S");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error esa opción no es válida, intente de nuevo y asegurese que lo haya hecho segun lo indicado.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(" Error el Id ingresado no existe, no se pudo hacer el cambio del registro.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(" Error el Id ingresado no existe, no se pudo hacer el cambio del registro.");
                        }
                    }
                    break;
                case 4:
                    { Console.WriteLine("Hecho por Josue Bryan Hernandez Zelaya "); }
                    return;
                default:
                    Console.WriteLine("Error esa opción no es válida, intente de nuevo y asegurese que lo haya hecho segun lo indicado.");
                    break;

            }
        }
        else
        {
            Console.WriteLine("Error esa opción no es válida, intente de nuevo y asegurese que lo haya hecho segun lo indicado.");
        }
    }
}

