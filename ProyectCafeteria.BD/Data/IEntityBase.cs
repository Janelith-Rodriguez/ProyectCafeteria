﻿namespace ProyectCafeteria.BD.Data
{
    public interface IEntityBase
    {
        bool Activo { get; set; }
        int Id { get; set; }
    }
}