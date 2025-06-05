const btnLoginSideBar = document.getElementById('login-sidebar')
const btnRegisterSideBar = document.getElementById('register-sidebar')
const divForms = document.getElementById('forms')
const divSideBar = document.getElementById('sidebar')
const loginForm = document.getElementById('login-form')
const registerForm = document.getElementById('register-form')
const loginMessage = document.getElementById('login-message')
const registerMessage = document.getElementById('register-message')

// Funciones de cambio de vista
btnLoginSideBar.addEventListener('click', changeLogin);
btnRegisterSideBar.addEventListener('click', changeRegister);

function changeLogin(){
    divForms.classList.remove('active')
    divSideBar.classList.remove('active')
    loginMessage.textContent = ''
    registerMessage.textContent = ''
}

function changeRegister(){
    divForms.classList.add('active')
    divSideBar.classList.add('active')
    loginMessage.textContent = ''
    registerMessage.textContent = ''
}

// Manejo del formulario de login
loginForm.addEventListener('submit', async (e) => {
    e.preventDefault()
    const email = document.getElementById('login-email').value
    const password = document.getElementById('login-password').value

    try {
        const response = await fetch('/Auth/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
            },
            body: JSON.stringify({ email, password })
        })

        const data = await response.json()
        
        if (data.success) {
            window.location.href = data.redirectUrl
        } else {
            loginMessage.textContent = data.message
            loginMessage.style.color = 'red'
        }
    } catch (error) {
        loginMessage.textContent = 'Error al intentar iniciar sesión'
        loginMessage.style.color = 'red'
    }
})

// Manejo del formulario de registro
registerForm.addEventListener('submit', async (e) => {
    e.preventDefault()
    const nombre = document.getElementById('register-nombre').value
    const apellido = document.getElementById('register-apellido').value
    const correo = document.getElementById('register-correo').value
    const password = document.getElementById('register-password').value

    try {
        const response = await fetch('/Auth/Register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'RequestVerificationToken': document.querySelector('input[name="__RequestVerificationToken"]').value
            },
            body: JSON.stringify({ nombre, apellido, correo, password })
        })

        const data = await response.json()
        
        if (data.success) {
            window.location.href = data.redirectUrl
        } else {
            registerMessage.textContent = data.message
            registerMessage.style.color = 'red'
        }
    } catch (error) {
        registerMessage.textContent = 'Error al intentar registrarse'
        registerMessage.style.color = 'red'
    }
})

// Manejo del menú móvil
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
