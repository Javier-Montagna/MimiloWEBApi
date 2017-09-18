
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Mimilo.Models;

namespace Mimilo.Database
{
    public class MimiloSeedData
    {
        private MimiloContext _context;
        private RoleManager<MimiloRole> _roleManager;
        private UserManager<MimiloUser> _userManager;

        public MimiloSeedData(MimiloContext context, RoleManager<MimiloRole> roleManager, UserManager<MimiloUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task EnsureSeedDate()
        {
            await AddProductTestData();
            await AddUserTestData();
        }

        private async Task AddUserTestData()
        {
            _context.Users.Clear();
            _context.UserRoles.Clear();

            var role = new MimiloRole()
            {
                Name = "Administrador",
                Description = "Capacidad de dominar el mundo conocido",
            };
            await _roleManager.CreateAsync(role);

            var javierMontagna = new MimiloUser()
            {
                Name = "Javier",
                LastName = "Montagna",
                Email = "javiermontagna@gmail.com",
                UserName = "javiermontagna@gmail.com"
            };

            await _userManager.CreateAsync(javierMontagna, "Racing1$");
            await _userManager.AddToRoleAsync(javierMontagna, "Administrador");
        }

        private async Task AddProductTestData()
        {
            _context.Products.Clear();
            var sabanaOrganica = new Product()
            {
                ProductName = "Sabana organica",
                TitleDescription = "Sabana organica",
                ShortDescription = "Sabana de algodon organico.",
                LongDescription = "Sábana Ajustable para Cuna en Algodón Orgánico Certificado. Confección artesanal, con elástico alrededor de todo el ajustable.",
                ReleaseDate = "March 18, 2016",
                Price = 350,
                CoverImageUrl = "/assets/img/products/Sabanas/Cover.jpg"
            };
            _context.Products.Add(sabanaOrganica);

            var cestoContenedor = new Product()
            {
                ProductName = "Cesto contenedor",
                TitleDescription = "Cesto contenedor",
                ShortDescription = "Cesto contenedor de juguetes.",
                LongDescription = "Sirve como muñeco de apego, para que tu bebito descubra nuevas texturas o simplemente para jugar y divertirse.",
                ReleaseDate = "March 18, 2016",
                Price = 180,
                CoverImageUrl = "/assets/img/products/Cestos/Cover.jpg"
            };
            _context.Products.Add(cestoContenedor);


            var elefanteTela = new Product()
            {
                ProductName = "Elefante de lana",
                TitleDescription = "Elefante de lana",
                ShortDescription = "Elefante de lana y crochet.",
                LongDescription = "Sirve como muñeco de apego, para que tu bebito descubra nuevas texturas o simplemente para jugar y divertirse.",
                ReleaseDate = "March 18, 2016",
                Price = 250,
                CoverImageUrl = "/assets/img/products/ElefanteTela/Cover.png"
            };
            _context.Products.Add(elefanteTela);

            var miniElefante = new Product()
            {
                ProductName = "Mini elefante de tela",
                TitleDescription = "Mini elefante de tela",
                ShortDescription = "Mini elefante de tela con detalles en crochet.",
                LongDescription = "Una ternura este mini elefante de tela con detalles en crochet. Ideal para que tu bebito descubra nuevas texturas, con el tamaño perfecto para que pueda agarrarlo con sus manitos. También podes incluirlo en el ajuar que estés armando para regalar.",
                ReleaseDate = "March 18, 2016",
                Price = 160,
                CoverImageUrl = "/assets/img/products/Minielefantes/Cover.jpg"
            };
            _context.Products.Add(miniElefante);

            var bolsoOrganizador = new Product()
            {
                ProductName = "Bolso Organizador",
                TitleDescription = "Bolso Organizador",
                ShortDescription = "Bolso Organizador Para Paraguita.",
                LongDescription = "Súper práctico para tener todo a mano, con manijas para colgarlo del paragüita, llevarlo en la mano, colgado el brazo o del hombro.",
                ReleaseDate = "March 18, 2016",
                Price = 320,
                CoverImageUrl = "/assets/img/products/Organizador/Cover.jpg"
            };
            _context.Products.Add(bolsoOrganizador);

            var protectoresMamarios = new Product()
            {
                ProductName = "Protectores Mamarios",
                TitleDescription = "Protectores Mamarios",
                ShortDescription = "Protectores Mamarios Lavables Reutilizables.",
                LongDescription = "Confeccionados con una capa muy suave de terry de bambu, una de toalla de microfibra y una tela pul. Diámetro de 12 cm.",
                ReleaseDate = "March 18, 2016",
                Price = 60,
                CoverImageUrl = "/assets/img/products/Protectores/Cover.jpg"
            };
            _context.Products.Add(protectoresMamarios);

            await _context.SaveChangesAsync();
        }
    }
}