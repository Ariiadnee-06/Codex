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

const rawUser = localStorage.getItem('usuario');
const user = rawUser ? JSON.parse(rawUser) : null;

// Modal de alerta de login
const alertModal = document.getElementById('login-alert-modal');
const closeAlertModal = document.getElementById('close_alert_modal');

const mostrarAlerta = () => {
    if (alertModal) {
        alertModal.classList.remove('hidden');
    }
};

if (closeAlertModal) {
    closeAlertModal.addEventListener('click', () => {
        alertModal.classList.add('hidden');
    });
}

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
            formOldModal.classList.remove('hidden');
        }
    });
}

if (closeOldModal) {
    closeOldModal.addEventListener('click', () => {
        formOldModal.classList.add('hidden');
    });
}

// ----------------- CERRAR SESIÓN Y MOSTRAR USUARIO -----------------
window.addEventListener("DOMContentLoaded", () => {
    const rawUser = localStorage.getItem('usuario');
    const user = rawUser ? JSON.parse(rawUser) : null;

    const userNameSpan = document.getElementById('user-name');
    const logoutBtn = document.getElementById('logout-btn');
    const loginLi = document.getElementById('login-li');
    const logoutLi = document.getElementById('logout-li');

    console.log("🔍 Usuario detectado:", user);

    if (user && user.nombre) {
        console.log("✅ Sesión activa con:", user.nombre);
        if (userNameSpan) userNameSpan.textContent = `Hola, ${user.nombre}`;
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