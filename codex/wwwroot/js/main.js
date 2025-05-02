// ----------------- MENÚ NAV -----------------
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

// ----------------- FORMULARIOS CON VALIDACIÓN DE SESIÓN -----------------
const openFormBtn = document.getElementById('openNew');
const formModal = document.getElementById('form_modal');
const closeModal = document.getElementById('close_modal');

const openOldFormBtn = document.getElementById('openOld');
const formOldModal = document.getElementById('form_modalOld');
const closeOldModal = document.getElementById('close_modalOld');

const alertBox = document.getElementById('login-alert');
const rawUser = localStorage.getItem('usuario');
const user = rawUser ? JSON.parse(rawUser) : null;

const mostrarAlerta = () => {
    if (alertBox) {
        alertBox.classList.remove('hidden');
        alertBox.style.opacity = '1';
        setTimeout(() => {
            alertBox.style.opacity = '0';
            setTimeout(() => alertBox.classList.add('hidden'), 500);
        }, 9000); // 9 segundos en pantalla
    }
};

if (openFormBtn) {
    openFormBtn.addEventListener('click', (e) => {
        e.preventDefault();
        if (!user || !user.nombre) {
            mostrarAlerta();
        } else {
            formModal.classList.remove('hidden');
        }
    });
}

if (closeModal) {
    closeModal.addEventListener('click', () => {
        formModal.classList.add('hidden');
    });
}

if (openOldFormBtn) {
    openOldFormBtn.addEventListener('click', (e) => {
        e.preventDefault();
        if (!user || !user.nombre) {
            mostrarAlerta();
        } else {
            formModal.classList.remove('hidden');
        }

    });
}

if (closeOldModal) {
    closeOldModal.addEventListener('click', () => {
        formOldModal.classList.add('hidden');
    });
}


// Inicio de Script para cerrar sesión y mostrar sesiones - By Lady 
window.addEventListener("DOMContentLoaded", () => {
    const rawUser = localStorage.getItem('usuario');
    const user = rawUser ? JSON.parse(rawUser) : null;

    const userNameSpan = document.getElementById('user-name');
    const logoutBtn = document.getElementById('logout-btn');
    const loginLi = document.getElementById('login-li');
    const logoutLi = document.getElementById('logout-li');

    console.log("🔍 Usuario detectado:", user);

    if (user && user.nombre) {
        console.log("✅ Sesión activa con:", user.Nombre);
        if (userNameSpan) userNameSpan.textContent = `Hola, ${user.Nombre}`;
        if (logoutLi) logoutLi.classList.remove('hidden');
        if (loginLi) loginLi.classList.add('hidden');
    } else {
        console.log("🚫 No hay sesión activa");
        if (logoutLi) logoutLi.classList.add('hidden');
        if (loginLi) loginLi.classList.remove('hidden');
        if (userNameSpan) userNameSpan.textContent = '';
    }

    if (logoutBtn) {
        logoutBtn.addEventListener('click', (e) => {
            e.preventDefault();
            console.log("🔒 Cerrando sesión...");
            localStorage.removeItem('usuario');
            window.location.href = "/index.html";
        });
    }
});


