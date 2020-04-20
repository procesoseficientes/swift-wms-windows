using System.Collections.Generic;
using MobilityScm.Modelo.Argumentos;
using MobilityScm.Vertical.Entidades;

namespace MobilityScm.Modelo.Interfaces.Servicios
{
    public interface IClaseServicio
    {
        /// <summary>
        /// Obtiene una clase por ID
        /// </summary>
        /// <param name="clase">ID a buscar</param>
        /// <returns>Clase solicitada</returns>
        Clase ObtenerClasePorId(Clase clase);

        /// <summary>
        /// Obtiene todas las clases
        /// </summary>
        /// <returns>Listado de clases</returns>
        IList<Clase> ObtenerClases();

        /// <summary>
        /// Obtine las clases asociadas de la clase enviada
        /// </summary>
        /// <param name="clase">ID a buscar</param>
        /// <returns>Listado de clases</returns>
        IList<Clase> ObtenerClasesAsociadas(Clase clase);

        /// <summary>
        /// Obtiene las clases no asociadas a la clase enviada
        /// </summary>
        /// <param name="clase">ID a buscar</param>
        /// <returns>Listado de clases</returns>
        IList<Clase> ObtenerClasesNoAsociadas(Clase clase);

        /// <summary>
        /// Crea una clase
        /// </summary>
        /// <param name="clase">Clase a crear</param>
        /// <returns>Resultado de la operacion</returns>
        Operacion CrearClase(Clase clase);

        /// <summary>
        /// Actualiza una clase
        /// </summary>
        /// <param name="clase">Clase a actualizar</param>
        /// <returns>Resultado de la operacion</returns>
        Operacion ActualizarClase(Clase clase);

        /// <summary>
        /// Elimina una clase
        /// </summary>
        /// <param name="clase">Clase a Elimnar</param>
        /// <returns>Resultado de la operacion</returns>
        Operacion EliminarClase(Clase clase);

        /// <summary>
        /// Asocia clases a una clase
        /// </summary>
        /// <param name="claseArgumento">lista de clases a asociar</param>
        /// <returns>Resultado de la operacion</returns>
        Operacion AsociarClases(ClaseArgumento claseArgumento);

        /// <summary>
        /// Desasocia clases a una clase
        /// </summary>
        /// <param name="claseArgumento">lista de clases a desasociar</param>
        /// <returns>Resultado de la operacion</returns>
        Operacion DesasociarClases(ClaseArgumento claseArgumento);

        /// <summary>
        /// Carga las clases por XML
        /// </summary>
        /// <param name="xml">Clases a cargar</param>
        /// <returns></returns>
        Operacion CargarClasesPorXml(ClaseArgumento claseArgumento);

        /// <summary>
        /// Obtiene todas las clases asignadas de las zonas de posicionamientos
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        IList<Clase> ObtenerClasesAsignadasParaZonasDePosicionamiento(PosicionamientoArgumento arg);

        /// <summary>
        /// Obtiene todas las sub clases asignadas de las zonas de posicionamientos
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        IList<Clase> ObtenerSubClasesAsignadasParaZonasDePosicionamiento(PosicionamientoArgumento arg);

        /// <summary>
        /// Obtiene todas las clases disponibles de las zonas de posicionamientos
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        IList<Clase> ObtenerClasesDisponbilesParaZonasDePosicionamiento(PosicionamientoArgumento arg);

        /// <summary>
        /// Obtiene todas las sub clases disponibles de las zonas de posicionamientos
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        IList<Clase> ObtenerSubClasesDisponbilesParaZonasDePosicionamiento(PosicionamientoArgumento arg);
    }
}