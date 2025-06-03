const btnLoginSideBar = document.getElementById('login-sidebar')
const btnRegisterSideBar = document.getElementById('register-sidebar')
const divForms = document.getElementById('forms')
const divSideBar = document.getElementById('sidebar')

btnLoginSideBar.addEventListener('click', changeLogin);
btnRegisterSideBar.addEventListener('click', changeRegister);

function changeLogin(){
    divForms.classList.remove('active')
    divSideBar.classList.remove('active')
}
function changeRegister(){
    divForms.classList.add('active')
    divSideBar.classList.add('active')
}

const navMenu = document.getElementById('nav_menu'),
    navToggle = document.getElementById('nav_toggle'),
    navClose = document.getElementById('nav_close');

if (navToggle) {
    navToggle.addEventListener('click', () => {
        navMenu.classList.add('show_menu');
    });
}

if (navClose) {
    navClose.addEventListener('click', () => {
        navMenu.classList.remove('show_menu');
    });
}
