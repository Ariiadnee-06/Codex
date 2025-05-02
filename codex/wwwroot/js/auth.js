document.getElementById('show-login').onclick = () => {
    document.getElementById('login-form').classList.remove('hidden');
    document.getElementById('register-form').classList.add('hidden');
};

document.getElementById('show-register').onclick = () => {
    document.getElementById('register-form').classList.remove('hidden');
    document.getElementById('login-form').classList.add('hidden');
};

async function register() {
    const messageBox = document.getElementById('register-message');
    messageBox.style.display = "none";

    const data = {
        nombre: document.getElementById('register-nombre').value,
        apellido: document.getElementById('register-apellido').value,
        correo: document.getElementById('register-correo').value,
        contraseñaHash: document.getElementById('register-password').value
    };

    const response = await fetch('/api/auth/register', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    });

    let result;
    try {
        result = await response.json();
    } catch {
        result = { mensaje: "Error inesperado del servidor." };
    }

    messageBox.textContent = result.mensaje || result;
    messageBox.className = 'message ' + (response.ok ? 'success' : 'error');
    messageBox.style.display = "block";
}


async function login() {
    const data = {
        correo: document.getElementById('login-email').value,
        contraseñaHash: document.getElementById('login-password').value
    };

    const response = await fetch('/api/auth/login', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(data)
    });

    const result = await response.json();
    if (response.ok) {
        alert("Bienvenido " + result.usuario.nombre);
        // Aquí se guardan datos en localStorage o redirigir
    } else {
        alert(result);
    }
}

// para el tab activo
document.getElementById('show-login').onclick = () => {
    document.getElementById('login-form').classList.add('active-form');
    document.getElementById('register-form').classList.remove('active-form');
    document.getElementById('show-login').classList.add('active-tab');
    document.getElementById('show-register').classList.remove('active-tab');
};

document.getElementById('show-register').onclick = () => {
    document.getElementById('register-form').classList.add('active-form');
    document.getElementById('login-form').classList.remove('active-form');
    document.getElementById('show-register').classList.add('active-tab');
    document.getElementById('show-login').classList.remove('active-tab');
};

