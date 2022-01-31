﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiTiempo.Data;

namespace WebApiTiempo.Migrations
{
    [DbContext(typeof(WebApiTiempoContext))]
    partial class WebApiTiempoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApiTiempo.Models.TiempoItem", b =>
                {
                    b.Property<string>("Municipio")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Humedad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitud")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrecipitacionAcumulada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempMax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempMedia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TempMin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Temperatura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VelocidadViento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Municipio");

                    b.ToTable("TiempoItem");
                });

            modelBuilder.Entity("WebApiTiempo.Models.Usuario", b =>
                {
                    b.Property<string>("usuario")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("usuario");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
