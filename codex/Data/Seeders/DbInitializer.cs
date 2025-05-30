using codex.Models;

namespace codex.Data.Seeders
{
    public static class DbInitializer
    {
        public static void Inicializar(ApplicationDbContext context)
        {
            if (context.Computadoras.Any())
                return; // Ya hay datos, no insertar duplicados

            var computadoras = new List<Computadora>
            {
                new Computadora
                {
                    Marca = "HP",
                    Modelo = "Stream 14",
                    TipoDispositivo = TipoDispositivo.Portatil,
                    Procesador = "Intel Celeron N4020",
                    GeneracionCPU = "9ª",
                    MemoriaRam = "4 GB",
                    TipoRam = "DDR4",
                    AlmacenamientoPrincipal = "64 GB SSD",
                    TarjetaGrafica = "Integrada UHD 600",
                    TieneGPUIntegrada = true,
                    PantallaPulgadas = 14,
                    ResolucionHorizontal = 1366,
                    ResolucionVertical = 768,
                    Puertos = "USB x2, HDMI, SD",
                    Conectividad = "Wi-Fi, Bluetooth",
                    Precio = 899000,
                    ImagenUrl = "https://example.com/hp-stream.jpg",
                    TipoRecomendado = TipoUso.Basico,
                    Descripcion = "Ideal para navegación, tareas básicas y videollamadas."
                },
                new Computadora
                {
                    Marca = "Lenovo",
                    Modelo = "IdeaPad 3",
                    TipoDispositivo = TipoDispositivo.Portatil,
                    Procesador = "Intel Core i3-10110U",
                    GeneracionCPU = "10ª",
                    MemoriaRam = "8 GB",
                    TipoRam = "DDR4",
                    AlmacenamientoPrincipal = "256 GB SSD",
                    TarjetaGrafica = "Integrada UHD",
                    TieneGPUIntegrada = true,
                    PantallaPulgadas = 15.6,
                    ResolucionHorizontal = 1920,
                    ResolucionVertical = 1080,
                    Puertos = "USB 3.1, HDMI",
                    Conectividad = "Wi-Fi AC, Bluetooth 4.2",
                    Precio = 1599000,
                    ImagenUrl = "https://example.com/lenovo-ideapad3.jpg",
                    TipoRecomendado = TipoUso.Estudiante,
                    Descripcion = "Perfecta para clases virtuales y productividad académica."
                },
                new Computadora
                {
                    Marca = "Dell",
                    Modelo = "Inspiron 15",
                    TipoDispositivo = TipoDispositivo.Portatil,
                    Procesador = "Intel Core i5-1135G7",
                    GeneracionCPU = "11ª",
                    MemoriaRam = "8 GB",
                    TipoRam = "DDR4",
                    AlmacenamientoPrincipal = "512 GB SSD",
                    TarjetaGrafica = "Integrada Iris Xe",
                    TieneGPUIntegrada = true,
                    PantallaPulgadas = 15.6,
                    ResolucionHorizontal = 1920,
                    ResolucionVertical = 1080,
                    Puertos = "USB-C, HDMI, SD",
                    Conectividad = "Wi-Fi 6, Bluetooth 5",
                    Precio = 2299000,
                    ImagenUrl = "https://example.com/dell-inspiron.jpg",
                    TipoRecomendado = TipoUso.Programador,
                    Descripcion = "Ideal para programación, desarrollo y multitarea."
                },
                new Computadora
                {
                    Marca = "ASUS",
                    Modelo = "VivoBook Pro",
                    TipoDispositivo = TipoDispositivo.Portatil,
                    Procesador = "AMD Ryzen 7 5800H",
                    GeneracionCPU = "5ª",
                    MemoriaRam = "16 GB",
                    TipoRam = "DDR4",
                    AlmacenamientoPrincipal = "1 TB SSD",
                    TarjetaGrafica = "NVIDIA GTX 1650",
                    TieneGPUIntegrada = false,
                    PantallaPulgadas = 15.6,
                    ResolucionHorizontal = 1920,
                    ResolucionVertical = 1080,
                    Puertos = "HDMI, USB-C, microSD",
                    Conectividad = "Wi-Fi 6, Bluetooth 5.2",
                    Precio = 3999000,
                    ImagenUrl = "https://example.com/asus-vivobookpro.jpg",
                    TipoRecomendado = TipoUso.Disenador,
                    Descripcion = "Diseñada para creativos que usan Photoshop e Illustrator."
                },
                new Computadora
                {
                    Marca = "MSI",
                    Modelo = "Creator M16",
                    TipoDispositivo = TipoDispositivo.Portatil,
                    Procesador = "Intel Core i7-12700H",
                    GeneracionCPU = "12ª",
                    MemoriaRam = "32 GB",
                    TipoRam = "DDR4",
                    AlmacenamientoPrincipal = "1 TB SSD",
                    TarjetaGrafica = "NVIDIA RTX 3060",
                    TieneGPUIntegrada = false,
                    PantallaPulgadas = 16,
                    ResolucionHorizontal = 2560,
                    ResolucionVertical = 1600,
                    Puertos = "USB-C, HDMI, lector SD",
                    Conectividad = "Wi-Fi 6E, Bluetooth 5.2",
                    Precio = 6990000,
                    ImagenUrl = "https://example.com/msi-creator.jpg",
                    TipoRecomendado = TipoUso.EditorVideo,
                    Descripcion = "Potente estación para edición 4K y renderizado en Premiere."
                },
                new Computadora
                {
                    Marca = "HP",
                    Modelo = "ZBook Firefly G8",
                    TipoDispositivo = TipoDispositivo.Portatil,
                    Procesador = "Intel Core i7-1185G7",
                    GeneracionCPU = "11ª",
                    MemoriaRam = "32 GB",
                    TipoRam = "DDR4",
                    AlmacenamientoPrincipal = "1 TB SSD",
                    TarjetaGrafica = "NVIDIA Quadro T500",
                    TieneGPUIntegrada = false,
                    PantallaPulgadas = 15.6,
                    ResolucionHorizontal = 1920,
                    ResolucionVertical = 1080,
                    Puertos = "Thunderbolt, HDMI, USB",
                    Conectividad = "Wi-Fi 6, Bluetooth 5",
                    Precio = 7590000,
                    ImagenUrl = "https://example.com/hp-zbook.jpg",
                    TipoRecomendado = TipoUso.TecnicoAvanzado,
                    Descripcion = "Workstation para CAD, simulaciones y modelado 3D exigente."
                },
                new Computadora
                {
                    Marca = "Acer",
                    Modelo = "Nitro 5",
                    TipoDispositivo = TipoDispositivo.Portatil,
                    Procesador = "Intel Core i7-11800H",
                    GeneracionCPU = "11ª",
                    MemoriaRam = "16 GB",
                    TipoRam = "DDR4",
                    AlmacenamientoPrincipal = "512 GB SSD",
                    AlmacenamientoSecundario = "1 TB HDD",
                    TarjetaGrafica = "NVIDIA RTX 3050",
                    TieneGPUIntegrada = false,
                    PantallaPulgadas = 15.6,
                    ResolucionHorizontal = 1920,
                    ResolucionVertical = 1080,
                    Puertos = "Ethernet, HDMI, USB 3.2",
                    Conectividad = "Wi-Fi 6, Bluetooth",
                    Precio = 4590000,
                    ImagenUrl = "https://example.com/acer-nitro5.jpg",
                    TipoRecomendado = TipoUso.Gamer,
                    Descripcion = "Perfecta para gaming fluido, streaming y multitarea extrema."
                }
            };

            context.Computadoras.AddRange(computadoras);
            context.SaveChanges();
        }
    }
}
