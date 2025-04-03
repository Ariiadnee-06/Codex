const navMenu = document.getElementById('nav_menu'),
      navToggle = document.getElementById('nav_toggle'),
      navClose = document.getElementById('nav_close');

// ABRIR MENÚ
if (navToggle) {
    navToggle.addEventListener('click', () => {
        navMenu.classList.add('show_menu');
    });
}

// CERRAR MENÚ
if (navClose) {
    navClose.addEventListener('click', () => {
        navMenu.classList.remove('show_menu');
    });
}

// CERRAR MENÚ AL HACER CLIC EN UN ENLACE
const navLinks = document.querySelectorAll('.nav_list a');

navLinks.forEach(link => {
    link.addEventListener('click', () => {
        navMenu.classList.remove('show_menu');
    });
});
